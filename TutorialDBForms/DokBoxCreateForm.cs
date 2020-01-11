using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TutorialDBForms.mssDBDataSetTableAdapters;

namespace TutorialDBForms
{
    public partial class DokBoxCreateForm : Form
    {
        public static List<string> typyDokumentow = new List<string>() { "PM", "MM", "WM" };

        private string comb3, comb4, comb5, comb6, comb7, comb8;

        public DokBoxCreateForm()
        {
            InitializeComponent();
            AppDataSet.setData("dokbox");
            ComboBoxData();
        }

        private void DokBoxCreateForm_Load(object sender, EventArgs e)
        {
            this.ziarboxTableAdapter.Fill(this.mssDBDataSet.ziarbox);
            this.dokboxTableAdapter.Fill(this.mssDBDataSet.dokbox);
            this.kierboxTableAdapter.Fill(this.mssDBDataSet.kierbox);
            this.pojboxTableAdapter.Fill(this.mssDBDataSet.pojbox);
            this.naczboxTableAdapter.Fill(this.mssDBDataSet.naczbox);
            comboBox1.Text = null;
            comboBox3.Text = null;
            comboBox4.Text = "";
            comboBox5.Text = null;
            comboBox6.Text = null;
            comboBox7.Text = null;
            comboBox8.Text = "";
        }

        public static void DokBoxCreateShow()
        {
            new DokBoxCreateForm().ShowDialog();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedValue == null)
                return;
            if (this.comboBox1.SelectedValue.Equals((object)"MM"))
            {
                this.comboBox4.Enabled = true;
                this.comboBox8.Enabled = true;
            }
            else if (this.comboBox1.SelectedValue.Equals((object)"PM"))
            {
                this.comboBox4.Text = "";
                this.comboBox4.Enabled = false;
                this.comboBox8.Enabled = true;
            }
            else if (this.comboBox1.SelectedValue.Equals((object)"WM"))
            {
                this.comboBox8.Text = "";
                this.comboBox4.Enabled = true;
                this.comboBox8.Enabled = false;
            }
        }

