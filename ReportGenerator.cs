using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week_7
{
    internal class ReportGenerator
    {
        private Logger logger;
        private string reportPath = "weather_report.txt";

        public ReportGenerator()
        {
            logger = Logger.GetInstance();
        }

        public void GenerateReport(List<Book> books)
        {

            if (books.Count == 0)
            {
                logger.Log("No books available for report.");
                return;
            }
            Console.WriteLine("Book Report:");
            Console.WriteLine("------------");
            foreach (var book in books)
            {
                Console.WriteLine(book.ToString());

            }


            string summary = "=== Book Report ===\n" +
                             "Generated on: " + DateTime.Now.ToString("f") + "\n" +
                             "Total books: " + books.Count + "\n" +
                             "=====================\n";

            Console.WriteLine(summary);

            try
            {
                File.WriteAllText(reportPath, summary);
                logger.Log("Weather report saved to " + reportPath + ".");
            }
            catch (Exception ex)
            {
                logger.Log("Error writing report: " + ex.Message);
            }
        }
    }
}
