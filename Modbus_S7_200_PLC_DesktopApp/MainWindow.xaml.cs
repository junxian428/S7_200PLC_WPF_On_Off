using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Sockets;
using Modbus.Device;
using S7.Net;

namespace Modbus_S7_200_PLC_DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PLC_Modbus(object sender, RoutedEventArgs e)
        {
            // Create an instance of the S7.Net Plc object
            Plc plc = new Plc(CpuType.S7200, "192.168.1.25", 0, 1);

            // Open the connection to the PLC
            plc.Open();

            // Turn on the Q0.0 output
            plc.Write("Q0.0",true);

            // Read the I0.0 input
            bool inputStatus = (bool)plc.Read("I0.0");

            // Close the connection to the PLC
            plc.Close();

            if (inputStatus)
            {
                MessageBox.Show("Output Q0.0 turned on and input I0.0 is active.");
            }
            else
            {
                MessageBox.Show("Failed to turn on output Q0.0 or input I0.0 is inactive.");
            }

        }
    
    }
}
