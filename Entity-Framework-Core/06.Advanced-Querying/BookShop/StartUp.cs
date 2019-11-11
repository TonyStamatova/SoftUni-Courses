namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                IncreasePrices(db);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction restriction = Enum.Parse<AgeRestriction>(command, true);

            List<string> books = context.Books
                .Where(b => b.AgeRestriction == restriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            List<string> books = context.Books
                    .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                    .OrderBy(b => b.BookId)
                    .Select(b => b.Title)
                    .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            List<string> books = context.Books
                    .Where(b => b.Price > 40)
                    .OrderByDescending(b => b.Price)
                    .Select(b => $"{b.Title} - ${b.Price:f2}")
                    .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            List<string> books = context.Books
                    .Where(b => b.ReleaseDate.Value.Year != year)
                    .OrderBy(b => b.BookId)
                    .Select(b => b.Title)
                    .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            HashSet<string> specifiedCategories = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.ToLower())
                .ToHashSet();

            List<string> titles = context
                .Books
                .Where(b => b.BookCategories.Any(bc => specifiedCategories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, titles);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime filterDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            List<string> books = context.Books
                    .Where(b => b.ReleaseDate < filterDate)
                    .OrderByDescending(b => b.ReleaseDate)
                    .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
                    .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            List<string> authors = context.Authors
                    .Where(a => a.FirstName.EndsWith(input))
                    .OrderBy(a => a.FirstName)
                    .ThenBy(a => a.LastName)
                    .Select(a => $"{a.FirstName} {a.LastName}")
                    .ToList();

            return string.Join(Environment.NewLine, authors);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string filterString = input.ToLower();
            List<string> titles = context.Books
                    .Where(a => a.Title
                        .ToLower()
                        .Contains(filterString))
                    .OrderBy(a => a.Title)
                    .Select(a => a.Title)
                    .ToList();

            return string.Join(Environment.NewLine, titles);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            List<string> books = context.Books
                    .Where(a => a
                        .Author
                        .LastName
                        .StartsWith(input, StringComparison.InvariantCultureIgnoreCase))
                    .OrderBy(a => a.BookId)
                    .Select(a => $"{a.Title} ({a.Author.FirstName} {a.Author.LastName})")
                    .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int filteredBooks = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return filteredBooks;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            List<string> copiesInfo = context.Authors
                .OrderByDescending(a => a.Books.Select(b => b.Copies).Sum())
                .Select(a => $"{a.FirstName} {a.LastName} - {a.Books.Select(b => b.Copies).Sum()}")
                .ToList();

            return string.Join(Environment.NewLine, copiesInfo);
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            List<string> profits = context.Categories
                .OrderByDescending(c => c.CategoryBooks
                    .Select(cb => cb.Book)
                    .Select(b => b.Copies * b.Price).Sum())
                .Select(c =>
                    $"{c.Name} ${c.CategoryBooks.Select(cb => cb.Book).Select(b => b.Copies * b.Price).Sum()}")
                .ToList();

            return string.Join(Environment.NewLine, profits);
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            List<string> profits = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => $"--{c.Name}"
                    + Environment.NewLine
                    + string.Join(
                        Environment.NewLine,
                        c.CategoryBooks
                            .OrderByDescending(cb => cb.Book.ReleaseDate)
                            .Select(cb => $"{ cb.Book.Title} ({cb.Book.ReleaseDate.Value.Year})")
                            .Take(3)))
                .ToList();

            return string.Join(Environment.NewLine, profits);
        }

        public static void IncreasePrices(BookShopContext context)
        {
            context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList()
                .ForEach(b => b.Price += 5);

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            List<Book> books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            int result = books.Count;

            context.RemoveRange(books);

            context.SaveChanges();

            return result;
        }
    }
}

