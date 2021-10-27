using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestCRC8;

namespace Packet_Lab
{
    public static class ASCII
    {
        // Special ASCII characters used
        public const byte EOT = 0x04;
        public const byte ENQ = 0x05;
        public const byte ACK = 0x06;
        public const byte NAK = 0x15;
        public const byte LF = 0x0A;
        public const byte CR = 0x0D;
        public const byte SOH = 0x01;

        // ASCII control character lookup for display purposes 
        public static SortedDictionary<string, int> ASCII_Controls = new SortedDictionary<string, int>()
        {
            { "SOH", 1 },
            { "EOT", 4 },
            { "ENQ", 5 },
            { "ACK", 6 },
            { "LF", 10 },
            { "CR", 13 },
            { "NAK", 21 },
            { "PAD", 255 }
        };
    }

    public class Packet
    {
        // Program constant definitions
        private const int PACKET_SIZE = 7;
        private const int DATA_SIZE = 5;
        private const byte PAD = 0xFF; // Pad packets when < 5 bytes
        private const byte SPACE = 32; // ASCII - lowest printable char
        private const byte TILDE = 126; // ASCII - highest printable char

        // Response
        private byte[] nak = new byte[1] { ASCII.NAK };
        private byte[] ack = new byte[1] { ASCII.ACK };

        // Components of packets 
        private ushort CRC_VALUE;

        // List to hold packets accessible to application
        public List<byte[]> packetBuffer = new List<byte[]>();

        public Packet()
        {
            CRC_VALUE = 0;
        }

        public void respondACK(SerialPort rxPort)
        {
            rxPort.Write(ack, 0, 1);
        }

        public void respondNAK(SerialPort rxPort)
        {
            rxPort.Write(nak, 0, 1);
        }

        public byte[] calculateCRC(byte[] packetData, bool eotPacket)
        {
            // Char array to store data that CRC operates on 
            char[] crcData = new char[PACKET_SIZE - 1];

            // Byte array for final data with CRC that is returned by function
            byte[] finalPacket = new byte[PACKET_SIZE];

            // SOH for both
            crcData[0] = Convert.ToChar(ASCII.SOH);
            finalPacket[0] = ASCII.SOH;

            // If the last packet only contains EOT, store EOT at element 1
            if (eotPacket)
            {
                crcData[1] = Convert.ToChar(ASCII.EOT);
                finalPacket[1] = ASCII.EOT;
            }
            else
            {
                crcData[1] = Convert.ToChar(packetData[1]);
                finalPacket[1] = packetData[1];
            }

            // Populate crc data depending on whether this is the EOT packet
            for (int i = 2; i < PACKET_SIZE - 1; i++)
            {
                if (eotPacket)
                {
                    finalPacket[i] = PAD;
                    crcData[i] = Convert.ToChar(PAD);
                }
                else
                {
                    finalPacket[i] = packetData[i];
                    crcData[i] = Convert.ToChar(packetData[i]);
                }
            }

            // Calculate CRC
            CRC crc = new CRC(crcData);
            CRC_VALUE = crc.crc(false); // Not decode

            // Store CRC in packet
            finalPacket[PACKET_SIZE - 1] = Convert.ToByte(CRC_VALUE);

            // Return packet containing calculated CRC value
            return finalPacket;
        }

        public bool readFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            // Ininitalize file search to current folder
            fileDialog.InitialDirectory = "C:/Users/%USERPROFILE%/source/repos/PacketLab/PacketLab";

            // Filter for only text files
            fileDialog.Filter = "Text Files (*.txt) | *.txt";

            // Show dialog, select and display text file
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // Initialize String to absolute path the selected text file
                String file = fileDialog.FileName;

                StreamReader reader = new StreamReader(file);

                // Read from file
                while (!reader.EndOfStream)
                {
                    byte[] packet = new byte[PACKET_SIZE];
                    char[] data = new char[DATA_SIZE];

                    packet[0] = ASCII.SOH;

                    // Add PAD characters in data
                    for (int i = 0; i < DATA_SIZE; i++)
                    {
                        data[i] = Convert.ToChar(PAD);
                    }

                    reader.Read(data, 0, DATA_SIZE);


                    bool checkEOT = false;

                    // Add data to packet
                    for (int i = 1; i < PACKET_SIZE - 1; i++)
                    {
                        // If a PAD character is reached, this is the end of the data so add EOT
                        if (data[i - 1] == Convert.ToChar(PAD))
                        {
                            packet[i] = ASCII.EOT;

                            // Fill the rest with PAD chars
                            for (int j = i; j < PACKET_SIZE - 1; j++)
                            {
                                packet[j + 1] = Convert.ToByte(PAD);
                            }

                            // Done building packet
                            break;
                        }
                        else
                        {
                            packet[i] = Convert.ToByte(data[i - 1]);
                        }
                    }

                    // Check if the last packet in the stream contained EOT in final element
                    if (reader.EndOfStream && !Array.Exists(packet, element => element == ASCII.EOT))
                    {
                        checkEOT = true;
                    }
                    

                    // Add packet to buffer
                    packetBuffer.Add(calculateCRC(packet, false));

                    // Include an additional final packet with just SOH, EOT, PAD data, and CRC 
                    if (checkEOT == true)
                    {
                        packetBuffer.Add(calculateCRC(null, true));
                    }

                }

                // Restore OpenFileDialog opening directory to original directory
                fileDialog.RestoreDirectory = true;

                reader.Close();
            }

            if (packetBuffer.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
