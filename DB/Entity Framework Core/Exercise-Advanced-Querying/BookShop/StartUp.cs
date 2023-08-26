using System.Text;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookShop
{
    using Data;
    using Initializer;
    using System.Linq;
    using System;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
        }


        // 02. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var currentAgeRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(b => b.AgeRestriction == currentAgeRestriction)
                .OrderBy(b => b.Title)
                .AsNoTracking()
                .ToArray();

            foreach (var book in books)
            {
                stringBuilder.AppendLine($"{book.Title}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        //03. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .AsNoTracking()
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        //04. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .AsNoTracking()
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        //05. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate!.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .AsNoTracking()
                .ToArray();

           return string.Join(Environment.NewLine, books);
        }
        //06. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] inputSplit = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var categoryId = context.Categories
                .Where(c => inputSplit.Contains(c.Name.ToLower()))
                .AsNoTracking()
                .Select(c => c.CategoryId)
                .ToArray();

            var books = context.BooksCategories
                .Where(bc => categoryId.Contains(bc.CategoryId))
                .Select(b => b.Book)
                .OrderBy(b => b.Title)
                .AsNoTracking()
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString().TrimEnd();
        }

        //07. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateConverted = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < dateConverted)
                .OrderByDescending(b => b.ReleaseDate)
                .AsNoTracking()
                .Select(b => new
                {
                    b.Title,
                    EditionType = b.EditionType.ToString(),
                    b.Price
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //08. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                })
                .OrderBy(a => a.FullName)
                .AsNoTracking()
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName}");
            }

            return sb.ToString().TrimEnd();
        }

        //09. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .AsNoTracking()
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        //10. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    FullName = b.Author.FirstName + " " + b.Author.LastName
                })
                .AsNoTracking()
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.FullName})");
            }

            return sb.ToString().TrimEnd();
        }

        //11. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .AsNoTracking()
                .ToArray();

            return books.Count();
        }

        //12. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var books = context.Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    Copies = a.Books.Sum(x => x.Copies)
                })
                .OrderByDescending(b => b.Copies)
                .AsNoTracking()
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var authorBook in books)
            {
                sb.AppendLine($"{authorBook.FullName} - {authorBook.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        //13. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var books = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .AsNoTracking()
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Name} ${book.Profit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //14. Profit by Category
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var books = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    Category = c.Name,
                    Books = c.CategoryBooks
                        .OrderByDescending(b => b.Book.ReleaseDate)
                        .Select(b => new
                        {
                            Title = b.Book.Title,
                            Year = b.Book.ReleaseDate.Value.Year
                        })
                        .Take(3)
                        .ToArray()
                })
                .AsNoTracking()
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var recentBook in books)
            {
                sb.AppendLine($"--{recentBook.Category}");

                foreach (var book in recentBook.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //15. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate!.Value.Year < 2010)
                .ToArray();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //16. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.RemoveRange(books);
            context.SaveChanges();

            return books.Length;
        }
    }
}