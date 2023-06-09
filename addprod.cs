using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simple_stock_management
{
    public partial class addprod : Form
    {
        public addprod()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox1.Image = new Bitmap(open.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            pictureBox1.Image=null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=127.0.0.1,3306;User=root;password=;database=stock_management;";
            string id =textBox4.Text;
            string name = textBox2.Text;
            string categorie = textBox3.Text;
            byte[] imageData;
            Image image = pictureBox1.Image;
            using(MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

                imageData = memoryStream.ToArray();
            }
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "Insert into product (id_prod,nom_prod,categorie,image_prod) values('"+id+"','"+name+"','"+categorie+"','"+imageData+"')";
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = query;
            int reader = command.ExecuteNonQuery();
            if (reader > 0)
            {
                
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        
    }

}
