using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_7
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public bool IsRead { get; set; }

        public Book(string title, string author, int year, bool isRead)
        {
            Title = title;
            Author = author;
            Year = year;
            IsRead = isRead;
        }
        public override string ToString()
        {
            return $"{Title} by {Author}, {Year} - {(IsRead ? "Read" : "Not Read")}";
        }
    }
}
