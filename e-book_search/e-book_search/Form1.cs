using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using e_book_search.Entities;

namespace e_book_search
{
    public partial class Form1 : SajatForm
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

        public void addEbook(Ebook ebookP)
        {
            //context.ebooks.SqlQuery("insert into ebook (title, author, format) values ('" + title + "', '" + author + "', '" + format + "'");

            ebooks ebook = new ebooks();
            ebook.Title = ebookP.Title;
            ebook.Author = ebookP.Author;
            ebook.Format = (int) ebookP.Format;
            context.ebooks.Local.Add(ebook);
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
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
            switch (s.Substring(0,s.IndexOf(' '))) {
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
            addEbook(new Ebook(textBox1.Text, textBox2.Text, i));

            textBox1.Clear();
            textBox2.Clear();
            listBox1.ClearSelected();
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

            String keyword = textBox3.Text; if (keyword.Length == 0) return;
            String searchIn = (String) listBox2.SelectedItem;
            HashSet<int> result = new HashSet<int>();


            if (!keyword.Contains("*"))
            {
                keyword = keyword.ToLower().Trim();
                foreach (var x in allBooks)
                {
                    String[] array;
                    switch (searchIn)
                    {
                        
                        case "Title":

                            array = x.Title.Split(' ');
                            for (int i = 0; i < array.Length; i++) array[i] = array[i].ToLower()
                                                                                        .Replace('(', ' ').Replace(')', ' ').Replace(',', ' ')
                                                                                        .Replace('.', ' ').Replace('!', ' ').Replace('?', ' ')
                                                                                        .Trim();
                            HashSet<String> title = array.ToHashSet();

                            if (title.Contains(keyword))
                            {
                                matches++;
                                result.Add(x.Id);
                            }
                            break;

                        case "Author":

                            array = x.Author.Split(' ');
                            for (int i = 0; i < array.Length; i++) array[i] = array[i]  .ToLower()
                                                                                        .Replace('(', ' ')  .Replace(')', ' ')  .Replace(',', ' ')
                                                                                        .Replace('.', ' ')  .Replace('!', ' ')  .Replace('?', ' ')
                                                                                        .Replace('#', ' ')  .Replace(':', ' ')
                                                                                        .Trim();
                            HashSet<String> author = array.ToHashSet();

                            if (author.Contains(keyword))
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
                    int index;
                    bool noMatch;
                    String temp;
                    bool asterisk;

                    switch (searchIn)
                    {

                        case "Title":
                            //for (int k = 0; k < keyword.Length; k++)
                            //{
                                index = 0;
                                noMatch = false;
                                temp = "";
                                asterisk = false;

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
                                if (!noMatch) { matches++; result.Add(x.Id); }
                            //}                           
                        break;

                        case "Author":
                            //for (int k = 0; k < keyword.Length; k++)
                            //{
                                index = 0;
                                noMatch = false;
                                temp = "";
                                asterisk = false;

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
                                if (!noMatch) { matches++; result.Add(x.Id); }
                            //}
                        break;
                    }
                }
            }

            var output = from x in context.ebooks
                           where result.Contains(x.Id)
                           select x;

            dataGridView2.DataSource = output.ToList();
            chart1.DataSource = output.ToList();
            
            var pdfCount = from x in output
                              where x.Format.Equals(1)
                              select x;

            var epubCount = from x in output
                           where x.Format.Equals(2)
                           select x;

            var mobiCount = from x in output
                           where x.Format.Equals(3)
                           select x;

            

            var series = chart1.Series[0];
            
            series.ChartType = SeriesChartType.Bar;
            series.Points.Clear();
            series.Points.AddXY ("PDF", (double) pdfCount.Count());
            series.Points.AddXY("EPUB", (double) epubCount.Count());
            series.Points.AddXY("MOBI", (double) mobiCount.Count());
            series.BorderWidth = 2;
            

            var legend = chart1.Legends[0];
            legend.Enabled = false;

           

        }
    }
}
