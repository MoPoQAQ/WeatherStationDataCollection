using System;
using LiveCharts;

namespace 气象站数据采集系统
{
    /// <summary>
    /// HistoricalDataPage.xaml 的交互逻辑
    /// </summary>
    public partial class HistoricalDataPage : BasePage
    {
        public HistoricalDataPage()
        {
            InitializeComponent();

            ListChart listChart = new ListChart();
            ChartsFrame.Content = listChart;
        }

        private void Data_Display_DropDownClosed(object sender, EventArgs e)
        {
            switch (Data_Display.Text)
            {
                case "折线图":
                    LineChart lineChart = new LineChart();
                    ChartsFrame.Content = lineChart;
                    break;

                case "列表图":
                    ListChart listChart = new ListChart();
                    ChartsFrame.Content = listChart;
                    break;
            }
        }
    }
}
