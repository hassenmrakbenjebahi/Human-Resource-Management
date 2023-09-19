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
using System.Configuration;

namespace Human_Resource_Management
{
    public partial class livraison : Form
    {
        int id;
        int td;
        OleDbConnection connection = new OleDbConnection();
        public livraison(int id,int td)
        {
            this.id = id;
            this.td = td;
            
            InitializeComponent();
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string path = config.AppSettings.Settings["ClientSettingsProvider.ServiceUri"].Value;
            if (path == "")
            {
                path = "DB.accdb";
            }
            if (!File.Exists(path))
            {
                path = "DB.accdb";
            }
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + @";
Persist Security Info=False;";
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminPanel add = new AdminPanel();
            add.Show();
        }

        private void livraison_Load(object sender, EventArgs e)
        {

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Settings where key='backgroundColor'";
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string color = (string)reader["value"];
                    this.BackColor = ColorTranslator.FromHtml(color);
                    close.BackColor = ColorTranslator.FromHtml(color);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }


            load_livraison();
        }


        public void load_livraison()
        {

            try
            {
                int b = td;
                int z = td;
                while (z > 0)
                {
                    string ch = "R+" + (b + 1 - z);
                    comboBox2.Items.Add(ch);
                    z--;
                    td--;
                }
                label1.Visible = false;
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Livraison where idprojet="+id;
                command.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                client_table.DataSource = dt;
                int x = 0;
                foreach (DataRow row in  dt.Rows)
                {
                    x++;

                }

                string a = x.ToString();
                label1.Text = a;
                connection.Close();



            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = string.Empty;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string m = id + comboBox2.Text;
                query = "insert into Livraison ([idprojet], [livraison],[idlivraison]) values ('" + id + "','" + comboBox2.Text + "' , '" + m + "' )";

                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
                int d = int.Parse(label1.Text);
                var count = comboBox2.Items.Count;
                if (d+1 == count)
                {
                    updateprojet(id);
                }
                else
                {
                    load_livraison();
                    MessageBox.Show("livraison added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                connection.Close();


            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }
        public void updateprojet(int id)
        {
            string query = string.Empty;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
               
                query = "update projet set [livraison1] = '"+ 1 + "'   where idproj = " + id;
                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
                
                
                MessageBox.Show("projet updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
            }

            this.Close();
            livraisonprojet add = new livraisonprojet();
            add.Show();
        }
    }
}
