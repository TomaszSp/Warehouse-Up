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
    public partial class DokBoxForm : Form
    {
        private DataSet ds;
        public DokBoxForm()
        {
            InitializeComponent();
            ds = AppDataSet.setData("xdokbox");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "xdokbox";
        }
        public DokBoxForm(DataSet ds)
        {
            InitializeComponent();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "xdokbox";
        }

        public void DokBoxShow(DokBoxForm dialog)
        {
            dialog.ShowDialog();
        }

        public static void DokBoxShow()
        {
            DokBoxForm dialog = new DokBoxForm();
            dialog.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DokBoxCreateForm.DokBoxCreateShow();
            ds = AppDataSet.setData("xdokbox");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "xdokbox";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DokBoxFilterForm.DokBoxFilterShow(ds);
            ds = DokBoxFilterForm.filteredDataSet;
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "xdokbox";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuForm.MenuShow();
            Close();
        }
    }

}
