using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public class AdminMenu : Menu, ICoursesViewable
    {
        public AdminService AdminService { private set; get; }
        public AdminMenu(AdminService adminService)
        {
            if (adminService == null)
            {
                throw new InvalidDataException("Admin Service is null");
            }
            AdminService = adminService;
        }

        public override void MainMenu()
        {
            do
            {
                Console.WriteLine("=======================");
                Console.WriteLine("> Admin Menu <");
                Console.WriteLine("=======================");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Exit");
                Console.WriteLine("=======================");
                Console.Write("> Please Enter your choice: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            Admin admin = Login(AdminService.GetAdmins());
                            if (admin != null)
                            {
                                AdminService.Admin = admin;
                                ServiceMenu();
                            }
                            break;
                        }
                    case "2":
                        {
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid input!");
                            break;
                        }
                }
            } while (true);
        }

        public void ViewCourses()
        {
            var courses = AdminService.GetAllCourses();
            if (courses.Count == 0)
            {
                Console.WriteLine("No courses exist in the system!");
            }
            foreach (var course in courses)
            {
                Console.WriteLine("=======================");
                Console.WriteLine($"Course Name: {course.Name}");
                if (course.Status == Status.Assigned)
                {
                    Console.WriteLine($"Teacher Name: {course.Teacher.Name}");
                }
                else
                {
                    Console.WriteLine($"Teacher Name: None");

                }
                Console.WriteLine($"Course Duration: {course.Duration.TotalHours}H");
                Console.WriteLine($"Number of Lessons: {course.NumberofLessons}");
                Console.WriteLine($"Course Category: {course.Category}");
                Console.WriteLine($"Number of Students Enrolled: {course.GetEnrolledStudents().Count}");
                Console.WriteLine($"Number of Quizzes: {course.GetQuizzes().Count}");
                Console.WriteLine("Quiz Names: ");
                foreach (var quiz in course.GetQuizzes())
                {
                    Console.WriteLine($"Name: {quiz.Name}");
                }
                Console.Write("\nStudent Names: ");
                foreach (var student in course.GetEnrolledStudents())
                {
                    Console.WriteLine($"Name: {student.Name}");
                }
            }
            Console.WriteLine("\n=======================");

        }
        public void ViewStudents()
        {
            var students = AdminService.GetStudents();
            if (students.Count == 0)
            {
                Console.WriteLine("No students exist in the system!");
            }
            foreach (var student in students)
            {
                Console.WriteLine("=======================");
                Console.WriteLine($"Student Name: {student.Name}");
                Console.WriteLine($"Student Email: {student.Email}");
                Console.WriteLine($"Student Grade: {student.Grade}");
                Console.WriteLine($"Number of Courses Enrolled in: {student.GetEnrolledCourses().Count}");
                Console.WriteLine($"Number of Quizzes Taken: {student.GetQuizzesTaken().Count}");
                Console.WriteLine("Course Names:");
                foreach (var course in student.GetEnrolledCourses())
                {
                    Console.WriteLine($"Name: {course.Name}");
                }
                Console.WriteLine("Quiz Names:");
                foreach (var quiz in student.GetQuizzesTaken())
                {
                    Console.WriteLine($"Name: {quiz.Key.Name}");
                }
            }
            Console.WriteLine("\n=======================");
        }
        public void ViewTeachers()
        {
            var teachers = AdminService.GetTeachers();
            if (teachers.Count == 0)
            {
                Console.WriteLine("No teachers exist in the system!");
            }
            foreach (var teacher in teachers)
            {
                Console.WriteLine("=======================");
                Console.WriteLine($"Teacher Name: {teacher.Name}");
                Console.WriteLine($"Teacher Email: {teacher.Email}");
                Console.WriteLine($"Teacher Title: {teacher.Title}");
                Console.WriteLine($"Number of Courses Teacher teach: {teacher.GetAssignedCourses().Count}");
                Console.WriteLine($"Number of Quizzes Created: {teacher.GetCreatedQuizzes().Count}");
                Console.WriteLine("Courses:");
                foreach (var course in teacher.GetAssignedCourses())
                {
                    Console.WriteLine($"Name: {course.Name} || Category: {course.Category}");
                }
                Console.WriteLine("Quizzes:");
                foreach (var quiz in teacher.GetCreatedQuizzes())
                {
                    Console.WriteLine($"Name: {quiz.Name}");
                }
            }
        }
        public void CreateCourse()
        {
            Console.WriteLine("=======================");
            Console.WriteLine("> Course Creation Menu <");
            Console.WriteLine("=======================");
            Console.WriteLine("Hint: Type 'exit' if you want to return!");
            string input, name;
            int nooflessons;
            Category category = Category.UnAssigned;
            TimeSpan duration;

            do
            {
                Console.Write("> Enter course name: ");
                input = Console.ReadLine();
                if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                {
                    Console.WriteLine("Returning...");
                    return;
                }
                if (!Validation.General(input))
                {
                    Console.WriteLine("Course name is empty!");
                    continue;
                }
                name = input;
                break;
            } while (true);

            do
            {
                Console.Write("> Enter Number of Lessons: ");
                input = Console.ReadLine();
                if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                {
                    Console.WriteLine("Returning...");
                    return;
                }
                if (!int.TryParse(input, out nooflessons) || nooflessons <= 0)
                {
                    Console.WriteLine("Invalid Number of Lessons!");
                    continue;
                }
                break;
            } while (true);

            Console.WriteLine("=======================");
            Console.WriteLine("1. Math\n2. Science\n3. Mechanics\n4. Programming\n5. English ");
            Console.WriteLine("=======================");
            do
            {
                bool flag = true;
                Console.Write("> Please choose a category: ");
                input = Console.ReadLine();
                if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                {
                    Console.WriteLine("Returning...");
                    return;
                }
                switch (input)
                {
                    case "1":
                        {
                            category = Category.Math;
                            break;
                        }
                    case "2":
                        {
                            category = Category.Science;
                            break;
                        }
                    case "3":
                        {
                            category = Category.Mechanics;
                            break;
                        }
                    case "4":
                        {
                            category = Category.Programming;
                            break;
                        }
                    case "5":
                        {
                            category = Category.English;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice!");
                            flag = false;
                            break;
                        }
                }
                if (flag)
                    break;
            } while (true);

            do
            {
                Console.Write("> Enter The duration of the course in Hours: ");
                input = Console.ReadLine();
                if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                {
                    Console.WriteLine("Returning...");
                    return;
                }
                if (!int.TryParse(input, out int number) || number <= 0)
                {
                    Console.WriteLine("Invalid Duration!");
                    continue;
                }
                duration = TimeSpan.FromHours(number);
                break;
            } while (true);

            if (AdminService.AddCourse(new Course(name, duration, AdminService.Admin, category, nooflessons)))
                Console.WriteLine("Course Added Successfully");
            else
                Console.WriteLine("This course name already exists!\nCourse was not added!");
        }

        public override void ServiceMenu()
        {
            do
            {
                Console.WriteLine("=======================");
                Console.WriteLine("> Admin Menu <");
                Console.WriteLine("=======================");
                Console.WriteLine("1. Create Course");
                Console.WriteLine("2. View All Courses");
                Console.WriteLine("3. View All Students");
                Console.WriteLine("4. View All Teachers");
                Console.WriteLine("5. Logout");
                Console.WriteLine("=======================");
                Console.Write("> Please Enter your choice: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            CreateCourse();
                            break;
                        }
                    case "2":
                        {
                            ViewCourses();
                            break;
                        }
                    case "3":
                        {
                            ViewStudents();
                            break;
                        }
                    case "4":
                        {
                            ViewTeachers();
                            break;
                        }
                    case "5":
                        {
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid input!");
                            break;
                        }
                }
            } while (true);
        }
    }

}
