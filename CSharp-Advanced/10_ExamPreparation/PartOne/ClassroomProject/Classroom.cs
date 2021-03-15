using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> data;


        public Classroom(int capacity)
        {
            Capacity = capacity;
            data = new List<Student>();
        }

        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }


        public string RegisterStudent(Student student)
        {
            if (data.Count < Capacity)
            {
                data.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }
        public string DismissStudent(string firstName, string lastName)
        {
            Student student = data.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            if (data.Contains(student))
            {
                data.Remove(student);
                return $"Dismissed student {firstName} {lastName}";

            }
            else
            {
                return "Student not found";
            }
        }
        public string GetSubjectInfo(string subject)
        {
            Student student = data.FirstOrDefault(s => s.Subject == subject);
            StringBuilder sb = new StringBuilder();
            if (student != null)
            {
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (var item in data.Where(s => s.Subject == subject))
                {

                    sb.AppendLine($"{item.FirstName} {item.LastName}");
                }
                return sb.ToString().Trim();//try trim
            }
            else
            {

                return "No students enrolled for the subject";
            }


        }

        public int GetStudentsCount()
        {
            return data.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = data.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            return student;
        }
    }
}
