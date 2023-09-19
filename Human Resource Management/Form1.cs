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
    public partial class client : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public client()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\DB.mdb;
Persist Security Info=False;";
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanel admin = new AdminPanel();
            admin.Show();
        }

        private void b1_Click(object sender, EventArgs e)
        {

            string query = string.Empty;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                query = "insert into client ([username], [fullname],[tel], [email],[adresse]) values ('" + username.Text + "' , '"+ full_name.Text + "' ,  '" + phone.Text + "' , '" +
                    email.Text +  "','"+adresse.Text+"')";

                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
                this.Close();
                client5 add = new client5();
                add.Show();

                MessageBox.Show("client added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
            }

        }

        private void client_FormClosed(object sender, FormClosedEventArgs e)
        {
            client5 emp = new client5();
            emp.Show();
        }
        private void client_Load(object sender, EventArgs e)
        {

        }
    }
}
