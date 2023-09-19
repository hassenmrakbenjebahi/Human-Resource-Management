using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Configuration;

namespace Human_Resource_Management
{
    public partial class projet1 : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public projet1()
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            projet add = new projet();
            add.Show();
        }

        private void projet1_Load(object sender, EventArgs e)
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
                    close.BackColor = ColorTranslator.FromHtml(color);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }


            load_projet();
        }

        public void load_projet()
        {
            
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select username,full_name from architecte";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    arch.Items.Add(reader[0] + " " + reader[1]);

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
            }

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select [idproj],[dat],[nomarch],[nomclient],[type],[nblot],[surface],[prixtotale],[nbetage] from projet";
                command.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                client_table.DataSource = dt;

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            var row = client_table.CurrentRow;
            if (row != null)
            {
                var id = row.Cells[0].Value;
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this projet?", "Delete confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        connection.Open();
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        string query = "delete from projet where idproj = " + id;
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                        MessageBox.Show("projet deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                        load_projet();



                    }
                    catch (Exception ex)
                    {
                        connection.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("No projet is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminPanel add = new AdminPanel();
            add.Show();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            var row = client_table.CurrentRow;
            if (row != null)
            {
                int id = (int)row.Cells[0].Value;
                editprojet notif = new editprojet(id);
                this.Close();
                notif.Show();
            }
            else
            {
                MessageBox.Show("No client is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var row = client_table.CurrentRow;
            if (row != null)
            {
                int id = (int)row.Cells[0].Value;
                string path = string.Empty;
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Choose where do you want to store the file";

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    path = fbd.SelectedPath;
                    path = path + "//" + "projet.pdf";
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


                    iTextSharp.text.Font font = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 22);
                    iTextSharp.text.Font font2 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 22);
                    iTextSharp.text.Font font3 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 40, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
                    iTextSharp.text.Font fonttitre = iTextSharp.text.FontFactory.GetFont(FontFactory.TIMES_BOLD, 72, BaseColor.BLACK);

                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "select [idproj],[dat],[nomarch],[nomclient],[type],[nblot],[surface],[prixtotale],[nbetage] from projet where idproj=" + id;
                    command.CommandText = query;

                    OleDbDataAdapter da = new OleDbDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    connection.Close();

                    PdfPTable table = new PdfPTable(2);
                    float[] widths = new float[] { 4f, 4f };

                    table.SetWidths(widths);

                    table.WidthPercentage = 100;

                    PdfPCell cell = new PdfPCell(new Phrase("Information de Projet", font3));
                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.Colspan = dt.Columns.Count;

                    cell.BackgroundColor = BaseColor.GRAY;
                    cell.BorderWidth = 3;
                    cell.BorderColor = BaseColor.BLACK;
                    cell.Padding = 5;
                    table.AddCell(cell);


                    foreach (DataRow r in dt.Rows)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            Paragraph title = new Paragraph(" Projet N " + r[0].ToString(), fonttitre);


                            title.Alignment = Element.ALIGN_CENTER;
                            title.Font = FontFactory.GetFont("Arial", 32);
                            title.Add("\n\n\n");
                            document.Add(title);

                            table.AddCell(new Phrase("Date :", font2));

                            table.AddCell(new Phrase(r[1].ToString(), font));
                            table.AddCell(new Phrase("Nom d'architect :", font2));
                            table.AddCell(new Phrase(r[2].ToString(), font));
                            table.AddCell(new Phrase("Nom de client :", font2));
                            table.AddCell(new Phrase(r[3].ToString(), font));
                            table.AddCell(new Phrase("Type de projet :", font2));
                            table.AddCell(new Phrase(r[4].ToString(), font));
                            table.AddCell(new Phrase("Nombre lot :", font2));
                            table.AddCell(new Phrase(r[5].ToString(), font));
                            table.AddCell(new Phrase("Surface :", font2));
                            table.AddCell(new Phrase(r[6].ToString(), font));
                            table.AddCell(new Phrase("Nombre d'etage :", font2));
                            table.AddCell(new Phrase(r[8].ToString(), font));
                            table.AddCell(new Phrase("Prix total :", font2));
                            table.AddCell(new Phrase(r[7].ToString() + "Dt", font));

                        }
                    }
                    document.Add(table);
                    document.Close();
                    System.Diagnostics.Process.Start(path);
                }
            }


            else
            {
                MessageBox.Show("No client is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in client_table.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in client_table.Rows)
            {
                
                
                    DataRow dRow = dt.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dRow[cell.ColumnIndex] = cell.Value;
                    }
               
                DateTime oDate = Convert.ToDateTime(dRow[1].ToString());
                if ((oDate >= de.Value)&&(oDate<=a.Value))
                    { 
                    dt.Rows.Add(dRow);
                    }
            }
            client_table.DataSource = dt;


        }




        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in client_table.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in client_table.Rows)
            {


                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                if (dRow[2].ToString() == arch.Text)
                {
                    dt.Rows.Add(dRow);
                }
            }
            client_table.DataSource = dt;



        }
    }

 }
