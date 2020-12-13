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
using e_book_search.Entities;

namespace e_book_search
{
    public partial class Form1 : Form
    {
    
        Database1Entities1 context = new Database1Entities1();
        public Form1()
        {
            InitializeComponent();


            context.ebooks.Load();

            ebooksBindingSource.DataSource = context.ebooks.Local;

            String[] a = { "pdf    (1)", "epub (2)", "mobi  (3)" };
            int[] b = { 1, 2, 3 };
            listBox1.DataSource = a;

            

            
        }

        public void addEbook(String title, String author, int format)
        {
            //context.ebooks.SqlQuery("insert into ebook (title, author, format) values ('" + title + "', '" + author + "', '" + format + "'");

            ebooks ebook = new ebooks();
            ebook.Title = title;
            ebook.Author = author;
            ebook.Format = format;
            context.ebooks.Local.Add(ebook);
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            GetEbooks();
        }

        private void GetEbooks()
        {
            dataGridView1.DataSource =
            (
                from s in context.ebooks
                select s
            ).ToList();
            
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

        private void button1_Click(object sender, EventArgs e)
        {
            String s = (String) listBox1.SelectedItem;
            Format i = Format.pdf;
            switch (s) {
                case "pdf": 
                    i = Format.pdf;
                    break;
                case "epub":
                    i = Format.epub;
                    break;
                case "mobi":
                    i = Format.mobi;
                    break;
            }
            addEbook(textBox1.Text, textBox2.Text, (int) i);
        }

        private void ebooksBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void ebooksBindingSource_CurrentChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
