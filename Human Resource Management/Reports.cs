using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Human_Resource_Management
{
    public partial class Reports : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public Reports()
        {
            InitializeComponent();
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string path = config.AppSettings.Settings["ClientSettingsProvider.ServiceUri"].Value;
            if (path == "")
            {
                path = "DB.accdb";
            }
            if (!File.Exists(path))
            {
                path = "DB.accdb";
            }
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + @";
Persist Security Info=False;";
        }

        private void print_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Choose where do you want to store the file";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
                path = path + "//" + "Employees.pdf";
                string dir = Path.GetDirectoryName(path);
                string fileName = Path.GetFileNameWithoutExtension(path);
                string fileExt = Path.GetExtension(path);

                for (int i = 1; ; ++i)
                {
                    if (!File.Exists(path))
                        break;

                    path = Path.Combine(dir, fileName + "(" + i + ")" + fileExt);
                }
                Document document = new Document();
                document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                string time = DateTime.Now.ToString("ddMMyy HHmmss");
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
                document.Open();
                iTextSharp.text.Font font = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 10);

                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Employees2";
                command.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                connection.Close();

                PdfPTable table = new PdfPTable(dt.Columns.Count);
                float[] widths = new float[] { 1f, 4f, 4f, 4f, 4f, 4f, 4f, 5f, 4f, 4f, 4f };

                table.SetWidths(widths);

                table.WidthPercentage = 100;

                PdfPCell cell = new PdfPCell(new Phrase("Employees"));

                cell.Colspan = dt.Columns.Count;

                table.AddCell(cell);

                foreach (DataColumn c in dt.Columns)
                {
                    table.AddCell(new Phrase(c.ColumnName, font));
                }

                foreach (DataRow r in dt.Rows)
                {
                    if (dt.Rows.Count > 0)
                    {
                        table.AddCell(new Phrase(r[0].ToString(), font));
                        table.AddCell(new Phrase(r[1].ToString(), font));
                        table.AddCell(new Phrase(r[2].ToString(), font));
                        table.AddCell(new Phrase(r[3].ToString(), font));
                        table.AddCell(new Phrase(r[4].ToString(), font));
                        table.AddCell(new Phrase(r[5].ToString(), font));
                        table.AddCell(new Phrase(r[6].ToString(), font));
                        table.AddCell(new Phrase(r[7].ToString(), font));
                        table.AddCell(new Phrase(r[8].ToString(), font));
                        table.AddCell(new Phrase(r[9].ToString(), font));
                        table.AddCell(new Phrase(r[10].ToString(), font));
                    }
                }
                document.Add(table);
                document.Close();
                System.Diagnostics.Process.Start(path);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Choose where do you want to store the file";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
                path = path + "//" + "Leaves.pdf";
                string dir = Path.GetDirectoryName(path);
                string fileName = Path.GetFileNameWithoutExtension(path);
                string fileExt = Path.GetExtension(path);

                for (int i = 1; ; ++i)
                {
                    if (!File.Exists(path))
                        break;

                    path = Path.Combine(dir, fileName + "(" + i + ")" + fileExt);
                }
                Document document = new Document();
                document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
                document.Open();
                iTextSharp.text.Font font = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 10);

                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Leaves";
                command.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                connection.Close();

                PdfPTable table = new PdfPTable(dt.Columns.Count);
                float[] widths = new float[] { 1f, 4f, 4f, 4f, 4f};

                table.SetWidths(widths);

                table.WidthPercentage = 100;

                PdfPCell cell = new PdfPCell(new Phrase("Leaves"));

                cell.Colspan = dt.Columns.Count;

                table.AddCell(cell);

                foreach (DataColumn c in dt.Columns)
                {
                    table.AddCell(new Phrase(c.ColumnName, font));
                }

                foreach (DataRow r in dt.Rows)
                {
                    if (dt.Rows.Count > 0)
                    {
                        table.AddCell(new Phrase(r[0].ToString(), font));
                        table.AddCell(new Phrase(r[1].ToString(), font));
                        table.AddCell(new Phrase(r[2].ToString(), font));
                        table.AddCell(new Phrase(r[3].ToString(), font));
                        table.AddCell(new Phrase(r[4].ToString(), font));

                    }
                }
                document.Add(table);
                document.Close();
                System.Diagnostics.Process.Start(path);
            }
        }

        private void Reports_Load(object sender, EventArgs e)
        {

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Settings where key='backgroundColor'";
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string color = (string)reader["value"];
                    this.BackColor = ColorTranslator.FromHtml(color);
                  
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }



        }
    }
}
