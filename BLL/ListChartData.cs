using DAL;
using System.Data;

namespace BLL
{
    public class ListChartData
    {
        public DataTable GetData()
        {
            SQLiteHelper helper = new SQLiteHelper();
            DataSet set = helper.ExecuteDataSet("select * from Data;", CommandType.Text);
            DataTable table = set.Tables[0];
            return table;
        } 
    }
}
