using System;
using System.Windows.Controls;

using System.IO.Ports;


namespace 气象站数据采集系统
{
    /// <summary>
    /// SerialPortControl.xaml 的交互逻辑
    /// </summary>
    public partial class SerialPortControl : UserControl
    {
        public SerialPortControl()
        {
            InitializeComponent();

            foreach (var ports in SerialPort.GetPortNames())
            {
                serialPorts.Items.Add(ports);
            }
        }
    }
}
