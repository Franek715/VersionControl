using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
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
            inputFormatList.DataSource = a;
            inputFormatList.ClearSelected();


            String[] b = { "Title", "Author"};
            chooseAuthorList.DataSource = b;

        }


        private void addEbookButton_Click(object sender, EventArgs e)
        {
            String s = (String) inputFormatList.SelectedItem;
            Format i = Format.pdf;

            if(!(s.Length > 0 && inputTitle.Text.Length > 0 && inputAuthor.Text.Length > 0)) { MessageBox.Show("Valamelyik mező üres"); return; }

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
            addEbook(new Ebook(inputTitle.Text, inputAuthor.Text, i));

            inputTitle.Clear();
            inputAuthor.Clear();
            inputFormatList.ClearSelected();
        }


        private void searchButton_Click(object sender, EventArgs e)
        {
            getMatches();
        }


        public void addEbook(Ebook ebookP)
        {
            ebooks ebook = new ebooks();
            ebook.Title = ebookP.Title;
            ebook.Author = ebookP.Author;
            ebook.Format = (int)ebookP.Format;

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
            displayAllBooks.DataSource =
            (
                from s in context.ebooks
                select s
            ).ToList();

        }

        public void getMatches()
        {
            int matches;
            var allBooks = from x in context.ebooks select x;

            matches = 0;

            String keyword = inputSearch.Text; if (keyword.Length == 0) return;
            String searchIn = (String) chooseAuthorList.SelectedItem;
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
                    int index = 0;
                    bool noMatch;
                    String temp;
                    bool asterisk;

                    switch (searchIn)
                    {

                        case "Title":

                                noMatch = false;
                                temp = "";
                                asterisk = false;

                                for (int l = 0; l < keyword.Length; l++)
                                {
                                    String trimmed = x.Title.Substring(index).ToLower().Trim();
                                    index = 0;

                                    if (keyword[l] != '*') temp += keyword[l]; //actKeywords[j] = x.Title
                                    else
                                    {
                                        asterisk = true; //searchInput[k] = keyword
                                        if (trimmed.Contains(temp))
                                        {
                                            index = trimmed.ToLower().Trim().IndexOf(temp) + 1;
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
                            break;

                        case "Author":

                                noMatch = false;
                                temp = "";
                                asterisk = false;

                                for (int l = 0; l < keyword.Length; l++)
                                {
                                    
                                    String trimmed = x.Author.Substring(index).ToLower().Trim();
                                    index = 0;

                                if (keyword[l] != '*') temp += keyword[l]; //actKeywords[j] = x.Author
                                    else
                                    {
                                        asterisk = true; //searchInput[k] = keyword
                                        if (trimmed.Contains(temp))
                                        {
                                            index = trimmed.ToLower().Trim().IndexOf(temp) +1;
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
                            break;
                    }
                }
            }

            var output = from x in context.ebooks
                           where result.Contains(x.Id)
                           select x;

            displaySearchResult.DataSource = output.ToList();
            formatChart.DataSource = output.ToList();
            
            var pdfCount = from x in output
                              where x.Format.Equals(1)
                              select x;

            var epubCount = from x in output
                           where x.Format.Equals(2)
                           select x;

            var mobiCount = from x in output
                           where x.Format.Equals(3)
                           select x;

            

            var series = formatChart.Series[0];
            
            series.ChartType = SeriesChartType.Bar;
            series.Points.Clear();
            series.Points.AddXY("MOBI", (double)mobiCount.Count());
            series.Points.AddXY("EPUB", (double) epubCount.Count());
            series.Points.AddXY("PDF", (double)pdfCount.Count());
            series.BorderWidth = 2;
            

            var legend = formatChart.Legends[0];
            legend.Enabled = false;

           

        }
    }
}
