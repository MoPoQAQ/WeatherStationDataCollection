using System;
using System.Collections.Generic;
using System.IO;
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

using System.Windows.Threading;

namespace 气象站数据采集系统
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        SelectCommunicationMethodPage selectCommunicationMethod = new SelectCommunicationMethodPage();
        WiredSettingPage wiredSetting = new WiredSettingPage();
        WirelessSettingPage wirelessSetting = new WirelessSettingPage();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new WindowViewModel(this);

            MainFrame.Content = selectCommunicationMethod;
            selectCommunicationMethod.btn_wired.Click += Btn_wired_Click;
            selectCommunicationMethod.btn_wireless.Click += Btn_wireless_Click;

            wiredSetting.ButtonExit.Click += ButtonExit_Click;
        }

        private void Btn_wired_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = wiredSetting;
        }

        private void Btn_wireless_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = wirelessSetting;
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = selectCommunicationMethod;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
