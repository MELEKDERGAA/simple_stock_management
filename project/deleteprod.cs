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
using System.Xml.Linq;

namespace simple_stock_management
{
    public partial class deleteprod : Form
    {
        public deleteprod()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string connectionString = "Data Source=127.0.0.1,3306;User=root;password=;database=stock_management;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string query;
                if (dataGridView1.Rows[e.RowIndex].Cells[2].Value == "")
                {
                    query = "Delete from product where product.id_prod='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'";
                }
                else
                {
                    query = "Delete from prodcolor where prodcolor.id_prod='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'and prodcolor.color_name='"+ dataGridView1.Rows[e.RowIndex].Cells[2].Value+"'";
                }
                MySqlCommand command = new MySqlCommand(query, connection);
                int n=command.ExecuteNonQuery();
                if (n > 0)
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    button1_Click(sender, e);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string connectionString = "Data Source=127.0.0.1,3306;User=root;password=;database=stock_management;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query="Select prodcolor.color_name,product.nom_prod from product inner join prodcolor On product.id_prod='"+id+"'and product.id_prod=prodcolor.id_prod";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.Rows.Clear();
            int n;
            foreach (DataRow item in data.Rows)
            {
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = id;
                dataGridView1.Rows[n].Cells[1].Value = item["nom_prod"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["color_name"].ToString();
            }
                string query1 = "Select product.nom_prod from product  where product.id_prod='" + id + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(query1, connection);
                DataTable dat = new DataTable();
                adap.Fill(dat);
                if (dat.Rows.Count > 0)
                {
                    n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = id;
                    dataGridView1.Rows[n].Cells[1].Value = dat.Rows[0]["nom_prod"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = "";
                }
            
        }
    }
}
