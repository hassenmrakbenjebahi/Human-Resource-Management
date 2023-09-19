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
    public partial class NewPenalty : Form
    {
        int id;
        OleDbConnection connection = new OleDbConnection();
        public NewPenalty(int id)
        {
            InitializeComponent();
            this.id = id;
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
                query = "insert into Penalties ([employee_id], [value]) values ("+this.id+", "+textBox1.Text+")";

                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
                this.Close();
                MessageBox.Show("Penaltiy added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void NewPenalty_FormClosed(object sender, FormClosedEventArgs e)
        {
            EmployeePenalties penalties = new EmployeePenalties(this.id);
            penalties.Show();
        }
    }
}
