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
using PdfSharp.Drawing;
using PdfSharp.Pdf;
namespace windows_file_10
{
    public partial class View_Attendance : Form
    {
        public View_Attendance()
        {
            InitializeComponent();
        }

        private void attendBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.attendBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.usersDbDataSet);

        }

        private void View_Attendance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'usersDbDataSet.attend' table. You can move, or remove it, as needed.
            this.attendTableAdapter.Fill(this.usersDbDataSet.attend);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\ravi\source\repos\windows_file_10\windows_file_10\UsersDb.mdf';Integrated Security=True";
            string commandString = "Select * from attend";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand sqlCommand = new SqlCommand(commandString, conn))
                {
                    sqlDataAdapter.SelectCommand = sqlCommand;
                    sqlDataAdapter.Fill(ds);
                    WriteToPdf(ds);
                }
            }
        }
    
    private void WriteToPdf(DataSet ds)
    {
        int yPoint = 0;
        PdfDocument pdf = new PdfDocument();
        string present = string.Empty;

        pdf.Info.Title = "Database to PDF";
        PdfPage pdfPage = pdf.AddPage();
        XGraphics graph = XGraphics.FromPdfPage(pdfPage);
        XFont font = new XFont("Verdana", 20, XFontStyle.Regular);

        yPoint = yPoint + 80;

        graph.DrawString("Card Number", font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

        graph.DrawString("Present/Absent", font, XBrushes.Black, new XRect(280, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

        graph.DrawString("      Date", font, XBrushes.Black, new XRect(420, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

        yPoint = yPoint + 40;

        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        {
            string cardNo = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            bool isPresent = (bool)ds.Tables[0].Rows[i].ItemArray[1];
            DateTime dt = (DateTime)ds.Tables[0].Rows[i].ItemArray[2];

            if (isPresent)
                present = "Present";

            if (!isPresent)
                present = "Absent";



            graph.DrawString(cardNo, font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            graph.DrawString(present, font, XBrushes.Black, new XRect(280, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            graph.DrawString(dt.ToShortDateString(), font, XBrushes.Black, new XRect(420, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

            yPoint = yPoint + 40;
        }

        string pdfFilename = "status_of_staff_report.pdf";
        pdf.Save(pdfFilename);

        MessageBox.Show("Report saved successfully");
    }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu main = new Main_Menu();
            main.Show();
        }
    }
}