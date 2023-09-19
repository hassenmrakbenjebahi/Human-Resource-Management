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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Human_Resource_Management
{
    public partial class Employees : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public Employees()
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
            this.Close();
            AddEmployee add = new AddEmployee();
            add.Show();
        }


        private void close_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanel admin = new AdminPanel();
            admin.Show();
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            load_employees();
        }

        public void load_employees() {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Employees2";
                command.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                employees_table.DataSource = dt;

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var row = employees_table.CurrentRow;
            if (row != null)
            {
                int id = (int)row.Cells[0].Value;
                EditEmployee edit = new EditEmployee(id);
                this.Close();
                edit.Show();
            }
            else {
                MessageBox.Show("No employee is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var row = employees_table.CurrentRow;
            if (row != null)
            {
                var id = row.Cells[0].Value;
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this employee?", "Delete confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        connection.Open();
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        string query = "delete from Employees2 where id = " + id;
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                        MessageBox.Show("Employee deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                        load_employees();
                    }
                    catch (Exception ex)
                    {
                        connection.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else {
                MessageBox.Show("No employee is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        private void print_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Choose where do you want to store the file";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
                path = path + "//" + "Employees.pdf";
                string dir = Path.GetDirectoryName(path);
                string fileName = Path.GetFileNameWithoutExtension(path);
                string fileExt = Path.GetExtension(path);

                for (int i = 1; ; ++i)
                {
                    if (!File.Exists(path))
                        break;

                    path = Path.Combine(dir, fileName + "(" + i + ")" + fileExt);
                }
                Document document = new Document();
                document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                string time = DateTime.Now.ToString("ddMMyy HHmmss");
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
                document.Open();
                iTextSharp.text.Font font = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 10);
                DataTable dt = (DataTable)employees_table.DataSource;
                PdfPTable table = new PdfPTable(dt.Columns.Count);
                float[] widths = new float[] { 1f, 4f, 4f, 4f, 4f, 4f, 4f, 5f, 4f, 4f, 4f };

                table.SetWidths(widths);

                table.WidthPercentage = 100;

                PdfPCell cell = new PdfPCell(new Phrase("Employees"));

                cell.Colspan = dt.Columns.Count;

                table.AddCell(cell);

                foreach (DataColumn c in dt.Columns)
                {
                    table.AddCell(new Phrase(c.ColumnName, font));
                }
                var row = employees_table.CurrentRow;
                var ind = 0;
                foreach (DataRow r in dt.Rows)
                {
                    if (dt.Rows.Count > 0)
                    {if(ind== row.Index) { 
                        table.AddCell(new Phrase(r[0].ToString(), font));
                        table.AddCell(new Phrase(r[1].ToString(), font));
                        table.AddCell(new Phrase(r[2].ToString(), font));
                        table.AddCell(new Phrase(r[3].ToString(), font));
                        table.AddCell(new Phrase(r[4].ToString(), font));
                        table.AddCell(new Phrase(r[5].ToString(), font));
                        table.AddCell(new Phrase(r[6].ToString(), font));
                        table.AddCell(new Phrase(r[7].ToString(), font));
                        table.AddCell(new Phrase(r[8].ToString(), font));
                        table.AddCell(new Phrase(r[9].ToString(), font));
                        table.AddCell(new Phrase(r[10].ToString(), font));
                        }
                    }
                    ind++;
                }
                document.Add(table);
                document.Close();
                System.Diagnostics.Process.Start(path);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var row = employees_table.CurrentRow;
            if (row != null)
            {
                int id = (int)row.Cells[0].Value;
                EmployeeLeaves leaves = new EmployeeLeaves(id);
                leaves.Show();
            }
            else
            {
                MessageBox.Show("No employee is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var row = employees_table.CurrentRow;
            if (row != null)
            {
                int id = (int)row.Cells[0].Value;
                RateEmployee rate = new RateEmployee(id);
                this.Close();
                rate.Show();
            }
            else
            {
                MessageBox.Show("No employee is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var row = employees_table.CurrentRow;
            if (row != null)
            {
                int id = (int)row.Cells[0].Value;
                EmployeePenalties penalties = new EmployeePenalties(id);
                this.Close();
                penalties.Show();
            }
            else
            {
                MessageBox.Show("No employee is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void employees_table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
