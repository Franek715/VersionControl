using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_book_search.Entities
{
    public class Ebook
    {
        public String Title { get; set; }
        public String Author { get; set; }
        public Format Format { get; set; }

        public Ebook(String title, String author, Format format)
        {
            Title = title;
            Author = author;
            Format = format;
        }

    }
    
}
