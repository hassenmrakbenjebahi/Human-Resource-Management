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
    public partial class Settings : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public Settings()
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                var c = colorDialog1.Color;
                string color = "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
                this.BackColor = ColorTranslator.FromHtml(color);
                close.BackColor = ColorTranslator.FromHtml(color);
                button1.BackColor = ColorTranslator.FromHtml(color);
                string query = string.Empty;
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;

                    query = "update Settings set [value] = '"+ color+ "' where [key]='backgroundColor'";
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Color changed successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Settings_Load(object sender, EventArgs e)
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
                    button1.BackColor = ColorTranslator.FromHtml(color);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Access 2007 (*.accdb)|*accdb";
            openFileDialog.Title = "Please select database";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string path = openFileDialog.FileName;
                config.AppSettings.Settings["ClientSettingsProvider.ServiceUri"].Value = path;
                config.Save(ConfigurationSaveMode.Modified);
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + @";
Persist Security Info=False;";

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
                        button1.BackColor = ColorTranslator.FromHtml(color);
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MessageBox.Show("Database imported successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string selectedPath = string.Empty;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Choose where do you want to store the database";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                selectedPath = fbd.SelectedPath;
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string path = config.AppSettings.Settings["ClientSettingsProvider.ServiceUri"].Value;
                selectedPath = selectedPath + "//" + "DB.accdb";
                File.Copy(path, selectedPath);
                MessageBox.Show("Database exported successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
