using System;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    class LineChartData
    {
        public DateTime GetDateTime()
        {
            SQLiteHelper helper = new SQLiteHelper();
            helper.ExecuteDataSet("select ", CommandType.Text);

        }
    }
}
