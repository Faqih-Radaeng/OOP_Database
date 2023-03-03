using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadperson();
        }

        private void loadperson()
        {
            String connectionString = "server=localhost;uid=root;database=persondb";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM personTable", conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String connectionString = "server=localhost;uid=root;database=persondb";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("INSERT INTO `persontable`(`firstName`, `lastName`) VALUES ('" + txtFirstname.Text + "', '" + txtLastname.Text + "');", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Add Success!");
            loadperson();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            String connectionString = "server=localhost;uid=root;database=persondb";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("DELETE FROM `persontable` WHERE (`id` = '" + txtDeleteId.Text + "');", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Delete Success!");
            loadperson();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String connectionString = "server=localhost;uid=root;database=persondb";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("UPDATE `persontable`SET`firstName` = '" + txtFirstname.Text + "',`lastName` = '" + txtLastname.Text + "'WHERE (`id` = '" + txtUpdateId.Text + "');", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Update Success!");
            loadperson();
        }
    }
}
