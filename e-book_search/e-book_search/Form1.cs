using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_book_search
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Database1Entities context = new Database1Entities();

            context.ebooks.Load();

            ebooksBindingSource.DataSource = context.ebooks.Local;

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
