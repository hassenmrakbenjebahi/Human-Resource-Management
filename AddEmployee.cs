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

        private void button3_Click(object sender, EventArgs e)
        {
            string query = string.Empty;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                query = "insert into Employees ([username], [password], [full_name], [salary], [identification_card], [phone], [email], [job_title], [hire_date]) values ('" + username.Text + "' , '" + password.Text + "' , '" + full_name.Text + "' , " + salary.Text + " , " + identification_card.Text + " , '" + phone.Text + "' , '" + email.Text + "' , '" + job_title.Text + "' , '" + hire_date.Text + "')";
                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
                this.Close();
                Employees emp = new Employees();
                emp.Show();
                MessageBox.Show("Employee added successfully");
            } catch(Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            hire_date.Format = DateTimePickerFormat.Custom;
            hire_date.CustomFormat = "MM/dd/yyyy";
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
    }
}
