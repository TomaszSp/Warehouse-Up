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
    public partial class DokBoxFilterForm : Form
    {
        public static List<string> typyDokumentow = new List<string>() {"", "PM", "MM", "WM"};
        public static List<string> zbiorniki = new List<string>() {"", "BIN1", "BIN2", "BIN3", "BIN4", "BIN5", "BIN6", "BIN7", "BIN8", "BIN9", "BIN10", "HALA1", "HALA2", "Z. ZAŁ"};
        public static DataSet filteredDataSet= new DataSet();

        public DokBoxFilterForm(DataSet ds)
        {
            InitializeComponent();
            AppDataSet.setData("dokbox");
            ComboBoxData();
            filteredDataSet = ds;
        }

        public static void DokBoxFilterShow(DataSet ds)
        {
            DokBoxFilterForm dialog = new DokBoxFilterForm(ds);
            dialog.ShowDialog();
        }

        private void DokBoxFilterForm_Load(object sender, EventArgs e)
        {
            SetFilter();
        }
        private void SetFilter()
        {
            this.ziarboxTableAdapter.Fill(this.mssDBDataSet.ziarbox);
            this.dokboxTableAdapter.Fill(this.mssDBDataSet.dokbox);
            this.kierboxTableAdapter.Fill(this.mssDBDataSet.kierbox);
            this.pojboxTableAdapter.Fill(this.mssDBDataSet.pojbox);
            this.naczboxTableAdapter.Fill(this.mssDBDataSet.naczbox);

            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = null;
            comboBox3.Text = null;
            comboBox4.Text = null;
            comboBox5.Text = null;
            comboBox6.Text = null;
            comboBox7.Text = null;
        }

        private void ComboBoxData()
        {
            comboBox1.DataSource = typyDokumentow;

            comboBox3.DataSource = this.mssDBDataSet.ziarbox;
            comboBox3.DisplayMember = "RZIARNA";
            comboBox3.ValueMember = "ID";

            comboBox4.DataSource = zbiorniki;

            comboBox5.DataSource = this.mssDBDataSet.kierbox;
            comboBox5.DisplayMember = "NAZWISKO";

            comboBox6.DataSource = this.mssDBDataSet.pojbox;
            comboBox6.DisplayMember = "NUMER";

            comboBox7.DataSource = this.mssDBDataSet.naczbox;
            comboBox7.DisplayMember = "NUMER";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filteredDataSet = Filter();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetFilter();
            Close();
        }

        private DataSet Filter ()
        {
            filteredDataSet.Clear();
            string connectionString = @"Data Source = MASTER\PIERWSZY;Initial Catalog = mssDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql = "SELECT * FROM xdokbox WHERE NRDOK LIKE '%" + textBox1.Text + "%' AND KONTRAHENT LIKE '%" + textBox2.Text + "%' AND TYP LIKE '%" + comboBox1.Text + "%' AND RZIARNA LIKE '%" + comboBox3.Text + "%' AND ZBIORNIK LIKE '%" + comboBox4.Text + "%' AND KIEROWCA LIKE '%" + comboBox5.Text + "%' AND POJAZD LIKE '%" + comboBox6.Text + "%' AND NACZEPA LIKE '%" + comboBox7.Text + "%'";// lub null
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(filteredDataSet, "xdokbox");
            connection.Close();
            return filteredDataSet;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetFilter();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KonBoxForm konbox = new KonBoxForm();
            KonBoxForm.KonBoxShow();
            var selected = konbox.GetSelected();
            textBox2.Text = selected[0];
        }
    }
}
