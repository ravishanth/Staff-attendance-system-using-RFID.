using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace windows_file_10
{
    public partial class Attendance : Form
    {

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\ravi\source\repos\windows_file_10\windows_file_10\UsersDb.mdf';Integrated Security=True";
        public Attendance()
        {
            InitializeComponent();
            rfid_textBox.Enabled = false;
            serialPort1.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rfid_textBox.Text = serialPort1.ReadLine();
            bool isSuccess = false;
            if (rfid_textBox.Text != null)
            {
                string cardNo = rfid_textBox.Text.Replace(" ", "").TrimEnd();

                string Output = "";
                bool isPresent = false;
                string fullName = string.Empty;

                if (!string.IsNullOrEmpty(cardNo))
                {
                    isSuccess = InsertNewRecord(cardNo, true);
                }

                try
                {
                    if (isSuccess)
                    {
                        isPresent = GetAttendanceData(cardNo);
                        fullName = GetFirstnameLastname(cardNo);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString()); 
                }
                

                //sql = "SELECT COUNT (*) FROM registration where rfid_number='" + rfid_textBox.Text + "'";
                //   sql1 = "update attend set status ='"+"Present"+"' where dummy.dummy_rfid == registration.rfid_number";
                //   sql = "update registration set registration.rfid_number = attend.rfid_card From registration inner join attend on registration.rfid_number = attend.rfid_card"

                //   sql = "Select * FROM registration INNER JOIN attend ON registration.rfid_number = '" + rfid_textBox.Text + "'";

                if (isPresent && !String.IsNullOrEmpty(fullName))
                {
                    Output = " Attendance is marked for :" + fullName;
                }

                MessageBox.Show(Output);
            }
        }

        private bool InsertNewRecord(string cardNo, bool isPresent)
        {
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql = "Insert into attend(rfid_card,status,DateTime) values (@rfid_card,@status,@DateTime)";
            string first_name = string.Empty;
            string last_name = string.Empty;
            bool succeeded = false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sql,conn))
                {
                    sqlCommand.Parameters.AddWithValue("@rfid_card", cardNo);
                    sqlCommand.Parameters.AddWithValue("@status", isPresent);
                    sqlCommand.Parameters.AddWithValue("@DateTime", sqlFormattedDate);
                    sqlCommand.ExecuteNonQuery();
                    succeeded = true;
                }
                return succeeded;
            }
        }

        private string GetFirstnameLastname(string cardNo)
        {
            string first_name = "";
            string last_name = "";
            
            string commandString = "Select r.first_name, r.last_name From registration r join attend a on a.rfid_card LIKE r.rfid_number where rfid_number =" + "'" + cardNo + "'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand sqlCommand = new SqlCommand(commandString,conn))
                {
                    SqlDataReader datareader = sqlCommand.ExecuteReader();
                    while (datareader.Read())
                    {
                        first_name = datareader.GetString(0);
                        last_name = datareader.GetString(1);
                    }
                }
                return first_name + " " + last_name;
            }
        }

        private bool GetAttendanceData(string cardNo)
        {
            bool status = false;
            string commandString = "select status from attend where rfid_card = '" + cardNo + "'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand sqlCommand = new SqlCommand(commandString,conn))
                {
                    SqlDataReader datareader = sqlCommand.ExecuteReader();
                    while (datareader.Read())
                    {
                        status = datareader.GetBoolean(0);
                    }
                }
            }
            return status;
        }
        //    "select first_name, lastname from registration where rf_id="+rfid_card

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void registrationBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.registrationBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.usersDbDataSet);

        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'usersDbDataSet.registration' table. You can move, or remove it, as needed.
            this.registrationTableAdapter.Fill(this.usersDbDataSet.registration);

        }
    }
}
