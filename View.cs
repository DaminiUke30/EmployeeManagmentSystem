using System;
using System.Collections;
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
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }
        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=DESKTOP-2SDCK3L\NEWINSTANCE;Initial Catalog=EMS;Integrated Security=True");
        
        private void Fetchemp()
        {
            try
            {
                Con.Open();

                string Query = "select * from ETBL WHERE EmpId='"+textBox1.Text+"'";
                SqlCommand cmd = new SqlCommand(Query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda= new SqlDataAdapter(cmd);    
                sda.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    label14.Text = dr["EmpId"].ToString();
                    label18.Text = dr["EmpName"].ToString();
                    label17.Text = dr["EmpGen"].ToString();
                    label16.Text = dr["EmpAdd"].ToString();
                    label15.Text = dr["EmpPos"].ToString();
                    label13.Text = dr["EmpDob"].ToString();
                    label12.Text = dr["EmpPhone"].ToString();
                    label11.Text = dr["EmpEdu"].ToString();
                    label14.Visible = true;
                    label18.Visible = true;
                    label17.Visible = true;
                    label16.Visible = true;
                    label15.Visible = true;
                    label13.Visible = true;
                    label12.Visible = true;
                    label11.Visible = true;

                }
                Con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
            }
        private void CrossBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home H = new Home();
            H.Show();
            this.Hide();
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            Fetchemp();
        }
    }
}
