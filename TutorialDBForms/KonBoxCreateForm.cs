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
    public partial class KonBoxCreateForm : Form
    {
        public DataSet ds;

        public KonBoxCreateForm()
        {
            InitializeComponent();
        }

        public static void KonBoxCreateShow()
        {
            KonBoxCreateForm dialog = new KonBoxCreateForm();
            dialog.ShowDialog();
        }

        private void KonBoxCreateForm_Load(object sender, EventArgs e)
        {
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Insert("konbox", "NAZWA", textBox2.Text);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        public static void Insert(string tabela, string column1, string value1)
        {
            string connectionString = @"Data Source = MASTER\PIERWSZY;Initial Catalog = mssDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter cmd = new SqlDataAdapter();
            connection.Open();
            cmd.InsertCommand = new SqlCommand("INSERT INTO " + tabela + " (" + column1 + ") VALUES ('" + value1 + "')", connection);
            cmd.InsertCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}
