using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberStudents = int.Parse(Console.ReadLine());

            Dictionary <string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < numberStudents; i++)
            {
                string[] student = Console.ReadLine().Split();
                string name = student[0];
                decimal grade = decimal.Parse(student[1]);

                if (!studentGrades.ContainsKey(name))
                {
                    studentGrades.Add(name,new List<decimal>());
                }
                
                    studentGrades[name].Add(grade);
                

            }
            foreach (var student in studentGrades)
            {
                //var studentName = stud.Key;
                //var studentGrade = stud.Value;
                //var average = studentGrade.Average();we give him the value

                Console.Write($"{student.Key} -> ");

                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }
        }
    }
}
