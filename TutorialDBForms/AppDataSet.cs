using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TutorialDBForms
{
    class AppDataSet
    {
        public static DataSet ds;
        public static string connectionString;
        public static DataSet setData(string tabela)
        {
            string connectionString = @"Data Source = MASTER\PIERWSZY;Initial Catalog = mssDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql = "SELECT * FROM " + tabela;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, tabela);
            connection.Close();
            return ds;
        }
    }
}
