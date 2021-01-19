using System.Collections.Generic;
using System.Data;
using BLL;

namespace 气象站数据采集系统
{
    /// <summary>
    /// ListChart.xaml 的交互逻辑
    /// </summary>
    public partial class ListChart : BasePage
    {
        public ListChart()
        {
            InitializeComponent();

            ListChartData listChartData = new ListChartData();
            DataTable table = listChartData.GetData();

            List<Customer> ltCus = new List<Customer>();
            foreach (DataRow dataRow in table.Rows)
            {
                Customer cus = new Customer
                {
                    CusID = dataRow["id"].ToString(),
                    CusTime = dataRow["nowtime"].ToString(),
                    CusLight = dataRow["light"].ToString(),
                    CusTemp = dataRow["temp"].ToString(),
                    CusHumi = dataRow["humi"].ToString(),
                    CusAirp = dataRow["airp"].ToString(),
                    CusAlti = dataRow["alti"].ToString(),
                    CusAdco = dataRow["adco"].ToString(),
                };
                ltCus.Add(cus);
            }
            listView.ItemsSource = ltCus;
        }
    }
}
