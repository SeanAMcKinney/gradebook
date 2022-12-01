using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        private static void Main(string[] args)
        {
            var book = new DiskBook("Sean's Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named {book.Name}...");
            Console.WriteLine($"The lowest grede is {stats.Low:F2}.");
            Console.WriteLine($"The highest grade is {stats.High:F2}.");
            Console.WriteLine($"The average grade is {stats.Average:F2}.");
            System.Console.WriteLine($"Letter grade is {stats.Letter}.");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit.");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added.");
        }

    }
}