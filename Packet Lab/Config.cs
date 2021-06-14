using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Packet_Lab
{
    public delegate void OnConfigurationHandler(string port, int baud, int data, StopBits stop, Parity parity);

    public partial class Config : Form
    {
        public event OnConfigurationHandler OnConfiguration;

        public Config()
        {
            InitializeComponent();

            // Default configuration: 4800 Baud, 8 bits, 1 stop, no parity
            cmbBoxPortName.SelectedIndex = 0;
            cmbBoxBaudRate.SelectedIndex = 4;
            cmbBoxDataBits.SelectedIndex = 3;
            cmbBoxStop.SelectedIndex = 0;
            cmbBoxParity.SelectedIndex = 0;

            // Get a list of serial ports for the computer
            string[] ports = SerialPort.GetPortNames();

            // Sort Alphabetically 
            Array.Sort(ports, (x, y) => String.Compare(x, y));

            int index = 1;

            // Insert available COM ports
            foreach (string port in ports)
            {
                cmbBoxPortName.Items.Insert(index, port);

                index++;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // Ensure port name is not set to "None"
            if (cmbBoxPortName.SelectedIndex == 0)
            {
                MessageBox.Show("COM port not selected.", "Error - Invalid Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Save configuration selections
                OnConfiguration(
                        cmbBoxPortName.Text,
                        int.Parse(cmbBoxBaudRate.Text), // Baud
                        int.Parse(cmbBoxDataBits.Text), // Data
                        (StopBits)Enum.Parse(typeof(StopBits), cmbBoxStop.Text, true), // Stop
                        (Parity)Enum.Parse(typeof(Parity), cmbBoxParity.Text, true)); // Parity

                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Don't save selections
            Close();
        }

        private void Config_Load(object sender, EventArgs e)
        {

        }
    }
}
