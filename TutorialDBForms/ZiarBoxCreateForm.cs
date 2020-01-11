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
    public partial class ZiarBoxCreateForm : Form
    {
        public DataSet ds;

        public ZiarBoxCreateForm()
        {
            InitializeComponent();
        }

        public static void ZiarBoxCreateShow()
        {
            ZiarBoxCreateForm dialog = new ZiarBoxCreateForm();
            dialog.ShowDialog();
        }

        private void ZiarBoxCreateForm_Load(object sender, EventArgs e)
        {
            this.ziarboxTableAdapter.Fill(this.mssDBDataSet.ziarbox);
            this.dokboxTableAdapter.Fill(this.mssDBDataSet.dokbox);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (IdExists(textBox1.Text) == false)
            {
                Insert("ziarbox", "ID", "RZIARNA", textBox1.Text, textBox2.Text);
                Close();
            }
            else
            {
                MessageBox.Show("Ziarno o podanym ID już istnieje.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        public static void Insert(string tabela, string column1, string column2, string value1, string value2)
        {
            string connectionString = @"Data Source = MASTER\PIERWSZY;Initial Catalog = mssDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter cmd = new SqlDataAdapter();
            connection.Open();
            cmd.InsertCommand = new SqlCommand("INSERT INTO " + tabela + " (" + column1 + ", " + column2 + ") VALUES ('" + value1 + "', '" + value2 + "')", connection);
            cmd.InsertCommand.ExecuteNonQuery();
            connection.Close();
        }
        public static bool IdExists(string id)
        {
            string connectionString = @"Data Source = MASTER\PIERWSZY;Initial Catalog = mssDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql = "SELECT COUNT (id) from ziarbox where id = '" + id + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(sql, connection);
            var result = cmd.ExecuteScalar();
            if (result.ToString() == "0") return false;
            else return true;
        }
    }
}
