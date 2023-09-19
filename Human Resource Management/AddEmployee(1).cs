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
    public partial class AddEmployee : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public AddEmployee()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\DB.accdb;
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
            string query = string.Empty;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                query = "insert into Employees2 ([username], [localite], [full_name], [rue], [phoneFix], [phone], [email]," +
                    " [Nbureau], [codepostal], [ville]) values ('" + username.Text + "' , '" + localite.Text + "' , '" +
                    full_name.Text + "' , '" + rue.Text + "' , " + phoneFix.Text + " , '" + phone.Text + "' , '" +
                    email.Text + "' , '" + Nbureau.Text + "' , " + codepostal.Text + " , '" + ville.Text +  "')";

                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
                this.Close();
                MessageBox.Show("Employee added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch(Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
            }
        }

       

        private void AddEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            Employees emp = new Employees();
            emp.Show();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
