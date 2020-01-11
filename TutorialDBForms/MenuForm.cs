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
    public partial class MenuForm : Form
    {
        public DataSet ds;
        public MenuForm()
        {
            InitializeComponent();
            ds = AppDataSet.setData("xdokbox");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "xdokbox";
        }

        public static void MenuShow() 
        {
            MenuForm dialog = new MenuForm();
            dialog.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DokBoxForm.DokBoxShow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ZiarBoxCreateForm.ZiarBoxCreateShow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KonBoxForm.KonBoxShow();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KierBoxCreateForm.KierBoxCreateShow();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PojBoxCreateForm.PojBoxCreateShow();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NaczBoxCreateForm.NaczBoxCreateShow();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BinBoxForm.BinBoxShow();
        }
    }
}
