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
            listBox1.DataSource = a;

            String[] b = { "Title", "Author"};
            listBox2.DataSource = b;

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
            getMatches();
        }

        public void getMatches()
        {
            int matches;
            var allBooks = from x in context.ebooks select x;

            matches = 0;

            String keyword = textBox3.Text;
            String searchIn = (String) listBox2.SelectedItem;
            HashSet<int> result = new HashSet<int>();


            if (!keyword.Contains("*"))
            {
                foreach (var x in allBooks)
                {
                    switch ((String)listBox2.SelectedItem)
                    {
                        case "Title":
                            if (x.Title.Contains(keyword.ToLower().Trim()))
                            {
                                matches++;
                                result.Add(x.Id);
                            }
                            break;

                        case "Author":
                            if (x.Author.Contains(keyword.ToLower().Trim()))
                            {
                                matches++;
                                result.Add(x.Id);
                            }
                            break;
                    }
                }

            }

            else
            {
                foreach (var x in allBooks)
                {
                    switch ((String)listBox2.SelectedItem)
                    {
                        case "Title":
                            for (int k = 0; k < keyword.Length; k++)
                            {
                                int index = 0;
                                bool noMatch = false;
                                String temp = "";
                                bool asterisk = false;

                                for (int l = 0; l < keyword.Length; l++)
                                {
                                    String trimmed = x.Title.Substring(index, x.Title.Length).ToLower().Trim();
                                    if (keyword[l] != '*') temp += keyword[l]; //actKeywords[j] = x.Title
                                    else
                                    {
                                        asterisk = true; //searchInput[k] = keyword
                                        if (trimmed.Contains(temp))
                                        {
                                            index = x.Title.IndexOf(temp);
                                            temp = "";
                                        }
                                        else
                                        {
                                            noMatch = true;
                                            break;
                                        }

                                    }

                                    if (l == keyword.Length - 1)
                                    {
                                        if (!trimmed.Substring(trimmed.Length - temp.Length).Equals(temp))
                                        {
                                            noMatch = true;
                                            break;
                                        }
                                    }
                                    else if (asterisk)
                                    {
                                        if (temp.Length > 0 && !trimmed.Substring(index).Contains(temp))
                                        {
                                            noMatch = true;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (temp.Length > 0 && !trimmed.Substring(index, index + temp.Length).Contains(temp))
                                        {
                                            noMatch = true;
                                            break;
                                        }
                                    }
                                }
                                if (!noMatch) matches++;
                                result.Add(x.Id);
                            }                           
                        break;

                        case "Author":
                            for (int k = 0; k < keyword.Length; k++)
                            {
                                int index = 0;
                                bool noMatch = false;
                                String temp = "";
                                bool asterisk = false;

                                for (int l = 0; l < keyword.Length; l++)
                                {
                                    String trimmed = x.Author.Substring(index, x.Author.Length).ToLower().Trim();
                                    if (keyword[l] != '*') temp += keyword[l]; //actKeywords[j] = x.Author
                                    else
                                    {
                                        asterisk = true; //searchInput[k] = keyword
                                        if (trimmed.Contains(temp))
                                        {
                                            index = x.Author.IndexOf(temp);
                                            temp = "";
                                        }
                                        else
                                        {
                                            noMatch = true;
                                            break;
                                        }

                                    }

                                    if (l == keyword.Length - 1)
                                    {
                                        if (!trimmed.Substring(trimmed.Length - temp.Length).Equals(temp))
                                        {
                                            noMatch = true;
                                            break;
                                        }
                                    }
                                    else if (asterisk)
                                    {
                                        if (temp.Length > 0 && !trimmed.Substring(index).Contains(temp))
                                        {
                                            noMatch = true;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (temp.Length > 0 && !trimmed.Substring(index, index + temp.Length).Contains(temp))
                                        {
                                            noMatch = true;
                                            break;
                                        }
                                    }
                                }
                                if (!noMatch) matches++;
                                result.Add(x.Id);
                            }
                        break;
                    }
                }
            }

            var output = from x in context.ebooks
                           where result.Contains(x.Id)
                           select x;

            dataGridView2.DataSource = output.ToList();
            
        }

    }
}
