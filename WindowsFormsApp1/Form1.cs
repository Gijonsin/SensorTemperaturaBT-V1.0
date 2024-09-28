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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SerialPort sp = new SerialPort();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] puertos = SerialPort.GetPortNames();
            cb_Puertos.DataSource = puertos;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort actualSP = (SerialPort)sender;
            string inData = actualSP.ReadLine();
            lab_Temperatura.Invoke(new MethodInvoker(delegate
            {
                lab_Temperatura.Text = "Temperatura: " + inData + " °C";
            }));
        }

        private void btn_Conectar_Click(object sender, EventArgs e)
        {
            try
            {
                sp.PortName = cb_Puertos.Text;
                sp.BaudRate = 9600; // Asegúrate de que la velocidad en baudios coincida con la del módulo Bluetooth
                sp.Open();
                sp.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
                MessageBox.Show("Conectado al puerto " + sp.PortName);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            string[] puertos = SerialPort.GetPortNames();
            cb_Puertos.DataSource = puertos;
        }
    }
    
}
