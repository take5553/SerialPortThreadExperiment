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

namespace SerialPortThreadExperiment
{
    public partial class Form1 : Form
    {
        string InpTxt;

        public Form1()
        {
            InitializeComponent();
            ShowThreadID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            InpTxt = "";
        }

        private void BtnCommOpen_Click(object sender, EventArgs e)
        {
            ShowThreadID(System.Reflection.MethodBase.GetCurrentMethod().Name);

            Comm1Open();

            ActivationSwitcher(true);
        }

        private void Comm1Open()
        {
            ShowThreadID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = Parity.Even;
            serialPort1.DataBits = 8;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Handshake = Handshake.None;
            serialPort1.PortName = "COM" + txtCommNumber.Text;
            serialPort1.NewLine = "\r\n";

            try
            {
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Comm1Open Exception:" + ex.Message);
            }

        }

        private void BtnCommClose_Click(object sender, EventArgs e)
        {
            ShowThreadID(System.Reflection.MethodBase.GetCurrentMethod().Name);

            serialPort1.Close();

            ActivationSwitcher(false);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        private void OutCmd(string tcmd)
        {
            ShowThreadID(System.Reflection.MethodBase.GetCurrentMethod().Name);

            if (serialPort1.IsOpen == false)
            {
                return;
            }

            try
            {
                serialPort1.Write(tcmd + "\r\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("OutCmd Exception:" + ex.Message);
            }
        }

        private void BtnSendCR_Click(object sender, EventArgs e)
        {
            ShowThreadID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            OutCmd("CR");
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ShowThreadID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            string data = serialPort1.ReadLine();
            InpTxt = data;
            //Response(data);
        }

        private void Response(string text)
        {
            ShowThreadID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            if (InvokeRequired)
            {
                Invoke(new Action<string>(Response), text);
                return;
            }
            lblReceivedText.Text += text + serialPort1.NewLine;
        }

        private void ShowThreadID(string method)
        {
            int id = System.Threading.Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("ID : " + id + "(" + method + ")");
        }

        private void ActivationSwitcher(bool Activation)
        {
            // シリアルポートが開く前用のコントロールを無効化
            btnCommOpen.Enabled = !Activation;

            // シリアルポートが開いた後用のコントロールを有効化
            btnCommClose.Enabled = Activation;
            btnSendCR.Enabled = Activation;
            btnCRAndWaitResponse.Enabled = Activation;
        }

        private void btnCRAndWaitResponse_Click(object sender, EventArgs e)
        {
            ShowThreadID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            SendCRAndWaitResponse2();
        }

        private async void SendCRAndWaitResponse()
        {
            ShowThreadID("SendCRAndWait 開始");
            int t = 200;
            OutCmd("CR");
            do
            {
                await Task.Delay(50);
                t -= 1;
            } while (t >= 0 && InpTxt == "");
            if (t < 0)
            {
                Console.WriteLine("Failed Receiving: InpTxt = " + InpTxt + ", t = " + t);
                ShowThreadID(System.Reflection.MethodBase.GetCurrentMethod().Name);
                InpTxt = "";
                return;
            }
            Console.WriteLine("Data Received: InpTxt = " + InpTxt + ", t = " + t);
            ShowThreadID("SendCRAndWait 終了");
            lblReceivedText.Text += InpTxt + serialPort1.NewLine;
            InpTxt = "";
        }

        private void SendCRAndWaitResponse2()
        {
            ShowThreadID("SendCRAndWait 開始");
            int t = 20000000;
            OutCmd("CR2");
            do
            {
                Application.DoEvents();
                t -= 1;
            } while (t >= 0 && InpTxt == "");
            if (t < 0)
            {
                Console.WriteLine("Failed Receiving: InpTxt = " + InpTxt + ", t = " + t);
                ShowThreadID(System.Reflection.MethodBase.GetCurrentMethod().Name);
                InpTxt = "";
                return;
            }
            Console.WriteLine("Data Received: InpTxt = " + InpTxt + ", t = " + t);
            ShowThreadID("SendCRAndWait 終了");
            lblReceivedText.Text += InpTxt + serialPort1.NewLine;
            InpTxt = "";
        }
    }
}
