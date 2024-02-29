using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagmentSystem
{
    public partial class Salaray : Form
    {
        public Salaray()
        {
            InitializeComponent();
        }
        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=DESKTOP-2SDCK3L\NEWINSTANCE;Initial Catalog=EMS;Integrated Security=True");

        int Dailybase;
        int Total;

        private void Fetchemp()
        {
            try
            {
                if (Eid.Text == "")
                {
                    MessageBox.Show("Enter Employee Id");
                }
                else
                {
                    Con.Open();
                    string Query = "select * from ETBL WHERE EmpId='" + Eid.Text + "'";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        En.Text = dr["EmpName"].ToString();
                        Ep.Text = dr["EmpPos"].ToString();
                    }
                    Con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

    

        private void viewbtn_Click(object sender, EventArgs e)
        {
            if (Ep.Text == "")
            {
                MessageBox.Show("Select An Employee");
            }
            else if (Wd.Text == "" || Convert.ToInt32(Wd.Text) > 28)
            {
                MessageBox.Show("Enter A Vaild Number Of Days");
            }
            else
            {
                if (Ep.Text == "Manager")
                {
                    Dailybase = 1200;
                }
                else if (Ep.Text == "Senior Devloper")
                {
                    Dailybase = 1000;
                }
                else if (Ep.Text == "Junior Devloper")
                {
                    Dailybase = 950;
                }
                else
                {
                    Dailybase = 850;
                }

                Total = Dailybase * Convert.ToInt32(Wd.Text);
                SS.Text = "Employee Id :" + Eid.Text + "\n" + "Employee Name : " + En.Text + "\n" + "Employee Position : " + Ep.Text + "\n" + "Daily Salary:" + Dailybase + "\n" + "Total Amount:" + Total ;
            }
        }

        private void Fetchbtn_Click(object sender, EventArgs e)
        {
            Fetchemp();
        }

        private void homebtn_Click_1(object sender, EventArgs e)
        {
            Home H = new Home();
            H.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ep_TextChanged(object sender, EventArgs e)
        {

        }

        private void Salaray_Load(object sender, EventArgs e)
        {

        }
    }
}

