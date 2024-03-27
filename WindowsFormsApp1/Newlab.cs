using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseConnection
{
    public partial class Newlab : Form
    {
        private static string connString = "server=localhost;port=3306;user id = root;password=;database=classicmodels;charset=utf8;";
        MySqlConnection conn = new MySqlConnection(connString);
        MySqlDataAdapter adr;
        DataTable dt = new DataTable();
        public Newlab()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sqlCmd = "SELECT * FROM employees WHERE lastName = @lastName";
            adr = new MySqlDataAdapter(sqlCmd, conn);
            adr.SelectCommand.Parameters.AddWithValue("@lastName", "Bow");
            adr.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            DataTable updateDt = (DataTable)dataGridView1.DataSource;
            MySqlCommandBuilder sqlBuilder = new MySqlCommandBuilder(adr);
            adr.UpdateCommand = sqlBuilder.GetUpdateCommand();
            adr.Update(updateDt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {

                    conn.Open();
                    String sqlCmd = "Update employees SET email = EmailAddressAttribute; WHERE lastName = @lastName";

                    using (MySqlCommand cmd = new MySqlCommand(sqlCmd, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", "testing@email.com");
                        cmd.Parameters.AddWithValue("@lastName", "Bow");

                        int rowsAdded = cmd.ExecuteNonQuery();
                        if (rowsAdded > 0)
                            MessageBox.Show($"{rowsAdded}Row Inserted");
                        else
                            MessageBox.Show("No Row Inserted");

                    }
                }
                catch (Exception ex) {

                    MessageBox.Show("Error:" + ex.Message);
                }
            
            
            }
        }
    }
}
