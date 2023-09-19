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
    public partial class AdminPanel : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public AdminPanel()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\DB.accdb;
Persist Security Info=False;";
        }

        private void AdminPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void open_employees() {
            this.Hide();
            Employees emp = new Employees();
            emp.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            open_employees();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            open_employees();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            int end_service = 0;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Employees where end_service <= NOW()";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    end_service++;
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
            }


            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select count(*) from Leaves where state='Waiting for admin'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int demands = Int32.Parse(reader[0].ToString());
                    int total_notifications = demands + end_service;
                    notifications.Text = "" + total_notifications;
                    if(notifications.Text == "0")
                    {
                        notifications.Visible = false;
                    }
                }
                else {
                    notifications.Visible = false;
                }
               

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
            }

            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            client notif = new client();
            notif.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            this.Hide();
            projet notif = new projet();
            notif.Show();
        }
    }
}
