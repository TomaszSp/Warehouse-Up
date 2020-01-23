using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TutorialDBForms
{
    public partial class KonBoxFilterForm : Form
    {
        public static DataSet filteredDataSet = new DataSet();

        public KonBoxFilterForm(DataSet ds)
        {
            InitializeComponent();
            AppDataSet.setData("konbox");
            filteredDataSet = ds;
        }

        public static void KonBoxFilterShow(DataSet ds)
        {
            KonBoxFilterForm dialog = new KonBoxFilterForm(ds);
            dialog.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filteredDataSet = Filter();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private DataSet Filter ()
        {
            filteredDataSet.Clear();
            string connectionString = @"Data Source = MASTER\PIERWSZY;Initial Catalog = mssDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql = "SELECT * FROM konbox WHERE NAZWA LIKE '%" + textBox1.Text + "%'";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(filteredDataSet, "konbox");
            connection.Close();
            return filteredDataSet;
        }
    }
}
