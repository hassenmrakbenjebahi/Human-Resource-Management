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
    public partial class architect : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public architect()
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

        private void architect_Load(object sender, EventArgs e)
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


            loed_architect();
        }

        public void loed_architect()
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from architecte";
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddEmployee notif = new AddEmployee();
            notif.Show();
        }

        private void delete_Click(object sender, EventArgs e)
        {

            var row = client_table.CurrentRow;
            if (row != null)
            {
                var id = row.Cells[0].Value;
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this architecte?", "Delete confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        connection.Open();
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        string query = "delete from architecte where id = " + id;
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                        MessageBox.Show("architecte deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                        loed_architect();



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
                MessageBox.Show("No architecte is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            var row = client_table.CurrentRow;
            if (row != null)
            {
                int id = (int)row.Cells[0].Value;
                editarch notif = new editarch(id);
                this.Close();
                notif.Show();
            }
            else
            {
                MessageBox.Show("No client is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void client_table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminPanel notif = new AdminPanel();
            notif.Show();
        }
    }
}
