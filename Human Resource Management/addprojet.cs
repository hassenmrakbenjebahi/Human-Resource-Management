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
    public partial class projet : Form

    {
        
        OleDbConnection connection = new OleDbConnection();
        public projet()
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

        private void projet_Load(object sender, EventArgs e)
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


            load_addprojet();


        }
        public void load_addprojet()
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

                    c1.Items.Add(reader[0] + " " + reader[1]);

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
                string query = "select username,fullname from client";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    c2.Items.Add(reader[0] + " " + reader[1]);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
            }

        }

        private void c1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void str_CheckedChanged(object sender, EventArgs e)
        {
            label6.Visible = false;
            nblot.Visible = false;
            vrd.Checked = false;
            sur.Visible = true;
            label5.Visible = true;
           
        }

        private void sec_CheckedChanged(object sender, EventArgs e)
        {

            label6.Visible = false;
            nblot.Visible = false;
            vrd.Checked = false;
            sur.Visible = true;
            label5.Visible = true;
        }

        private void vrd_CheckedChanged(object sender, EventArgs e)
        {
            str.Checked = false;
            sec.Checked = false;
            sur.Visible = false;
            label5.Visible = false;
            label6.Visible = true;
            nblot.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            
            if (vrd.Checked)
            {
                string query = string.Empty;
                string ch;
                try
                {

                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;

                    ch = "VRD";
                    
                   
                        query = "INSERT INTO projet([nomarch],[dat],[type],[nblot],[nomclient],[prixtotale],[nbetage],[livraison1])values('" + c1.Text + "','" + dat.Value + "','" + ch + "','" + nblot.Text + "','" + c2.Text + "','" + prix.Text + "','" + textBox1.Text + "','"+0+"')";
                    
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    connection.Close();
                    this.Close();
                    projet1 add = new projet1();
                    add.Show();
                    MessageBox.Show("projet added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else if (sec.Checked && str.Checked)
            {
                string query = string.Empty;
                string ch;
                try
                {

                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;

                    ch = "securite et structure";
                    
                    query = "INSERT INTO projet([nomarch],[dat],[type],[surface],[nomclient],[prixtotale],[nbetage],[livraison1])values('" + c1.Text + "','" + dat.Value + "','" + ch + "','" + sur.Text + "','" + c2.Text + "','" + prix.Text + "','"+textBox1.Text+ "','" + 0 + "')";
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    connection.Close();
                    this.Close();
                    projet1 add = new projet1();
                    add.Show();
                    MessageBox.Show("projet added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else if (sec.Checked )
            {
                string query = string.Empty;
                string ch;
                try
                {

                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;

                    ch = "securite ";
                   
                    query = "INSERT INTO projet([nomarch],[dat],[type],[surface],[nomclient],[prixtotale],[nbetage],[livraison1])values('" + c1.Text + "','" + dat.Value + "','" + ch + "','" + sur.Text + "','" + c2.Text + "','" + prix.Text + "','" + textBox1.Text + "','" + 0 + "')";
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    connection.Close();
                    this.Close();
                    projet1 add = new projet1();
                    add.Show();
                    MessageBox.Show("projet added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else 
            {
                string query = string.Empty;
                string ch;
                try
                {

                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;

                    ch = "structure";
                    
                    query = "INSERT INTO projet([nomarch],[dat],[type],[surface],[nomclient],[prixtotale],[nbetage],[livraison1])values('" + c1.Text + "','" + dat.Value + "','" + ch + "','" + sur.Text + "','" + c2.Text + "','" + prix.Text + "','"+textBox1.Text+ "','" + 0 + "')";
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    connection.Close();
                    this.Close();
                    projet1 add = new projet1();
                    add.Show();
                    MessageBox.Show("projet added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void sur_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void nblot_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if(vrd.Checked)
            {
                string a;
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "select prixvrd from prix";
                    command.CommandText = query;
                    OleDbDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        var prix_v = reader["prixvrd"];
                        a = nblot.Text;
                        if (a != "")
                        {
                            prix.Text = "" + (Convert.ToInt32(prix_v) * Convert.ToInt32(a));
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error " + ex);
                }

            }
            else
            {
                string a;
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "select prixstruc from prix";
                    command.CommandText = query;
                    OleDbDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        var prix_v = reader["prixstruc"];
                        a = sur.Text;
                        prix.Text = "" + (Convert.ToInt32(prix_v) * Convert.ToInt32(a));
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error " + ex);
                }

            }

        }
    }
}
