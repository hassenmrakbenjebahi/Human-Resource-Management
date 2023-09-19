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

namespace Human_Resource_Management
{
    public partial class EditEmployee : Form
    {
        int id;
        OleDbConnection connection = new OleDbConnection();
        public EditEmployee(int id)
        {
            InitializeComponent();
            this.id = id;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Gasri\Desktop\Application de gestion d'architect\DB.mdb;
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

        private void EditEmployee_Load(object sender, EventArgs e)
        {
           

            string query = string.Empty;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                query = "select * from architecte where id = " + id;

                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var username_v = reader["username"];
                    var rue_v = reader["rue"];
                    var full_name_v = reader["full_name"];
                    var phoneFix_v = reader["phoneFix"];
                    var Nbureau_v = reader["Nbureau"];
                    var phone_v = reader["phone"];
                    var email_v = reader["email"];
                    var localite_v = reader["localite"];
                    var codepostal_v = reader["codepostal"];
                    var ville_v = reader["ville"];

                    username.Text = ""+username_v;
                    rue.Text = "" + rue_v;
                    full_name.Text = "" + full_name_v;
                    phoneFix.Text = "" + phoneFix_v;
                    Nbureau.Text = "" + Nbureau_v;
                    phone.Text = "" + phone_v;
                    email.Text = "" + email_v;
                    localite.Text = "" + localite_v;
                    codepostal.Text = "" + codepostal_v;
                    ville.Text = "" + ville_v;
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
        }

        private void EditEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            Employees emp = new Employees();
            emp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = string.Empty;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                query = "update architecte set [username] = '" + username.Text + "', [localite] ='" + localite.Text + "', [full_name] ='" +
                    full_name.Text + "', [rue] = '" + rue.Text + "', [phoneFix] = " + phoneFix.Text + ", [phone]= '" + phone.Text + "' , [email] ='" +
                    email.Text + "'," +
                    " [Nbureau] = '" + Nbureau.Text + "', [codepostal] = " + codepostal.Text + ", [ville] = '" + ville.Text + "'   where id = " + id;
                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
                this.Close();
                MessageBox.Show("Employee updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
