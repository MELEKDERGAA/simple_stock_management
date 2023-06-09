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
    public partial class mainpage : Form
    {
        private int childFormNumber = 0;

        public mainpage()
        {
            InitializeComponent();
        }

        private void mainpage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            addprod prod = new addprod();
            prod.MdiParent = this;
            prod.Show();
            

        }

        private void deleteProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteprod prod = new deleteprod();
            prod.MdiParent = this;
            prod.Show();
            
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stock stock= new stock();
            stock.MdiParent = this;
            stock.Show();
        }
    }
}
