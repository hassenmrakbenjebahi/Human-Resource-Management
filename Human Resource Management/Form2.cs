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

namespace Human_Resource_Management
{
    public partial class projet : Form

    {
        
        OleDbConnection connection = new OleDbConnection();
        public projet()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:..\..\..\DB.mdb;
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
                string query = "select username,full_name from architecte";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                    c1.Items.Add(reader[0]+" "+reader[1]);
                   
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
                string dh;
                try
                {

                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;

                    ch = "VRD";
                    dh = "non";
                    query = "INSERT INTO projet([nomarch],[dat],[type],[nblot],[nomclient],[prixtotale],[nbetage],[livraison1])values('" + c1.Text + "','" + dat.Value + "','" + ch + "','" + nblot.Text + "','" + c2.Text + "','"+prix.Text+ "','" + textBox1.Text + "','"+dh+"')";
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
                    
                    query = "INSERT INTO projet([nomarch],[dat],[type],[surface],[nomclient],[prixtotale])values('" + c1.Text + "','" + dat.Value + "','" + ch + "','" + sur.Text + "','" + c2.Text + "','" + prix.Text + "')";
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
                   
                    query = "INSERT INTO projet([nomarch],[dat],[type],[surface],[nomclient],[prixtotale])values('" + c1.Text + "','" + dat.Value + "','" + ch + "','" + sur.Text + "','" + c2.Text + "','" + prix.Text + "')";
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
                    
                    query = "INSERT INTO projet([nomarch],[dat],[type],[surface],[nomclient],[prixtotale])values('" + c1.Text + "','" + dat.Value + "','" + ch + "','" + sur.Text + "','" + c2.Text + "','" + prix.Text + "')";
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
    }
}
