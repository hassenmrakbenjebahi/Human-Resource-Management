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
    public partial class NewLeave : Form
    {
        int employee_id;
        OleDbConnection connection = new OleDbConnection();
        public NewLeave(int employee_id)
        {
            InitializeComponent();
            this.employee_id = employee_id;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\DB.accdb;
Persist Security Info=False;";
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewLeave_Load(object sender, EventArgs e)
        {
            date.Format = DateTimePickerFormat.Custom;
            date.CustomFormat = "MM/dd/yyyy";
        }

        private void save_demand_Click(object sender, EventArgs e)
        {
            string query = string.Empty;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
              
                query = "insert into Leaves ([cause], [date], [state], [id_employee]) values ('"+cause.Text+"', '"+date.Text+"', 'Waiting for admin', "+employee_id+")";

                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
                this.Close();
                DemandLeave demand = new DemandLeave(employee_id);
                demand.Show();
                MessageBox.Show("Demand saved successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void NewLeave_FormClosing(object sender, FormClosingEventArgs e)
        {
            DemandLeave demand = new DemandLeave(employee_id);
            demand.Show();
        }
    }
}
