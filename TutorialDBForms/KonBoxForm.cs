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
    public partial class KonBoxForm : Form
    {
        private static string selectedKontrahent;
        private static string selectedXkey;
        public DataSet ds;
        public KonBoxForm()
        {
            InitializeComponent();
            ds = AppDataSet.setData("konbox");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "konbox";
        }

        public static void KonBoxShow()
        {
            KonBoxForm dialog = new KonBoxForm();
            dialog.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KonBoxCreateForm.KonBoxCreateShow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KonBoxFilterForm.KonBoxFilterShow(ds);
            ds = KonBoxFilterForm.filteredDataSet;
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "konbox";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectedKontrahent = dataGridView1.CurrentRow.Cells["NAZWA"].Value.ToString();
            selectedXkey = dataGridView1.CurrentRow.Cells["XKEY"].Value.ToString();
            Close();
        }
        public string[] GetSelected()
        {
            string[] selected = new string[2];
            selected[0] = selectedKontrahent;
            selected[1] = selectedXkey;
            return selected;
        }
    }
}
