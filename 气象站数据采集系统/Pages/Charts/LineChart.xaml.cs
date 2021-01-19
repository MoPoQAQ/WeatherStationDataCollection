using System;
using System.Windows;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;

namespace 气象站数据采集系统
{
    /// <summary>
    /// PieChart.xaml 的交互逻辑
    /// </summary>
    public partial class LineChart : BasePage
    {
        public LineChart()
        {
            InitializeComponent();

            cartesianChart.Series = new SeriesCollection {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> {4, 6, 5, 2, 7}
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> {6, 7, 3, 4, 6},
                    PointGeometry = null
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> {5, 2, 8, 3},
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 15
                },
            };

            cartesianChart.AxisX.Add(new Axis
            {
                Title = "时间",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun" },
                MaxValue = 5,
                MinValue = 0,
            });
            cartesianChart.AxisY.Add(new Axis
            {
                Title = "温度",
                LabelFormatter = value => value + ("℃"),
                MaxValue = 20,
                MinValue = -20,
            });
            cartesianChart.LegendLocation = LegendLocation.Right;
            //更改数据集合会触发动画并更新图表
            cartesianChart.Series.Add(new LineSeries
            {
                Values = new ChartValues<double> { 5, 3, 2, 4, 5 },
                LineSmoothness = 0, //直线, 1 表示平滑曲线
                PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                PointGeometrySize = 5,
                PointForeground = Brushes.Gray,
            });
            //更改任何series都会触发动画并更新图表
            cartesianChart.Series[2].Values.Add(5d);
            //cartesianChart.DataClick += CartesianChart1OnDataClick;
        }

        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }

        public ChartValues<double> Values { get; set; }
    }
}