        private void ComboBoxData()
        {
            comboBox1.DataSource = DokBoxCreateForm.typyDokumentow;

            comboBox3.DisplayMember = "RZIARNA";
            comboBox3.ValueMember = "ID";
            comboBox3.DataSource = this.mssDBDataSet.ziarbox;

            comboBox4.DataSource = new List<string>() { "", "BIN1", "BIN2", "BIN3", "BIN4", "BIN5", "BIN6", "BIN7", "BIN8", "BIN9", "BIN10", "HALA1", "HALA2", "Z. ZAŁ" };
            comboBox4.Enabled = false;

            comboBox5.DisplayMember = "NAZWISKO";
            comboBox5.ValueMember = "XKEY";
            comboBox5.DataSource = this.mssDBDataSet.kierbox;

            comboBox6.DisplayMember = "NUMER";
            comboBox6.ValueMember = "XKEY";
            comboBox6.DataSource = this.mssDBDataSet.pojbox;

            comboBox7.DisplayMember = "NUMER";
            comboBox7.ValueMember = "XKEY";
            comboBox7.DataSource = this.mssDBDataSet.naczbox;

            comboBox8.DataSource = DokBoxFilterForm.zbiorniki;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("Należy obowiązkowo podać numer dokumentu");
            }
            else if (this.comboBox1.Text == "")
            {
                MessageBox.Show("Należy obowiązkowo podać typ dokumentu");
            }
            else
            {
                this.NullHandler();
                this.MMChecker(this.comboBox1.Text, this.comb4);
                if (!DokBoxCreateForm.Insert("dokbox", "NRDOK", "TYP", "ZIARID", "KONBOX_XKEY", "POBÓR", "ZBIORNIK", "MASA", "DATA", "KIERBOX_XKEY", "POJBOX_XKEY", "NACZBOX_XKEY", "WILGOTNOŚĆ", "BIAŁKO", "GLUTEN", "GĘSTOŚĆ", "ZU", "ZN", this.textBox1.Text, this.comboBox1.Text, this.comb3, Convert.ToInt32(this.comboBox2.ValueMember), this.comb4, this.comb8, this.textBox2.Text, this.dateTimePicker1.Value, Convert.ToInt32(this.comb5), Convert.ToInt32(this.comb6), Convert.ToInt32(this.comb7), this.textBox3.Text, this.textBox4.Text, this.textBox5.Text, this.textBox6.Text, this.textBox7.Text, this.textBox8.Text))
                    return;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static bool Insert(
          string tabela,
          string column1,
          string column2,
          string column3,
          string column4,
          string column5,
          string column6,
          string column7,
          string column8,
          string column9,
          string column10,
          string column11,
          string column12,
          string column13,
          string column14,
          string column15,
          string column16,
          string column17,
          string value1,
          string value2,
          string value3,
          int value4,
          string value5,
          string value6,
          string value7,
          DateTime value8,
          int value9,
          int value10,
          int value11,
          string value12,
          string value13,
          string value14,
          string value15,
          string value16,
          string value17)
        {
            SqlConnection connection = new SqlConnection("Data Source = MASTER\\PIERWSZY;Initial Catalog = mssDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            connection.Open();
            sqlDataAdapter.InsertCommand = new SqlCommand("INSERT INTO " + tabela + " (" + column1 + ", " + column2 + ", " + column3 + ", " + column4 + ", " + column5 + ", " + column6 + ", " + column7 + ", " + column8 + ", " + column9 + ", " + column10 + ", " + column11 + ", " + column12 + ", " + column13 + ", " + column14 + ", " + column15 + ", " + column16 + ", " + column17 + ") VALUES ('" + value1 + "', '" + value2 + "', '" + value3 + "', '" + (object)value4 + "', '" + value5 + "', '" + value6 + "', '" + value7 + "', '" + (object)value8 + "', '" + (object)value9 + "', '" + (object)value10 + "', '" + (object)value11 + "', '" + value12 + "', '" + value13 + "', '" + value14 + "', '" + value15 + "', '" + value16 + "', '" + value17 + "')", connection);
            try
            {
                sqlDataAdapter.InsertCommand.ExecuteNonQuery();
            }
            catch
            {
                int num = (int)MessageBox.Show("Jedno z pól zostało nieprawidłowo wypełnione.");
                connection.Close();
                return false;
            }
            connection.Close();
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KonBoxForm konBoxForm = new KonBoxForm();
            KonBoxForm.KonBoxShow();
            string[] selected = konBoxForm.GetSelected();
            this.comboBox2.Text = selected[0];
            this.comboBox2.ValueMember = selected[1];
        }

        private void NullHandler()
        {
            try
            {
                this.comb3 = this.comboBox3.SelectedValue.ToString();
            }
            catch
            {
                this.comb3 = "";
            }
            try
            {
                this.comb4 = this.comboBox4.Text;
            }
            catch
            {
                this.comb4 = "";
            }
            try
            {
                this.comb5 = this.comboBox5.SelectedValue.ToString();
            }
            catch
            {
                this.comb5 = "4";
            }
            try
            {
                this.comb6 = this.comboBox6.SelectedValue.ToString();
            }
            catch
            {
                this.comb6 = "4";
            }
            try
            {
                this.comb7 = this.comboBox7.SelectedValue.ToString();
            }
            catch
            {
                this.comb7 = "5";
            }
            try
            {
                this.comb8 = this.comboBox8.Text;
            }
            catch
            {
                this.comb8 = "";
            }
            if (this.comboBox2.ValueMember == "")
                this.comboBox2.ValueMember = "14";
            if (this.textBox2.Text == "")
                this.textBox2.Text = "0";
            if (this.textBox3.Text == "")
                this.textBox3.Text = "0";
            if (this.textBox4.Text == "")
                this.textBox4.Text = "0";
            if (this.textBox5.Text == "")
                this.textBox5.Text = "0";
            if (this.textBox6.Text == "")
                this.textBox6.Text = "0";
            if (this.textBox7.Text == "")
                this.textBox7.Text = "0";
            if (!(this.textBox8.Text == ""))
                return;
            this.textBox8.Text = "0";
        }

        private void MMChecker(string typ, string pobór)
        {
            if (!(typ == "MM"))
                return;
            string connectionString = "Data Source = MASTER\\PIERWSZY;Initial Catalog = mssDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string cmdText = "SELECT wilgotność, białko, gluten, gęstość, zu, zn FROM zbiorbox WHERE ZBIORNIK = '" + this.comb4 + "'";
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand(cmdText, connection));
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow row in (InternalDataCollectionBase)dataTable.Rows)
                {
                    this.textBox3.Text = row["wilgotność"].ToString().Replace(",", ".");
                    this.textBox4.Text = row["białko"].ToString().Replace(",", ".");
                    this.textBox5.Text = row["gluten"].ToString().Replace(",", ".");
                    this.textBox6.Text = row["gęstość"].ToString().Replace(",", ".");
                    this.textBox7.Text = row["zu"].ToString().Replace(",", ".");
                    this.textBox8.Text = row["zn"].ToString().Replace(",", ".");
                }
            }
        }

    }
}
