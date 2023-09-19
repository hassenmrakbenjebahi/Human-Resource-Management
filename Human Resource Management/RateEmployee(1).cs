using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Human_Resource_Management
{
    public partial class RateEmployee : Form
    {
        int id;
        OleDbConnection connection = new OleDbConnection();
        public RateEmployee(int id)
        {
            InitializeComponent();
            this.id = id;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\DB.accdb;
Persist Security Info=False;";
        }

        private void submit_Click(object sender, EventArgs e)
        {
            int selected = 0;
            if (star_1.Checked == true) {
                selected = 1;
            }
            if (star_2.Checked == true)
            {
                selected = 2;
            }
            if (star_3.Checked == true)
            {
                selected = 3;
            }
            if (star_4.Checked == true)
            {
                selected = 4;
            }
            if (star_5.Checked == true)
            {
                selected = 5;
            }
            if (selected == 0)
            {
                MessageBox.Show("Please select the number of stars you want to give");
            }
            else {
                string query = string.Empty;
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    query = "insert into Ratings ([employee_id], [stars]) values ("+this.id+", "+selected+")";

                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    connection.Close();
                    this.Close();
                    MessageBox.Show("Rate saved successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void RateEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            Employees emp = new Employees();
            emp.Show();
        }
    }
}
