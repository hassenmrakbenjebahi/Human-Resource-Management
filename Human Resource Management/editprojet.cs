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
    public partial class editprojet : Form
    {

        int id;
        OleDbConnection connection = new OleDbConnection();
        public editprojet(int id)
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

        private void editprojet_Load(object sender, EventArgs e)
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
                query = "select * from projet where idproj = " + id;

                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var dat_v = reader["dat"];
                    var type_v = reader["type"];

                    var nomarch_v = reader["nomarch"];
                    var nomclient_v = reader["nomclient"];
                    
                    var surface_v = reader["surface"];
                    
                    var nblot_v = reader["nblot"];
                  
                    var prix_v = reader["prixtotale"];
                    var nbetage_v = reader["nbetage"];
                    dat.Text = "" + dat_v;

                    c1.Text = "" + nomarch_v;
                    c2.Text = "" + nomclient_v;

                    sur.Text = "" + surface_v;
                    nblot.Text = "" + nblot_v;
                  
                    prix.Text = "" + prix_v;
                    textBox1.Text = "" + nbetage_v;
                    var ch1 =""+ type_v ;
                    if (ch1 == "structure")
                    {
                        str.Checked = true;
                    }
                    else if (ch1 == "VRD")
                    {
                        vrd.Checked = true;
                    }
                    else { sec.Checked = true; }
                   
                }
                
               

                if (sur.Text == "0")
                {
                    sur.Visible = false;
                    label5.Visible = false;


                }
                else { nblot.Visible = false;
                    label6.Visible = false;
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
            projet1 add = new projet1();
            add.Show();

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
                string ch = "VRD";
                string query = string.Empty;
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;

                    query = "update projet set [dat] = '" + dat.Text + "', [nomarch] ='" +
                        c1.Text + "',[nomclient]= '" + c2.Text + "' , [type] ='" +
                        ch + "'," +
                        " [nblot] = '" + nblot.Text + "',[surface]='" + 0 + "',[prixtotale]='" + prix.Text + "',[nbetage]='" + textBox1.Text + "'   where idproj = " + id;
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    connection.Close();
                    this.Close();
                    projet1 add = new projet1();
                    add.Show();
                    MessageBox.Show("projet updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else if (sec.Checked && str.Checked)
            {
                string ch = "structure et securite";
                string query = string.Empty;
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;

                    query = "update projet set [dat] = '" + dat.Text + "', [nomarch] ='" +
                        c1.Text + "',[nomclient]= '" + c2.Text + "' , [type] ='" +
                        ch + "'," +
                        " [surface] = '" + sur.Text + "',[nblot]='" + 0 + "',[prixtotale]='" + prix.Text + "'    where idproj = " + id;
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    connection.Close();
                    this.Close();
                    projet1 add = new projet1();
                    add.Show();
                    MessageBox.Show("projet updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else if (sec.Checked)
            {
                string ch = " securite";
                string query = string.Empty;
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;

                    query = "update projet set [dat] = '" + dat.Text + "', [nomarch] ='" +
                        c1.Text + "',[nomclient]= '" + c2.Text + "' , [type] ='" +
                        ch + "'," +
                        " [surface] = '" + sur.Text + "',[nblot]='" + 0 + "',[prixtotale]='" + prix.Text + "'    where idproj = " + id;
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    connection.Close();
                    this.Close();
                    projet1 add = new projet1();
                    add.Show();
                    MessageBox.Show("projet updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                string ch = "structure";
                string query = string.Empty;
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;

                    query = "update projet set [dat] = '" + dat.Text + "', [nomarch] ='" +
                        c1.Text + "',[nomclient]= '" + c2.Text + "' , [type] ='" +
                        ch + "'," +
                        " [surface] = '" + sur.Text + "',[nblot]='" + 0 + "' ,[prixtotale]='" + prix.Text + "'   where idproj = " + id;
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    connection.Close();
                    this.Close();
                    projet1 add = new projet1();
                    add.Show();
                    MessageBox.Show("projet updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
