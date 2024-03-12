using System;

namespace LibraryProject
{
    public class Book
    {
        public int Index { get; set; }
        public string Title { get; set; }

        public Book(string title, int i)
        {
            Index = i;
            Title = title;
        }
    }
}