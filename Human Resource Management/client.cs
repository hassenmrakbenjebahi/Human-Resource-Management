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
    public partial class client5 : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public client5()
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

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Close();
            client add = new client();
            add.Show();
        }

       

        private void close_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanel admin = new AdminPanel();
            admin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void client5_Load(object sender, EventArgs e)
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


            load_client();
        }

        public void load_client()
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from client";
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
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this client?", "Delete confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        connection.Open();
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        string query = "delete from client where idclient = " + id;
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                        MessageBox.Show("client deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                        load_client();



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
                MessageBox.Show("No client is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            var row = client_table.CurrentRow;
            if (row != null)
            {
                int id = (int)row.Cells[0].Value;
                editclient notif = new editclient(id);
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
    }
}
