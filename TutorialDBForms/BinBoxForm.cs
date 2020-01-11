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
    public partial class BinBoxForm : Form
    {
        private DataSet ds;
        private double[] masa = new double[DokBoxFilterForm.zbiorniki.Count];
        private double[] roznica = new double[DokBoxFilterForm.zbiorniki.Count];
        private double[] suma = new double[DokBoxFilterForm.zbiorniki.Count];
        private string[] typ = new string[DokBoxFilterForm.zbiorniki.Count];
        private double wilgotnosc, gluten, bialko, gestosc, zu, zn;
        private string zbiornik;
        private bool pobor;

        public BinBoxForm()
        {
            Sumuj();
            Typuj();
            InitializeComponent();
            ds = AppDataSet.setData("zbiorbox");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "zbiorbox";
        }
        public static void BinBoxShow()
        {
            BinBoxForm dialog = new BinBoxForm();
            dialog.ShowDialog();
        }

        private void BinBoxForm_Load(object sender, EventArgs e)
        {
            //Sumuj();
            //Typuj();
        }

        private void Sumuj()
        {
            for (int i = 1; i < DokBoxFilterForm.zbiorniki.Count; i++)
            {
                string connectionString = @"Data Source = MASTER\PIERWSZY;Initial Catalog = mssDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                string sql = "SELECT masa, typ, pobór, zbiornik, wilgotność, białko, gluten, gęstość, zu, zn FROM dokbox WHERE ZBIORNIK = '" + DokBoxFilterForm.zbiorniki[i] + "' OR POBÓR = '" + DokBoxFilterForm.zbiorniki[i] + "'";
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["masa"].ToString() != "")
                        {
                            if (dr["typ"].ToString().Equals("PM"))
                            {
                                masa[i] += Convert.ToDouble(dr["masa"]);
                            }
                            else if(dr["typ"].ToString().Equals("WM"))
                            {
                                roznica[i] += Convert.ToDouble(dr["masa"]);
                            }
                            else if(dr["typ"].ToString().Equals("MM") && (dr["POBÓR"].ToString().Equals(DokBoxFilterForm.zbiorniki[i])))
                            {
                                roznica[i] += Convert.ToDouble(dr["masa"]);
                            }
                            else if (dr["typ"].ToString().Equals("MM") && (dr["ZBIORNIK"].ToString().Equals(DokBoxFilterForm.zbiorniki[i])))
                            {
                                masa[i] += Convert.ToDouble(dr["masa"]);
                            }
                        }

                        if (dr["ZBIORNIK"].ToString() == DokBoxFilterForm.zbiorniki[i])
                        {
                            zbiornik = dr["ZBIORNIK"].ToString();
                        }
                        else
                        {
                            zbiornik = dr["POBÓR"].ToString();
                        }

                        if (dr["typ"].ToString().Equals("WM") || (dr["typ"].ToString().Equals("MM") && (dr["POBÓR"].ToString().Equals(DokBoxFilterForm.zbiorniki[i]))))
                        {
                            suma[i] = masa[i] - roznica[i];
                            pobor = true;
                        }
                        else
                        {
                            pobor = false;
                            if (dr["wilgotność"].ToString() != "")
                            {
                                wilgotnosc = ((wilgotnosc / 100) * suma[i]) + (Convert.ToDouble(dr["wilgotność"]) / 100) * Convert.ToDouble(dr["masa"]);
                            }
                            if (dr["białko"].ToString() != "")
                            {
                                bialko = ((bialko / 100) * suma[i]) + (Convert.ToDouble(dr["białko"]) / 100) * Convert.ToDouble(dr["masa"]);
                            }
                            if (dr["gluten"].ToString() != "")
                            {
                                gluten = ((gluten / 100) * suma[i]) + (Convert.ToDouble(dr["gluten"]) / 100) * Convert.ToDouble(dr["masa"]);
                            }
                            if (dr["gęstość"].ToString() != "")
                            {
                                gestosc = ((gestosc / 100) * suma[i]) + (Convert.ToDouble(dr["gęstość"]) / 100) * Convert.ToDouble(dr["masa"]);
                            }
                            if (dr["zn"].ToString() != "")
                            {
                                zn = ((zn / 100) * suma[i]) + (Convert.ToDouble(dr["zn"]) / 100) * Convert.ToDouble(dr["masa"]);
                            }
                            if (dr["zu"].ToString() != "")
                            {
                                zu = ((zu / 100) * suma[i]) + (Convert.ToDouble(dr["zu"]) / 100) * Convert.ToDouble(dr["masa"]);
                            }

                            suma[i] = masa[i] - roznica[i];
                        }
                        if (suma[i] != 0)
                        {
                            if (pobor) { }
                            else
                            {
                                wilgotnosc = Math.Round((wilgotnosc / suma[i] * 100), 4);
                                bialko = Math.Round((bialko / suma[i] * 100), 4);
                                gluten = Math.Round((gluten / suma[i] * 100), 4);
                                gestosc = Math.Round((gestosc / suma[i] * 100), 4);
                                zu = Math.Round((zu / suma[i] * 100), 4);
                                zn = Math.Round((zn / suma[i] * 100), 4);
                            }
                            sql = "UPDATE zbiorbox SET suma = '" + suma[i] + "', wilgotność = '" + wilgotnosc + "', białko = '" + bialko + "', gluten = '" + gluten + "', gęstość = '" + gestosc + "', zn = '" + zn + "', zu = '" + zu + "' WHERE ZBIORNIK = '" + zbiornik + "'";
                            connection.Open();
                            cmd = new SqlCommand(sql, connection);
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                        else
                        {
                            sql = "UPDATE zbiorbox SET suma = '" + suma[i] + "', wilgotność = null, białko = null, gluten = null, gęstość = null, zn = null, zu = null WHERE ZBIORNIK = '" + zbiornik + "'";
                            connection.Open();
                            cmd = new SqlCommand(sql, connection);
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                }
                wilgotnosc = 0;
                bialko = 0;
                gluten = 0;
                gestosc = 0;
                zn = 0;
                zu = 0;
            }
        }

        private void Typuj()
        {
            for (int i = 0; i < DokBoxFilterForm.zbiorniki.Count; i++)
            {
                string connectionString = @"Data Source = MASTER\PIERWSZY;Initial Catalog = mssDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                string sql = "SELECT TOP 1 ZIARID from dokbox where ZBIORNIK = '" + DokBoxFilterForm.zbiorniki[i] + "' ORDER BY DATA DESC";
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    connection.Open();
                    var c = cmd.ExecuteScalar();
                    if (c != null)
                    {
                        typ[i] = c.ToString();
                    }
                    sql = "UPDATE zbiorbox SET typ = '" + typ[i] + "' WHERE ZBIORNIK = '" + DokBoxFilterForm.zbiorniki[i] + "'";
                    cmd = new SqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
