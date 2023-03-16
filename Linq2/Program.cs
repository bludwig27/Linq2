using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq2
{
    class Program
    {
        public class Student
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public int Age { get; set; }
            public string Major { get; set; }
            public double Tuition { get; set; }
        }
        public class StudentClubs
        {
            public int StudentID { get; set; }
            public string ClubName { get; set; }
        }
        public class StudentGPA
        {
            public int StudentID { get; set; }
            public double GPA { get; set; }
        }

        static void Main(string[] args)
        {
            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "Frank Furter", Age = 55, Major="Hospitality", Tuition=3500.00} ,
                new Student() { StudentID = 1, StudentName = "Gina Host", Age = 21, Major="Hospitality", Tuition=4500.00 } ,
                new Student() { StudentID = 2, StudentName = "Cookie Crumb",  Age = 21, Major="CIT", Tuition=2500.00 } ,
                new Student() { StudentID = 3, StudentName = "Ima Script",  Age = 48, Major="CIT", Tuition=5500.00 } ,
                new Student() { StudentID = 3, StudentName = "Cora Coder",  Age = 35, Major="CIT", Tuition=1500.00 } ,
                new Student() { StudentID = 4, StudentName = "Ura Goodchild" , Age = 40, Major="Marketing", Tuition=500.00} ,
                new Student() { StudentID = 5, StudentName = "Take Mewith" , Age = 29, Major="Aerospace Engineering", Tuition=5500.00 }
        };
            // Student GPA Collection
            IList<StudentGPA> studentGPAList = new List<StudentGPA>() {
                new StudentGPA() { StudentID = 1,  GPA=4.0} ,
                new StudentGPA() { StudentID = 2,  GPA=3.5} ,
                new StudentGPA() { StudentID = 3,  GPA=2.0 } ,
                new StudentGPA() { StudentID = 4,  GPA=1.5 } ,
                new StudentGPA() { StudentID = 5,  GPA=4.0 } ,
                new StudentGPA() { StudentID = 6,  GPA=2.5} ,
                new StudentGPA() { StudentID = 7,  GPA=1.0 }
            };
            // Club collection
            IList<StudentClubs> studentClubList = new List<StudentClubs>() {
            new StudentClubs() {StudentID=1, ClubName="Photography" },
            new StudentClubs() {StudentID=1, ClubName="Game" },
            new StudentClubs() {StudentID=2, ClubName="Game" },
            new StudentClubs() {StudentID=5, ClubName="Photography" },
            new StudentClubs() {StudentID=6, ClubName="Game" },
            new StudentClubs() {StudentID=7, ClubName="Photography" },
            new StudentClubs() {StudentID=3, ClubName="PTK" },
        };
            Console.WriteLine("Student IDs sorted by GPA:");
            var myLinq1 = studentGPAList.OrderBy(s => s.GPA);
            foreach(var m in myLinq1)
            {
                Console.WriteLine(m.StudentID);
            }
            Console.WriteLine();
            Console.WriteLine("Student ID's sorted and grouped by club:");
            var myLinq2 = studentClubList.OrderBy(s => s.ClubName).GroupBy(s=>s.ClubName);
            foreach(var m in myLinq2)
            {
                Console.WriteLine("Club: " + m.Key);
                foreach(StudentClubs s in m)
                {
                    Console.WriteLine(s.StudentID);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            var myLinq3 = studentGPAList.Count(s => s.GPA >= 2.5 && s.GPA <= 4.0);
            Console.WriteLine($"There are {myLinq3} students with a GPA between 2.5 and 4.0, inclusive.");
            Console.WriteLine();
            var myLinq4 = studentList.Average(s => s.Tuition);
            Console.WriteLine($"The average tuition for all students on the list is {myLinq4}");
            Console.WriteLine();
            Console.WriteLine($"Highest Tuition Student Info");
            var myLinq5 = studentList.Max(s => s.Tuition);
            foreach(Student m in studentList)
            {
                if (m.Tuition == myLinq5)
                Console.WriteLine($"Name: {m.StudentName} Major: {m.Major} Tuition: {m.Tuition}");
            }
            Console.WriteLine();
            Console.WriteLine("Joined student & GPA list:");
            var myLinq6 = studentList.Join(studentGPAList,
                student => student.StudentID,
                gpa => gpa.StudentID,
                (student, gpa) => new
                {
                    StudentName = student.StudentName,
                    Major = student.Major,
                    GPA = gpa.GPA
                });
            foreach(var m in myLinq6)
            {
                Console.WriteLine($"Name: { m.StudentName} Major: {m.Major} GPA: {m.GPA}");
            }
            Console.WriteLine();
            Console.WriteLine("Names of students in the Game club (joined lists again):");
            var myLinq7 = studentList.Join(studentClubList,
                student => student.StudentID,
                club => club.StudentID,
                (student, club) => new
                {
                    StudentName = student.StudentName,
                    Club = club.ClubName
                }).Where(c => c.Club.Equals("Game"));
            foreach(var m in myLinq7) { Console.WriteLine(m.StudentName); }
        }
    }
}