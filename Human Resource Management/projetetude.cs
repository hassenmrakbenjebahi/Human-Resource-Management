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
    public partial class projetetude : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public projetetude()
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
            var row = client_table.CurrentRow;
            if (row != null)
            {
                int id = (int)row.Cells[0].Value;
                int td;
                if (row.Cells[8].Value !=null)
                { 
                 td = (int)row.Cells[8].Value;
                }
                else {
                    td = 0; 
                }
                suietude notif = new suietude(id,td);
                this.Close();
                notif.Show();
            }
            else
            {
                MessageBox.Show("No client is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void projetetude_Load(object sender, EventArgs e)
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

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminPanel notif = new AdminPanel();
            notif.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            

        }




       

        private void button4_Click_1(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

