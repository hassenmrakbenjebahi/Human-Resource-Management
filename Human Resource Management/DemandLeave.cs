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
    public partial class DemandLeave : Form
    {
        OleDbConnection connection = new OleDbConnection();
        int employee_id;
        public DemandLeave(int employee_id)
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\DB.accdb;
Persist Security Info=False;";
            this.employee_id = employee_id;
        }


        public void load_leaves() {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select cause, date, state from Leaves where id_employee = " + this.employee_id;
                command.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                leaves_table.DataSource = dt;

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void DemandLeave_Load(object sender, EventArgs e)
        {
            load_leaves();
        }

        private void close_Click(object sender, EventArgs e)
        {
            EmployeePanel panel = new EmployeePanel(employee_id);
            this.Close();
            panel.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void demand_leave_Click(object sender, EventArgs e)
        {
            NewLeave leave = new NewLeave(employee_id);
            this.Close();
            leave.Show();
        }
    }
}
