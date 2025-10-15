using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technika_dotnet
{
    public class Employee
    {
        private List<float> grades = new List<float>();
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public Employee()
        {
            this.Name = "Unknown";
            this.Surname = "Unknown";
        }

        public Employee(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                this.grades.Add(grade);
            }
            else
            {
                Console.WriteLine($"Invalid grade value: {grade}. Grade must be between 0 and 100.");
            }
        }

        public void AddGrade(string grade)
        {
            if (float.TryParse(grade, out float result))
            {
                AddGrade(result);
            }
            else if(char.TryParse(grade, out char letter) && grade.Length == 1)
            {
                switch (letter)
                {
                    case 'A':
                    case 'a':
                        AddGrade(100);
                        break;
                    case 'B':
                    case 'b':
                        AddGrade(80);
                        break;
                    case 'C':
                    case 'c':
                        AddGrade(60);
                        break;
                    case 'D':
                    case 'd':
                        AddGrade(40);
                        break;
                    case 'E':
                    case 'e':
                        AddGrade(20);
                        break;
                    case 'F':
                    case 'f':
                        AddGrade(0);
                        break;
                    default:
                        Console.WriteLine($"Invalid letter grade: {grade}. Please enter a letter from A to F.");
                        break;
                }
            }
            else
            {
                Console.WriteLine($"Invalid grade format: {grade}. Please enter a numeric value.");
            }
        }

        public Statistics GetStatistics()
        {
            var stats = new Statistics();
            stats.Min = 0f;
            stats.Max = 0f;
            stats.Average = 0f;
            stats.Letter = 'F';

            if (this.grades.Count == 0)
            {
                Console.WriteLine("No grades available to calculate statistics.");
                return stats;
            }
            stats.Min = this.grades.Min();
            stats.Max = this.grades.Max();
            stats.Average = this.grades.Average();

            switch (stats.Average)
            {
                case var d when d >= 81:
                    stats.Letter = 'A';
                    break;
                case var d when d >= 61:
                    stats.Letter = 'B';
                    break;
                case var d when d >= 41:
                    stats.Letter = 'C';
                    break;
                case var d when d >= 21:
                    stats.Letter = 'D';
                    break;
                case var d when d >= 1:
                    stats.Letter = 'E';
                    break;
                default:
                    stats.Letter = 'F';
                    break;
            }

            return stats;
        }
    }
}
