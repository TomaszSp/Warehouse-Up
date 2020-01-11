using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using System.Xml;

namespace TutorialDBForms
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = TutorialDB; Integrated Security = True; Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout = 60; Encrypt=False;TrustServerCertificate=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Person";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "Person");
            connection.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Person";
        }
    }
}
