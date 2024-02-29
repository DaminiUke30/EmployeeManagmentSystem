using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EmployeeManagmentSystem
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();

            DisplayEmp();
        }

        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=DESKTOP-2SDCK3L\NEWINSTANCE;Initial Catalog=EMS;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sda;
        private void DisplayEmp()
        {
            try
            {
                Con.Open();

                string Query = "select * from ETBL";

                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);

                SqlCommandBuilder builder = new SqlCommandBuilder(sda);

                var ds = new DataSet();

                sda.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

                Con.Close();
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
        private void CrossBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Homebtn_Click(object sender, EventArgs e)
        {
            Home H = new Home();
            H.Show();
            this.Hide();
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text== ""  || textBox2.Text== "" || textBox3.Text== "" || textBox4.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                   

                    string query = "insert into ETBL values ('"+ textBox1.Text +"','"+textBox2.Text + "','"+
                        comboBox1.SelectedItem.ToString() +"','" + textBox3.Text + "','"+ comboBox2.SelectedItem.ToString() + "','"+
                        dateTimePicker1.Value.Date+ "','" + textBox5.Text + "','" + comboBox3.SelectedItem.ToString() + "')";

                    SqlCommand cmd = new SqlCommand(query,Con);
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Entered Successfully");

                    DisplayEmp();

                 }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            DisplayEmp();
            loaddataGridView();
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text=="")
                {
                    MessageBox.Show("Enter the Employee Id");
                }
                else
                {
                    Con.Open();
                    string query ="delete from ETBL WHERE EmpId='"+textBox1.Text+"';";
                    SqlCommand command = new SqlCommand(query,Con);
                    command.ExecuteNonQuery();
                    Con.Close() ;
                    MessageBox.Show("Record Delete Successfully");
                    DisplayEmp() ;  

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

        private void Resetbtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
            comboBox2.Text = "";
            textBox5.Text = "";
            comboBox3.Text = "";




        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();

                    string query = "update ETBL set EmpId ='" + textBox1.Text + "', EmpName '" + textBox2.Text + "', EmpPos" + comboBox1.SelectedItem.ToString() + "', EmpAdd'" + textBox3.Text + "', EmpPos '" + comboBox2.SelectedItem.ToString() + "' , EmpDob  " + dateTimePicker1.Value.Date + "' , EmpPhone'" + textBox5.Text + "', EmpEdu  '" + comboBox3.SelectedItem.ToString() + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    //Con.Close();
                    MessageBox.Show("Record Update Successfully");

                    DisplayEmp();
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

        public void loaddataGridView()
        {
          string Query  = "select * from ETBL";
           sda = new SqlDataAdapter(Query, Con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource= ds.Tables[0];
         
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

        }
    }

}
