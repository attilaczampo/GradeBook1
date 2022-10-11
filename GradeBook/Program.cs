﻿using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Science Book");

            // Challange: Instead of hard-coding, we want to add the grades from the console.
            // We need a loop so that we can enter as many grades as we want.
            // If entering the letter "Q" it will stop.

            //book.AddGrade(89.1);
            //book.AddGrade(90.5);
            //book.AddGrade(77.5);

            // ..
         
            while(true)
            {
                Console.WriteLine("Enter a grade or press 'Q' to quit");
                var input = Console.ReadLine();

                if(input == "Q")
                {
                    break;   
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("***********************************");
                }
               
            }

       
            var stats = book.GetStats();
  

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

            // var grades = new List<double>() {12.7, 10.3, 6.11, 4.1};
            // grades.Add(56.1);

            // var results = 0.0;
            // var highGrade = double.MinValue;
            // var lowGrade = double.MaxValue;

            // foreach(var number in grades)
            // {
            //     lowGrade = Math.Min( number, lowGrade);
            //     highGrade = Math.Max(number, highGrade);
            //     results += number;
            // }
            // results /= grades.Count;
            // Console.WriteLine($"The highest grade is {highGrade}");
            // Console.WriteLine($"The lowest grade is {lowGrade}");
            // Console.WriteLine($"The average grade is {results:N1}");

            Console.WriteLine("Better call Saul!");


        }
    }
}
