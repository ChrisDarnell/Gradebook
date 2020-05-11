using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Chris' Gradebook of Dark Magic");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();


            Console.WriteLine($"For the GradeBook named {book.Name}:");
            Console.WriteLine($"The average grade is {stats.Average:N3}.");
            Console.WriteLine($"The highest grade is {stats.High:N3}.");
            Console.WriteLine($"The lowest grade is {stats.Low:N3}.");
            Console.WriteLine($"The letter grade is {stats.Letter}.");
        }


        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit: ");
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
            Console.WriteLine("The grade was added.");
        }
    }
}
