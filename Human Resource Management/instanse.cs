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
using System.Configuration;
using System.IO;

namespace Human_Resource_Management
{
    public partial class instanse : Form
    {
        int id;
        OleDbConnection connection = new OleDbConnection();
        public instanse(int id)
        {
            InitializeComponent();
            this.id = id;
          
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

        private void instanse_Load(object sender, EventArgs e)
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
            string query = string.Empty;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                query = "select *from projet where idproj = " + id;

                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var dat_v = reader["prixtotale"];

                    var nomarch_v = reader["prixpayer"];



                    label1.Text = "" + nomarch_v;
                    
                    label3.Text = "" + dat_v;



                }
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
            soldinst add = new soldinst();
            add.Show();
        }

        private void ok_Click(object sender, EventArgs e)
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


            string query = string.Empty;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                query = "update projet set [prixpayer]=[prixpayer]+'"+prix.Text+"'   where idproj = " + id;
                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
                this.Close();
                soldinst add = new soldinst();
                add.Show();
                MessageBox.Show("prix payer updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {

            string query = string.Empty;
            string ch;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                ch = "p";
                query = "update projet set [payer]='"+ ch+ "'   where idproj = " + id;
                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
                this.Close();
                soldinst add = new soldinst();
                add.Show();
                MessageBox.Show("prix payer  successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
