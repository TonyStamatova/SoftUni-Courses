using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> list = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                Article article = new Article(input[0], input[1], input[2]);
                list.Add(article);
            }

            string criteria = Console.ReadLine();

            switch (criteria)
            {
                case "title":
                    list.Sort((x, y) => x.Title.CompareTo(y.Title));
                    break;
                case "content":
                    list.Sort((x, y) => x.Content.CompareTo(y.Content));
                    break;
                case "author":
                    list.Sort((x, y) => x.Author.CompareTo(y.Author));
                    break;
            }

            Console.WriteLine(string.Join(Environment.NewLine, list));
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
