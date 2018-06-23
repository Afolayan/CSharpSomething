using System;

namespace ConsoleApp1{
    internal class Program{
        private static void Main(string[] args){
            Console.WriteLine("Hello World!\nWelcome to the CGPA calculator app.");
            Console.Write("Input the number of courses registered: ");
            var correctCourseNumberValue = false;
            var numberOfCourses = 0;
            do{
                var courses = Console.ReadLine();

                try{
                    numberOfCourses = int.Parse(courses);
                    correctCourseNumberValue = true;
                }
                catch (FormatException e){
                    correctCourseNumberValue = false;
                }
            } while (!correctCourseNumberValue);

            var sumOfProducts = 0.0;
            var sumOfUnits = 0;
            if (numberOfCourses > 0){
                for (var count = 0; count < numberOfCourses; count++){
                    Console.Write("Input the score in course {0}: ", (count + 1));
                    var score = ScoreGrade(int.Parse(Console.ReadLine()));

                    Console.Write("Input the number of unit of course {0}: ", (count + 1));
                    var unit = int.Parse(Console.ReadLine());
                    sumOfUnits += unit;

                    sumOfProducts += score * unit;
                }

                var cgpa = sumOfProducts / sumOfUnits;

                Console.WriteLine("CGPA == " + cgpa.ToString("#.##"));
                Console.WriteLine("CGPA class == " + CgpaClass(cgpa));
            }

            if (!System.Diagnostics.Debugger.IsAttached) return;
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }

        static int ScoreGrade(int score){
            if (score <= 39) return 0;
            else if (score > 39 && score <= 45) return 1;
            else if (score > 45 && score <= 49) return 2;
            else if (score > 49 && score <= 59) return 3;
            else if (score > 59 && score <= 69) return 4;
            else if (score > 69 && score <= 100) return 5;
            else return 0;
        }

        static string CgpaClass(double cgpa){
            if (cgpa > 1.0 && cgpa <= 1.49) return "Pass";
            else if (cgpa > 1.5 && cgpa <= 2.49) return "Third Class";
            else if (cgpa > 2.5 && cgpa <= 3.49) return "Second Class Lower";
            else if (cgpa > 3.5 && cgpa <= 4.49) return "Second Class Upper";
            else if (cgpa > 4.5 && cgpa <= 5.00) return "First Class";
            else return "Not a graduate.";
        }
    }
}