using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data.Common;

namespace windows_file_10
{
    class Connect
    {
        public SqlConnection conn = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        // public SqlDataReader rd = new SqlDataReader();
        //  public SqlDataReader datareader;


   
        public string locate = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\ravi\source\repos\windows_file_10\windows_file_10\UsersDb.mdf';Integrated Security=True";
    }
}
