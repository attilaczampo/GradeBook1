using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            // Special ocassion. 
            // This is what we call an implicit variable
            // that is always available inside of methods/ constructors.
            // You use it when you want to refer to the object
            // that is currently being operated on.
            Name = name;
        }

        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break ;
            
                case 'C':
                    AddGrade(70);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >=0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public Statistics GetStats()
        // This is a public method and its return type, that is type of Object. (Statistics)
        // Returns an object of type 'Statistics'.

        // We changed the method name to GetStats().
        // Instead of void, we need this method to return an OBJECT.
        // An OBJECT that has the following state associated with :
        // an Average, a High and Low.

        // We construct an object from a class definition.
        // We create the Statistics.cs class
        {
            var results = new Statistics();
            // In order to return an object of type 'Statistics', we'll construct an object of that type.
            // var results it's a new instance of Statistics.
            // results - holds a value, that is a reference to an object of type Statistics.

            results.Average = 0.0;
            results.High = double.MinValue;
            results.Low = double.MaxValue;

            //BEFORE
            //foreach (var grade in grades)
            //{
            //    results.Low = Math.Min(grade, results.Low);
            //    results.High = Math.Max(grade, results.High);
            //    results.Average += grade;
            //}
            //results.Average /= grades.Count;

            //return results;


            //AFTER
            for (var index = 0; index < grades.Count; index++)
            {
                results.Low = Math.Min(grades[index], results.Low);
                results.High = Math.Max(grades[index], results.High);
                results.Average += grades[index];

            }
            results.Average /= grades.Count;

            switch(results.Average)
            {
                case var d when d > 90.0:
                    results.Letter = 'A';
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case var d when d > 80.0:
                    results.Letter = 'B';
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case var d when d > 70.0:
                    results.Letter = 'C';
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case var d when d > 60.0:
                    results.Letter = 'D';
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                default:
                    results.Letter = 'F';
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }

            return results;
        }

        private List<double> grades;

        public string Name
        {
            get; 
            set;
        }
        
    }
}
