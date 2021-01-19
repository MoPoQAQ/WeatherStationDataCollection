using System;
using System.IO;
using System.IO.Ports;
using System.Threading.Tasks;

namespace 气象站数据采集系统
{
    /// <summary>
    /// WiredSettingPage.xaml Interaction logic
    /// </summary>
    public partial class WiredSettingPage : BasePage
    {
        HistoricalDataPage historicalData = new HistoricalDataPage();
        RealtimeDataPage realtimeData = new RealtimeDataPage();

        SerialPort Sp = new SerialPort();
        SerialPortControl serialPort;

        public WiredSettingPage()
        {
            InitializeComponent();

            Sp.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
        }

        public void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string s = "";
            int count = Sp.BytesToRead;//缓冲数据区数据的字节数

            byte[] data = new byte[count];//用于保存缓冲数据区的数据
            Sp.Read(data, 0, count);

            foreach (byte item in data)
            {
                s += Convert.ToChar(item);
            }

            this.Dispatcher.Invoke(new Action(() =>
            {//委托操作GUI控件的部分
                //tbReceiveData.Text += s;   //textbox文字加上字符串s
            }));
        }

        private void Btn_Add_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            serialPort = new SerialPortControl();
            SerialPortList.Items.Add(serialPort);
        }

        private void Btn_Del_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                SerialPortList.Items.RemoveAt(SerialPortList.SelectedIndex);
            }
            catch
            { }
        }

        private void Btn_real_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "WiredSetting.txt", false))
            {
                for (int i = 0; i < SerialPortList.Items.Count; i++)
                {
                    SerialPortControl serialPort = SerialPortList.Items[i] as SerialPortControl;
                    string result = serialPort.serialPorts.Text + "/"
                        + serialPort.baudRate.Text + "/"
                        + serialPort.checkDigit.Text + "/"
                        + serialPort.dataBit.Text + "/"
                        + serialPort.stopBit.Text + "|";
                    sw.Write(result);
                }
                sw.Close();
            }

            DataDisplay.Content = realtimeData;
        }

        private void Btn_hist_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DataDisplay.Content = historicalData;
        }
    }
}
