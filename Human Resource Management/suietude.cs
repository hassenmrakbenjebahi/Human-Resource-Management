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
    public partial class suietude : Form
    {
        int id, td;
        OleDbConnection connection = new OleDbConnection();
        public suietude(int id, int td)
        {
         
            this.id = id;
            this.td = td;
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

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminPanel notif = new AdminPanel();
            notif.Show();
        }

        private void suietude_Load(object sender, EventArgs e)
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


            loed_suietude();


        }
        public void loed_suietude()
        {

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                this.comboBox1.Items.Clear();

                string query = "select username,full_name from Concepteur";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    comboBox1.Items.Add(reader[0] + " " + reader[1]);

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
            }
            try
            {
                int z = td;

                while (z > 0)
                {
                    z--;
                    td--;
                    string ch = "R+" + (td + 1 - z);
                    comboBox2.Items.Add(ch);

                }

                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from etude where idprojet = " + id;
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

        private void button2_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Choose where do you want to store the file";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
                path = path + "//" + "Etude.pdf";
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
                string query = "select [idprojet],[suivietude],[concepteur] from etude where idprojet=" + id;
                command.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                connection.Close();

                PdfPTable table = new PdfPTable(dt.Columns.Count);
                float[] widths = new float[] { 4f, 8f, 8f };

                table.SetWidths(widths);

                table.WidthPercentage = 100;

                PdfPCell cell = new PdfPCell(new Phrase("Etude"));

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

                    }
                }
                document.Add(table);
                document.Close();
                System.Diagnostics.Process.Start(path);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {
            var row = client_table.CurrentRow;
            if (row != null)
            {
                var id = row.Cells[0].Value;
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this etude?", "Delete confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        connection.Open();
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        string query = "delete from etude where N° = " + id;
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                        MessageBox.Show("etude deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                        loed_suietude();



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

        private void client_table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            string query = string.Empty;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string ch = id + comboBox2.Text;
                query = "insert into etude ([idprojet], [suivietude],[Concepteur],[idsuietude]) values ('" + id + "','" + comboBox2.Text + "' , '" + comboBox1.Text + "','" + ch + "' )";
                string dh = comboBox2.Text;
                comboBox2.Items.Remove(dh);
                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
                loed_suietude();

                MessageBox.Show("etude added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
            }

        }
    }
}
