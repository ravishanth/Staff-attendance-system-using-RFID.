using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace windows_file_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

           
            }
        

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Attendance attendance = new Attendance();
            attendance.Show();


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1 != null && textBox2 != null)
            {
                try
                {
                    Connect obj = new Connect();
                    obj.conn.ConnectionString = obj.locate;
                    obj.conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT (*) FROM ADMIN_LOGIN where username = '" + textBox1.Text + "' and password ='" + textBox2.Text + "' ", obj.conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        this.Hide();
                        Main_Menu main = new Main_Menu();
                        main.Show();
                        MessageBox.Show("Successfull Login");


                    }
                    else
                    {
                        MessageBox.Show("Please enter correct details");
                    }
                    obj.conn.Close();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
    