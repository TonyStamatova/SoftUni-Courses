namespace IteratorsAndComparators
{
    using System;
    using System.Collections.Generic;

    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors;
        }

        public string Title { get; set; }

        public int Year { get; set; }

        public IReadOnlyList<string> Authors { get; set; }

        public int CompareTo(Book other)
        {
            BookComparator comparator = new BookComparator();
            return comparator.Compare(this, other);
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
