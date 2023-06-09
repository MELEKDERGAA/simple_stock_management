using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace simple_stock_management
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //
            string connectionString = "Data Source=127.0.0.1,3306;User=root;password=;database=stock_management;";
            string username = textBox1.Text;
            string password = textBox2.Text;
            MySqlConnection connection= new MySqlConnection(connectionString);
            connection.Open();
            MySqlDataReader reader;
            string query = "SELECT * FROM admin where username = '" + username + "'";
            MySqlCommand command=new MySqlCommand(query, connection);
            command.CommandTimeout = 60;
            reader=command.ExecuteReader();
            if (reader.HasRows)
            {
                this.Hide();
                mainpage mainpage = new mainpage();
                mainpage.Show();
            }
            
            
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
