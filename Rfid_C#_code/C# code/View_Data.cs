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
    public partial class View_Data : Form
    {
        public View_Data()
        {
            InitializeComponent();
        }

        private void registrationBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.registrationBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.usersDbDataSet);

        }

        private void View_Data_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'usersDbDataSet.registration' table. You can move, or remove it, as needed.
            this.registrationTableAdapter.Fill(this.usersDbDataSet.registration);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu main = new Main_Menu();
            main.Show();
        }

        private void registrationBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect obj = new Connect();


            obj.conn.ConnectionString = obj.locate;
            obj.conn.Open();
            registrationDataGridView.Refresh();
            obj.conn.Close();
        }
    }
}
