using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using Packet_Lab;
using TestCRC8;

namespace Packet_Lab
{
    public partial class Main : Form
    {
        enum State
        {
            SETUP,               // Setting up port configuration 
            CHECKING_CONN,       // Sending an ENQ to RX port 
            CONNECTED,           // Received ACK
            DISCONNECTED,        // Received NAK
            START_NEW_PACKET,    // Received SOH
            READING_PACKET,      // Received regular data
            END_TRANSMISSION     // Received EOT 
        }

        enum Mode
        {
            TX_MODE,             // Transmit mode 
            RX_MODE,             // Receive mode 
        }

        enum Transmission
        {
            NONE,
            ERROR_FREE,         // Error free packet transmission
            CRC_WR,             // CRC error with recovery
            CRC_NR,             // CRC error with no recovery
            SOH_WR              // SOH error with recovery
        }

        const int FAILURE_PACKET = 4;                           // Packet used for error modes
        const int PACKET_SIZE = 7;                              // Protocol defined packet size

        State currState = State.SETUP;                          // Starting state is setup
        Mode currMode = Mode.TX_MODE;                           // Default to transmit mode
        Transmission currTran = Transmission.ERROR_FREE;        // Default to error free mode

        TaskCompletionSource<bool> tcs = null;                  // Used to block sending of packets until ACK is received

        private int attempts = 0;                               // Attempts to reconnect in error modes
        private int packetsSent = 0;                            // Tracks how many packets have been sent
        private byte[] chkConn = new byte[1] { ASCII.ENQ };     // byte[] used for serial port send
        List<byte[]> recvBuffer = new List<byte[]>();           // Buffer for saving file 

        Config frmConfig = new Config();
        Packet packetProcessor = new Packet();

