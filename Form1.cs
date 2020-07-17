using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ArduinoRemoute
{
    public partial class Form1 : Form
    {
        const int COM_PORT = 8;
        const int KEYS_AMMOUNT = 9;

        string RecivedData;
        int CurrentPressed = -1;
        int LastPressed = -1;


        public Form1()
        {
            InitializeComponent();
            serialPort1.PortName = "COM8";
            serialPort1.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            RecivedData = serialPort1.ReadLine();

            switch (RecivedData.Trim())
            {
                case "E318261B":
                    CurrentPressed = 0;
                    break;
                case "511DBB":
                    CurrentPressed = 1;
                    break;
                case "EE886D7F":
                    CurrentPressed = 2;
                    break;
                case "52A3D41F":
                    CurrentPressed = 3;
                    break;
                case "D7E84B1B":
                    CurrentPressed = 4;
                    break;
                case "20FE4DBB":
                    CurrentPressed = 5;
                    break;
                case "F076C13B":
                    CurrentPressed = 6;
                    break;
                case "A3C8EDDB":
                    CurrentPressed = 7;
                    break;
                case "E5CFBD7F":
                    CurrentPressed = 8;
                    break;
                case "FFFFFFFF":
                    CurrentPressed = LastPressed;
                    break;
            }

            Console.WriteLine(CurrentPressed);
            LastPressed = CurrentPressed;
        }

    }
}
