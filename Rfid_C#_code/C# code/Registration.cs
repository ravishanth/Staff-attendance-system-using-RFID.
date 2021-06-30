using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Windows.Forms;
using System.Data.SqlClient;

namespace windows_file_10
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            rfid_textbox.Enabled = false;
            serialPort1.Open();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'usersDbDataSet.registration' table. You can move, or remove it, as needed.
            this.registrationTableAdapter.Fill(this.usersDbDataSet.registration);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            rfid_textbox.Text = serialPort1.ReadLine();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null && textBox4.Text != null && textBox5.Text != null && rfid_textbox.Text != null)
            {
                try
                {
                    string var1 = rfid_textbox.Text.Replace(" ", "").TrimEnd();
                    string var2 = textBox1.Text;
                    string var3 = textBox2.Text;
                    string var4 = textBox3.Text;
                    string var5 = textBox4.Text;
                    string var6 = textBox5.Text;
                    Image var7 = Image1.Image;

                    Connect obj = new Connect();


                    obj.conn.ConnectionString = obj.locate;
                    obj.conn.Open();
                    string insertuser = String.Format("Insert into registration values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", var1, var2, var3, var4, var5, var6,var7);
                      //"Insert into registration values('" + var1 + "', '" + var2 + "' ,'" + var3 + "', '" + var4 + "','" + var5 + "','" + var6 + "','" + var7 + "')";
                    obj.cmd.Connection = obj.conn;
                    obj.cmd.CommandText = insertuser;
                    obj.cmd.ExecuteNonQuery();
                    obj.conn.Close();
                    MessageBox.Show("user signup successfull");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }
            }

            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void registrationBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.registrationBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.usersDbDataSet);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.Jpg)|*.Jpg| PNG Files (*.Png)|*.Png| All Files(*.*)|*.*";
            dlg.Title = "Upload Picture";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                String picPath = dlg.FileName.ToString();
              //  picPath = @"C:\Users\ravi\source\repos\windows_file_10\windows_file_10\bin\Debug\users_photo";
                Image1.ImageLocation = picPath;
                
            }






        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu main = new Main_Menu();
            main.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            rfid_textbox.Text = String.Empty;
            Image1.Image = null;
            MessageBox.Show("You can add a new staff now");


        }
    }

}