        public Main()
        {
            InitializeComponent();

            txtHexView.AppendText("Hexademical View" + Environment.NewLine);
            txtASCIIView.AppendText("ASCII View" + Environment.NewLine);

            
            // Display that no port is selected
            tsrPortName.Text = "None";
            tsrPortName.BackColor = tsrPortName.BackColor;
            tsrPortName.ForeColor = Color.Red;

            // Display that no port is open
            tsrPortStatus.Text = "Closed";
            tsrPortStatus.BackColor = tsrPortStatus.BackColor;
            tsrPortStatus.ForeColor = Color.Red;

            // Display that there is no connection
            tsrConnectionStatus.Text = "Not Connected";
            tsrConnectionStatus.BackColor = tsrConnectionStatus.BackColor;
            tsrConnectionStatus.ForeColor = Color.Red;

            // Display that file is not loaded
            tsrFileStatus.Text = "Not Loaded";
            tsrFileStatus.BackColor = tsrFileStatus.BackColor;
            tsrFileStatus.ForeColor = Color.Red;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /**
         * Sets COM ports configuration and displays
         */
        private void OnConfiguration(string port, int baud, int data, StopBits stop, Parity parity)
        {
            // Apply configuration
            serialPort.PortName = port;
            serialPort.BaudRate = baud;
            serialPort.DataBits = data;
            serialPort.StopBits = stop;
            serialPort.Parity = parity;
            
            // Display configuration
            txtPortName.Text = port;
            tsrPortName.Text = port;
            tsrPortName.BackColor = tsrPortName.BackColor;
            tsrPortName.ForeColor = Color.Green;
            txtBaudRate.Text = Convert.ToString(baud);
            txtDataBits.Text = Convert.ToString(data);
            txtStop.Text = Convert.ToString(stop);
            txtParity.Text = Convert.ToString(parity);

        }

        /**
         * Loads a .txt file, and packetizes the data in format: [SOH, d0, d1, d2, d3, d4, CRC] 
         * where d0 - d4 represent single data bytes. The Packet object stores the buffer of packets to 
         * transmit. 
         */
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            if (packetProcessor.readFile())
            {
                tsrFileStatus.Text = "Loaded";
                tsrFileStatus.BackColor = tsrPortStatus.BackColor;
                tsrFileStatus.ForeColor = Color.Green;
            }
            else
            {
                MessageBox.Show("File contains no data.", "Error - No file data.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void tsmiConfigure_Click(object sender, EventArgs e)
        {
            // Open config form with delegate
            frmConfig.OnConfiguration += OnConfiguration;
            frmConfig.ShowDialog();    
        }

        private void tsmiOpenPort_Click(object sender, EventArgs e)
        {
            // Check if port is already open
            if (!serialPort.IsOpen)
            {
                try
                {
                    // Open port and update status
                    serialPort.Open();

                    if (radTransmit.Checked)
                        currMode = Mode.TX_MODE;
                    else if (radReceive.Checked)
                        currMode = Mode.RX_MODE;

                    radTransmit.Enabled = false;
                    radReceive.Enabled = false;
                    tsrPortStatus.Text = "Open";
                    tsrPortStatus.BackColor = tsrPortStatus.BackColor;
                    tsrPortStatus.ForeColor = Color.Green;
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("Port is unavailable.", "Error - Port Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Serial Port is already open.");
            }
        }

        private void tsmiClosePort_Click(object sender, EventArgs e)
        {
            // Check if port is already closed
            if (serialPort.IsOpen)
            {

                // Close port and update status
                serialPort.Close();
                radTransmit.Enabled = true;
                radReceive.Enabled = true;
                tsrPortStatus.Text = "Closed";
                tsrPortStatus.BackColor = tsrPortStatus.BackColor;
                tsrPortStatus.ForeColor = Color.Red;
            }
            else
            {
                MessageBox.Show("The serial port must be open before it can be closed.");
            }
        }

        /**
         * Clears the display of each textbox, and rewrites the title of each
         */
        private void tsmiClear_Click(object sender, EventArgs e)
        {
            txtASCIIView.Invoke(new EventHandler(delegate
            {
                txtASCIIView.Clear();
                txtASCIIView.AppendText("ASCII View" + Environment.NewLine);
            }));

            txtHexView.Invoke(new EventHandler(delegate
            {
                txtHexView.Clear();
                txtHexView.AppendText("Hexademical View" + Environment.NewLine);
            }));
        }

        /**
         * Clean up buffer, global variables, and states
         */
        private void cleanUp()
        {
            if (currState != State.DISCONNECTED || currMode == Mode.RX_MODE)
                currState = State.CONNECTED;

            packetsSent = 0;
            attempts = 0;

            recvBuffer.Clear();

        }

        /**
         * Prompts user to enter a path and name to save the file
         */
        private void saveFile()
        {
            String file = "";
            String path = "";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            bool result = false;

            // Convert bytes into string
            foreach (byte[] byteArry in recvBuffer)
            {
                file += System.Text.Encoding.ASCII.GetString(byteArry);
            }

            // Configure save file dialog box
            System.Windows.Forms.SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
            dlg.FileName = "Document";                      
            dlg.DefaultExt = ".text";                       
            dlg.Filter = "Text documents (.txt)|*.txt";     


            // Show save file dialog box
            if (dlg.ShowDialog() == DialogResult.OK)
                result = true;    

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                path = dlg.FileName;

                // Write file to text file at designated path
                using (StreamWriter writer = new StreamWriter(File.Create(path)))
                {
                    writer.Write(file);
                    writer.Flush();

                    writer.Close();
                }


                MessageBox.Show("File saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currState = State.CHECKING_CONN;

            if (!serialPort.IsOpen)
            {
                currState = State.SETUP;

                MessageBox.Show("Port is not open.", "Error - Port Not Open", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (currMode == Mode.RX_MODE)
                {
                    currState = State.SETUP;

                    MessageBox.Show("Port is in Receive Mode.", "Error - Invalid Mode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (currMode == Mode.TX_MODE)
                {
                    // Display sending of ENQ
                    txtASCIIView.AppendText("SEND:" + "\t" + ASCII.ASCII_Controls.FirstOrDefault(x => x.Value == ASCII.ENQ).Key + Environment.NewLine);

                    // chkConn contains an ENQ ASCII code
                    serialPort.Write(chkConn, 0, 1);

                }
            }
        }
   
        private async void transmitFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currMode != Mode.TX_MODE || currState != State.CONNECTED)
            {
                MessageBox.Show("Must be in transmit mode and connected to send file. ", "Error - Not Ready to Send.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                byte[] sendPacket = new byte[PACKET_SIZE];

                // Loop for every packet in buffer
                for (int i = 0; i < packetProcessor.packetBuffer.Count; i++)
                {
                    tcs = new TaskCompletionSource<bool>();

                    // Copy data into sending packet
                    Array.Copy(packetProcessor.packetBuffer[i], sendPacket, PACKET_SIZE);

                    // If in CRC NO RECOVERY mode and at the failure packet or reattempts of this packet, then inject CRC error
                    if (i >= FAILURE_PACKET - 1 && currTran == Transmission.CRC_NR)
                    {
                        CRC crc = new CRC(sendPacket);
                        crc.injectErrors();
                    }

                    // If in CRC WITH RECOVERY mode and at the failure packet, then inject CRC error once
                    if (packetsSent == FAILURE_PACKET - 1 && currTran == Transmission.CRC_WR)
                    {
                        CRC crc = new CRC(sendPacket);
                        crc.injectErrors();
                    }

                    // Remove SOH at failure packet in SOH WITH RECOVERY mode
                    if (packetsSent == FAILURE_PACKET - 1 && currTran == Transmission.SOH_WR)
                    {
                        sendPacket[0] = 0x00;
                    }


                    // If the max attempts has reached, clear out buffers and stop transmission
                    if (attempts == 3)
                    {
                        serialPort.DiscardInBuffer();
                        serialPort.DiscardOutBuffer();
                        cleanUp();

                        MessageBox.Show("Transmission has failed in CRC - No recovery mode. Max 3 attempts reached.", "Error - CRC_NR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;
                    }

                    // Display of sent data
                    txtASCIIView.Invoke(new EventHandler(delegate
                    {
                        // Display sent data
                        txtASCIIView.AppendText("SEND:" + "\t");

                        for (int j = 0; j < PACKET_SIZE; j++)
                        {
                            if (ASCII.ASCII_Controls.ContainsValue(sendPacket[j]))
                            {
                                txtASCIIView.AppendText(ASCII.ASCII_Controls.FirstOrDefault(x => x.Value == sendPacket[j]).Key + "\t");
                            }
                            else if (sendPacket[j] == 0x00)
                            {
                                txtASCIIView.AppendText("\t");
                            }
                            else
                            {
                                txtASCIIView.AppendText(Convert.ToString(Convert.ToChar(sendPacket[j])) + "\t");
                            }
                        }
                    }));

                    // Write a packet 
                    serialPort.Write(sendPacket, 0, PACKET_SIZE);

                    serialPort.WriteTimeout = 1000;

                    // Pause execution until ACK is received
                    await tcs.Task;

                    // If a NAK was received, increment attempts and go back an index in packet buffer to resend
                    if (currState == State.DISCONNECTED && currTran == Transmission.CRC_NR)
                    {
                        attempts++;
                        i--;
                    }

                    if (currState == State.DISCONNECTED && (currTran == Transmission.CRC_WR || currTran == Transmission.SOH_WR))
                    {
                        attempts++;

                        if (attempts == 1)
                            i--;

                    }

                    // Global variable to keep track of packets sent 
                    packetsSent++;
                }

                cleanUp();
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
      
            txtASCIIView.Invoke(new EventHandler(delegate
            {
                byte[] recvPacket = new byte[PACKET_SIZE];
                int readByte;
                int packetBytes = 0;

                while (serialPort.BytesToRead > 0 && currState != State.END_TRANSMISSION)
                {
                    // Read a byte from the serial port
                    readByte = serialPort.ReadByte();

                    // Determine the state depending on the byte 
                    switch (readByte)
                    {
                        case (ASCII.ENQ):
                            currState = State.CHECKING_CONN;
                            break;
                        case (ASCII.ACK):
                            currState = State.CONNECTED;
                            break;
                        case (ASCII.NAK):
                            currState = State.DISCONNECTED;
                            break;
                        case (ASCII.SOH):
                            currState = State.START_NEW_PACKET;
                            break;
                        case (ASCII.EOT):
                            currState = State.END_TRANSMISSION;
                            break;
                        default:
                            currState = State.READING_PACKET;
                            break;
                    }

                    // Determine what to do based on state 
                    switch (currState)
                    {
                        case (State.CHECKING_CONN):
                            {
                                radReceive.Checked = true;
                                currMode = Mode.RX_MODE;

                                // Set connection status to N/A for RX_MODE
                                if (currMode == Mode.RX_MODE)
                                    tsrConnectionStatus.Text = "N/A (Receive Mode)";

                                // Respond with ACK
                                packetProcessor.respondACK(serialPort);

                                break;
                            }
                        case (State.CONNECTED):
                            {
                                tsrConnectionStatus.Text = "Connected";
                                tsrConnectionStatus.BackColor = tsrConnectionStatus.BackColor;
                                tsrConnectionStatus.ForeColor = Color.Green;

                                break;
                            }
                        case (State.DISCONNECTED):
                            {
                                tsrConnectionStatus.Text = "Disconnected";
                                tsrConnectionStatus.BackColor = tsrConnectionStatus.BackColor;
                                tsrConnectionStatus.ForeColor = Color.Red;

                                break;
                            }
                        case (State.START_NEW_PACKET):
                            {
                                txtASCIIView.AppendText(Environment.NewLine);

                                // Read first byte of packet
                                recvPacket[packetBytes] = Convert.ToByte(readByte);
                                packetBytes++;

                                break;
                            }
                        case (State.READING_PACKET):
                            {
                                
                                // First byte wasn't SOH, display receiving of nothing
                                if (packetBytes == 0)
                                {
                                    txtASCIIView.AppendText(Environment.NewLine);
                                    txtASCIIView.AppendText("RECV:" + "\t" + "\t");
                                }

                                recvPacket[packetBytes] = Convert.ToByte(readByte);
                                packetBytes++;


                                if (packetBytes == PACKET_SIZE)
                                {
                                    packetsSent++;

                                    CRC crc = new CRC(recvPacket);

                                    // Calculate CRC
                                    ushort crcValue = crc.crc(true);

                                    // Send ACK and store in buffer if CRC is valid, NAK if invalid
                                    if (crcValue == 0)
                                    {
                                        // Temp packet to store contents
                                        byte[] tempPacket = new byte[5];

                                        // Copy data to temp packet 
                                        Array.Copy(recvPacket, 1, tempPacket, 0, 5);

                                        // Add packet to buffer
                                        recvBuffer.Add(tempPacket);

                                        // Clear recvPacket to continue receiving data
                                        Array.Clear(recvPacket, 0, PACKET_SIZE);

                                        // Reset index
                                        packetBytes = 0;

                                        // Send ACK 
                                        packetProcessor.respondACK(serialPort);
                                    }
                                    else
                                    {
                                        // Failed attempt 
                                        attempts++;

                                        // Reset index
                                        packetBytes = 0;

                                        // Send NAK
                                        packetProcessor.respondNAK(serialPort);

                                        if (attempts == 3 && currTran == Transmission.CRC_NR)
                                        {
                                            cleanUp();
                                        }
                                    }
                                }

                                break;
                            }
                        case (State.END_TRANSMISSION):
                            {
                                recvPacket[packetBytes] = Convert.ToByte(readByte);

                                serialPort.DiscardInBuffer();

                                packetProcessor.respondACK(serialPort);

                                break;
                            }


                    } // End state switch


                    // If transmission is over, save file and clean up receiving side
                    if (currMode == Mode.RX_MODE && currState == State.END_TRANSMISSION)
                    {
                        saveFile();
                        cleanUp();
                    }

                    // Logic for printing out send and recveive
                    if (currMode == Mode.TX_MODE)
                    {
                        txtASCIIView.AppendText(Environment.NewLine);
                        txtASCIIView.AppendText("RECV:" + "\t");

                        if (ASCII.ASCII_Controls.ContainsValue(readByte))
                        {
                            // If byte is in ASCII Control map, print key
                            txtASCIIView.AppendText(ASCII.ASCII_Controls.FirstOrDefault(x => x.Value == readByte).Key + "\t");
                        }
                        else
                        {
                            // Print byte not in map
                            txtASCIIView.AppendText(Convert.ToChar(readByte) + "\t");
                        }

                        txtASCIIView.AppendText(Environment.NewLine);

                        if (currState == State.CONNECTED)
                        {
                            // If TX_MODE receives ACK it is CONNECTED, allow next packet to transmit
                            tcs?.TrySetResult(true);
                        }
                        else if (currState == State.DISCONNECTED)
                        {
                            tcs?.TrySetResult(true);

                        }
                    }
                    else if (currMode == Mode.RX_MODE)
                    {
                        if (currState == State.CHECKING_CONN || currState == State.START_NEW_PACKET)
                        {
                            txtASCIIView.AppendText("RECV:" + "\t");
                        }

                        if (ASCII.ASCII_Controls.ContainsValue(readByte))
                        {
                            txtASCIIView.AppendText(ASCII.ASCII_Controls.FirstOrDefault(x => x.Value == readByte).Key + "\t");
                        }
                        else
                        {
                            txtASCIIView.AppendText(Convert.ToChar(readByte) + "\t");
                        }

                        if (currState == State.CHECKING_CONN)
                        {
                            txtASCIIView.AppendText(Environment.NewLine);
                        }
                    }
                } // End while loop
            })); // End invoke of delegate
        }

        private void radTransmit_CheckedChanged(object sender, EventArgs e)
        {
            if (radTransmit.Checked)
            {
                currMode = Mode.TX_MODE;
                connectToolStripMenuItem.Enabled = true;
                transmitFileToolStripMenuItem.Enabled = true;
                radNoError.Enabled = true;
                radCRCErrorR.Enabled = true;
                radCRCErrorNR.Enabled = true;
                radSOHErrorR.Enabled = true;
                tsrMode.Text = "Transmit";
            }

        }

        private void radReceive_CheckedChanged(object sender, EventArgs e)
        {
            if (radReceive.Checked)
            {
                currMode = Mode.RX_MODE;
                connectToolStripMenuItem.Enabled = false;      
                transmitFileToolStripMenuItem.Enabled = false;

                tsrMode.Text = "Receive";
            }

        }

        private void radNoError_CheckedChanged(object sender, EventArgs e)
        {
            // No error
            if (radNoError.Checked)
            {
                currTran = Transmission.ERROR_FREE;
            }
        }

        private void radCRCErrorR_CheckedChanged(object sender, EventArgs e)
        {
            // CRC error with recovery
            if (radCRCErrorR.Checked)
            {
                currTran = Transmission.CRC_WR;
            }
        }

        private void radCRCErrorNR_CheckedChanged(object sender, EventArgs e)
        {
            // CRC error with no recovery
            if (radCRCErrorNR.Checked)
            {
                currTran = Transmission.CRC_NR;
            }
        }

        private void radSOHErrorR_CheckedChanged(object sender, EventArgs e)
        {
            // SOH error with recovery
            if (radSOHErrorR.Checked)
            {
                currTran = Transmission.SOH_WR;
            }
        }
    }
}
