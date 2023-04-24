using LinqLabb.Data;
using LinqLabb.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace LinqLabb
{
    internal class Program
    {
        static void Main(string[] args)
        {


            DbCon db = new DbCon();

            bool MenuActive = true;

            while (MenuActive == true)
            {
                Console.WriteLine("Labb2 Menu:\n1. Math Teacher\n2. " +
                "TeacherwithStudents\n3. Subject Contains\n4. Edit Subject" +
                "\n5. Change Teacher\n6. Exit");
                string MenuChoice = Console.ReadLine();


                switch (MenuChoice)
                {

                    case "1":
                        SubjectTeacher(db);
                        break;
                    case "2":
                        TeacherStudent(db);
                        break;
                    case "3":
                        Contain(db);
                        break;
                    case "4":
                        EditSubject(db);
                        break;
                    case "5":
                        ChangeTeacher(db);
                        break;
                    case "6":
                        MenuActive = false;
                        break;
                    default:
                        Console.WriteLine("Choose between 1-4");
                        break;
                }
            }

        }

        public static void SubjectTeacher(DbCon db)
        {
            Console.Clear();

            Console.WriteLine($"Math Teacher: \n");
            var mathTeachers = db.Teachers.Where(t => t.Subjects.Any(s => s.SubjectName == "Math"));

            foreach (var item in mathTeachers)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
            Console.Clear();

        }


        public static void TeacherStudent(DbCon db)
        {
            Console.Clear();
            Console.WriteLine("Teacher and Student\n");

            for (int courseId = 1; courseId <= 2; courseId++)
            {
                var tea = db.Courses
                                   .Include(c => c.Students)
                                   .Include(c => c.Teachers)
                                   .FirstOrDefault(c => c.ID == courseId);

                if (tea != null)
                {
                    Console.WriteLine($"Course Name: {tea.CourseName}\n");

                    Console.WriteLine("Teachers:");
                    foreach (var teacher in tea.Teachers)
                    {
                        Console.WriteLine($"ID: {teacher.ID}, Name: {teacher.Name}");
                    }

                    Console.WriteLine("\nStudents:");
                    foreach (var student in tea.Students)
                    {
                        Console.WriteLine($"ID: {student.ID}, Name: {student.StudentName}");
                    }

                    Console.WriteLine();
                }
            }

            Console.ReadKey();
            Console.Clear();
        }

        public static void Contain(DbCon db)
        {
            Console.Clear();

            var hasMathCourse = db.Subjects
                .Select(c => c.SubjectName)
                .Contains("Programmering1");

                Console.WriteLine($"Does Progroammering 1 exist : {hasMathCourse}");

            Console.ReadKey();
            Console.Clear();


        }
        public static void EditSubject(DbCon db)
        {

            Console.Clear();

            var course = db.Subjects.FirstOrDefault(c => c.SubjectName == "OOP");
            
            string sub = course.SubjectName;
                 
                course.SubjectName = "Programmering2";
                db.SaveChanges();
                Console.WriteLine($"{sub} updated successfully to {course.SubjectName}.");

            Console.ReadKey();
            Console.Clear();
        }


        public static void ChangeTeacher(DbCon db)
        {


            var teach = db.Teachers.FirstOrDefault(c => c.Name == "Anas");
            if (teach != null)
            {
                teach.Name = "Reidar";
                db.SaveChanges();
                Console.WriteLine("Teacher succesfully changed");
            }
            else
            {
                Console.WriteLine("Teacher not found");
            }
        }
    


        public void Delete(DbCon db)
        {

            List<Student> studentsToDelete = db.Students.Where(s => s.ID == 12).ToList(); 
            if (studentsToDelete.Count > 0)
            {
                db.Students.RemoveRange(studentsToDelete); 
                db.SaveChanges(); 
            }
        }

        public void AddKoppling(DbCon db)
        {
            Course course = db.Courses.FirstOrDefault(c => c.ID == 2); 

            course.Teachers = new List<Teacher>()
            {
                db.Teachers.FirstOrDefault(s => s.ID == 1),
                db.Teachers.FirstOrDefault(s => s.ID == 2),
            };

            db.SaveChanges();

        }

        public void AddwithID(DbCon db)
        {
            List<Subject> sub = new List<Subject>()
            {
                new Subject(){SubjectName = "Avencerad.NET", Course = db.Courses.FirstOrDefault(c => c.ID == 1)},
                new Subject(){SubjectName = "DataBas", Course = db.Courses.FirstOrDefault(c => c.ID == 1)},
                new Subject(){SubjectName = "C#", Course = db.Courses.FirstOrDefault(c => c.ID == 1)},
                new Subject(){SubjectName = "Matte", Course = db.Courses.FirstOrDefault(c => c.ID == 2)},
                new Subject(){SubjectName = "Engelska", Course = db.Courses.FirstOrDefault(c => c.ID == 2)},
                new Subject(){SubjectName = "Geografi", Course = db.Courses.FirstOrDefault(c => c.ID == 2)},

            };

        }

        public void Addfunction(DbCon db)
        {
            List<Student> stu = new List<Student>()
            {
            new Student(){StudentName = "Damir"},
            new Student(){StudentName = "Sophia"},
            new Student(){StudentName = "Liam"},
            new Student(){StudentName = "Olivia"},
            new Student(){StudentName = "Noah"},
            new Student(){StudentName = "Emma"},
            new Student(){StudentName = "Ava"},
            new Student(){StudentName = "Isabella"},
            new Student(){StudentName = "Mia"},
            new Student(){StudentName = "Charlotte"},
            };

        }
        








}
}