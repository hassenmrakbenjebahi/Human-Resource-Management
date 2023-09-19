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
    public partial class EmployeePenalties : Form
    {
        int id;
        OleDbConnection connection = new OleDbConnection();
        public EmployeePenalties(int id)
        {
            InitializeComponent();
            this.id = id;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\DB.accdb;
Persist Security Info=False;";
        }

        private void EmployeePenalties_Load(object sender, EventArgs e)
        {
            load_penalties();
        }

        void load_penalties() {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Penalties where employee_id = "+this.id;
                command.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                penalties_table.DataSource = dt;

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void EmployeePenalties_FormClosed(object sender, FormClosedEventArgs e)
        {
            Employees emp = new Employees();
            emp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewPenalty penalty = new NewPenalty(this.id);
            penalty.Show();
            this.Hide();
        }
    }
}
