using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Week_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger logger = Logger.GetInstance();
            logger.Log("Book systemapplication started.");
            List<Book> books = new List<Book>
            {
                new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925, true),
                new Book("To Kill a Mockingbird", "Harper Lee", 1960, false),
                new Book("1984", "George Orwell", 1949, true),
                new Book("Pride and Prejudice", "Jane Austen", 1813, false)
            };

            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }

            string filePath = "books.json";
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    books = JsonSerializer.Deserialize<List<Book>>(json);
                    Console.WriteLine($"Loaded {books.Count} books from {filePath}.");
                    logger.Log("Loaded " + books.Count + " books from " + filePath + ".");
                }
                else
                {
                    Console.WriteLine("No existing data found. Starting fresh.");
                    logger.Log("No existing data found. Starting fresh.");

                }


            }
            catch (Exception ex)
            {
                logger.Log("Error loading data: " + ex.Message);
                Console.WriteLine($"Error saving books: {ex.Message}");
                books = new List<Book>();
            }

            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;
                string json = JsonSerializer.Serialize(books, options);
                File.WriteAllText(filePath, json);
                Console.WriteLine($"Saved {books.Count} books to {filePath}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving books: {ex.Message}");
            }
            logger.Log("Application finished.");
            ReportGenerator reportGenerator = new ReportGenerator();
            reportGenerator.GenerateReport(books);
            logger.Log("Application finished.");
        }
    }
}
