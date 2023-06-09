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

namespace simple_stock_management
{
    public partial class stock : Form
    {
        public stock()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string q = textBox2.Text;
            if (q != "")
            {
                string connectionString = "Data Source=127.0.0.1,3306;User=root;password=;database=stock_management;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string query ="insert into stock values('"+id+"','"+q+"')";
                MySqlCommand command = new MySqlCommand(query, connection);
                int n=command.ExecuteNonQuery();
                if (n == 0)
                {
                    MessageBox.Show("there's already a stock of that product");
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=127.0.0.1,3306;User=root;password=;database=stock_management;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "Select * from stock";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.Rows.Clear();
            foreach(DataRow row in data.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = row["id_prod"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = row["quantite"].ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text=dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string q = textBox2.Text;
            string connectionString = "Data Source=127.0.0.1,3306;User=root;password=;database=stock_management;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "update stock set quantite='"+q+"'where id_prod='"+id+"'";
            MySqlCommand command = new MySqlCommand(query, connection);
            int n = command.ExecuteNonQuery();
            if(n == 0)
            {
                MessageBox.Show("there is no product with this id");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string connectionString = "Data Source=127.0.0.1,3306;User=root;password=;database=stock_management;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "Select * from stock where id_prod='"+id+"'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.Rows.Clear();
            foreach (DataRow row in data.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = row["id_prod"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = row["quantite"].ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }
    }
}
