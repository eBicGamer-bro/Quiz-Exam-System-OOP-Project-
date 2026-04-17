using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public class StudentMenu : Menu, IQuizViewable, IRegisterable, ICoursesViewable
    {
        public StudentService StudentService { private set; get; }
        public StudentMenu(StudentService studentService)
        {
            StudentService = studentService;
        }

        public override void MainMenu()
        {
            do
            {
                Console.WriteLine("=======================");
                Console.WriteLine("> Student Menu <");
                Console.WriteLine("=======================");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.WriteLine("=======================");
                Console.Write("> Please Enter your choice: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            Student student = Login(StudentService.GetStudents());
                            if (student != null)
                            {
                                StudentService.SetStudent(student);
                                ServiceMenu();
                            }
                            break;
                        }
                    case "2":
                        {
                            Register();
                            break;
                        }
                    case "3":
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

        public void Register()
        {
            Console.WriteLine("=======================");
            Console.WriteLine("> Student Register Menu <");
            Console.WriteLine("=======================");
            Console.WriteLine("Hint: Type 'exit' if you want to return!");
            string input, name, email, password;
            Title title = Title.UnAssigned;
            var students = StudentService.GetStudents();

            do
            {
                var flag = true;
                Console.Write("> Enter your Email: ");
                input = Console.ReadLine();
                if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                {
                    Console.WriteLine("Returning...");
                    return;
                }
                if (!Validation.Email(input))
                {
                    Console.WriteLine("Invalid Email Format!");
                    continue;
                }
                foreach (var student in students)
                {
                    if (Validation.MatchIgnoreCase(student.Email, input))
                    {
                        Console.WriteLine("This email already exists!");
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    email = input;
                    break;
                }
            } while (true);

            do
            {
                Console.Write("> Enter your Password (Must be atleast 8 characters long, include an upper case, lower case, and a digit): ");
                input = Console.ReadLine();
                if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                {
                    Console.WriteLine("Returning...");
                    return;
                }
                if (!Validation.Password(input))
                {
                    Console.WriteLine("Invalid Password Format!");
                    continue;
                }
                password = input;
                break;
            } while (true);

            do
            {
                Console.Write("> Re-enter your password: ");
                input = Console.ReadLine();
                if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                {
                    Console.WriteLine("Returning...");
                    return;
                }
                if (!Validation.PasswordMatch(input, password))
                {
                    Console.WriteLine("Not the same password!");
                    continue;
                }
                break;
            } while (true);

            do
            {
                Console.Write("> Enter your Name: ");
                input = Console.ReadLine();
                if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                {
                    Console.WriteLine("Returning...");
                    return;
                }
                if (!Validation.Name(input))
                {
                    Console.WriteLine("Invalid Name Format!");
                    continue;
                }
                name = input;
                break;
            } while (true);

            StudentService.AddStudent(new Student(email, password, name));
            Console.WriteLine("Student created successfully!");
        }

        public override void ServiceMenu()
        {
            do
            {
                Console.WriteLine("=======================");
                Console.WriteLine("> Student Menu <");
                Console.WriteLine("=======================");
                Console.WriteLine("1. Enroll in Course");
                Console.WriteLine("2. View All Courses");
                Console.WriteLine("3. View Enrolled Courses");
                Console.WriteLine("4. View Quizzes");
                Console.WriteLine("5. Take a Quiz");
                Console.WriteLine("6. Logout");
                Console.WriteLine("=======================");
                Console.Write("> Please Enter your choice: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            EnrollCourse();
                            break;
                        }
                    case "2":
                        {
                            ViewCourses();
                            break;
                        }
                    case "3":
                        {
                            ViewEnrolledCourses();
                            break;
                        }
                    case "4":
                        {
                            ViewQuiz();
                            break;
                        }
                    case "5":
                        {
                            TakeQuiz();
                            break;
                        }
                    case "6":
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
            var courses = StudentService.GetAllCourses();
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
                Console.WriteLine($"Number of Quizzes: {course.GetQuizzes().Count}");
                Console.WriteLine("Quiz Names: ");
                foreach (var quiz in course.GetQuizzes())
                {
                    Console.WriteLine($"Name: {quiz.Name}");
                }
            }
            Console.WriteLine("\n=======================");
        }

        public void ViewQuiz()
        {
            string input;
            int choice;
            Console.WriteLine("=======================");
            Console.WriteLine($"View Quizzes Menu");
            Console.WriteLine("=======================");
            Console.WriteLine("Hint: Type 'exit' if you want to return!");
            var quizzes = StudentService.GetTakenQuizzes();
            var list = quizzes.Keys.ToList();
            if (quizzes.Count == 0)
            {
                Console.WriteLine("You have not taken any quizzes yet!");
                return;
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].Name}");
            }
            Console.WriteLine("=======================");
            do
            {
                Console.Write("> Please choose the quiz you want to view: ");
                input = Console.ReadLine();
                if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                {
                    Console.WriteLine("Returning...");
                    return;
                }
                if (!int.TryParse(input, out choice) || choice <= 0 || choice > quizzes.Count)
                {
                    Console.WriteLine("Invalid Choice!");
                    continue;
                }
                break;
            } while (true);
            var result = quizzes.GetValueOrDefault(list[choice - 1]);
            var choices = result.GetAnswers();
            Console.WriteLine("=======================");
            Console.WriteLine($"Quiz Name: {list[choice - 1].Name}");
            Console.WriteLine($"Course Name: {list[choice - 1].Course.Name}");
            Console.WriteLine($"Quiz Duration: {list[choice - 1].Duration.TotalSeconds}S");
            Console.WriteLine($"Score: {result.score}/100");
            Console.WriteLine($"Duration: {result.duration.TotalSeconds}S");
            Console.WriteLine($"Questions: ");
            int j = 1;
            foreach (var question in list[choice - 1].GetQuestions())
            {
                Console.Write($"Q{j}) {question.Display(true)}");
                Console.WriteLine($"Student Answer: {choices[j - 1]}");
                j++;
            }
        }

        public void ViewEnrolledCourses()
        {
            var courses = StudentService.GetEnrolledCourses();
            foreach (var course in courses)
            {
                Console.WriteLine("=======================");
                Console.WriteLine($"Course Name: {course.Name}");
                Console.WriteLine($"Teacher Name: {course.Teacher.Name}");
                Console.WriteLine($"Course Duration: {course.Duration.TotalHours}H");
                Console.WriteLine($"Number of Lessons: {course.NumberofLessons}");
                Console.WriteLine($"Course Category: {course.Category}");
                Console.WriteLine($"Number of Quizzes: {course.GetQuizzes().Count}");
                Console.WriteLine("Quiz Names: ");
                foreach (var quiz in course.GetQuizzes())
                {
                    Console.WriteLine($"Name: {quiz.Name}");
                }
            }
            Console.WriteLine("\n=======================");
        }

        public void TakeQuiz()
        {
            var courses = StudentService.GetEnrolledCourses();
            if (courses.Count == 0)
            {
                Console.WriteLine("You have not enrolled in any courses yet!");
                return;
            }
            Console.WriteLine("=======================");
            Console.WriteLine("> Take Quiz Menu <");
            Console.WriteLine("=======================");
            Console.WriteLine("Hint: Type 'exit' if you want to return!");
            int j = 1;
            foreach (var course in courses)
            {
                Console.WriteLine($"{j++}: {course.Name}");
            }
            Console.WriteLine("=======================");
            int choice;
            do
            {
                Console.Write("> Please choose the course you want to take a quiz in: ");
                string input = Console.ReadLine();
                if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                {
                    Console.WriteLine("Returning...");
                    return;
                }
                if (!int.TryParse(input, out choice) || choice <= 0 || choice > courses.Count)
                {
                    Console.WriteLine("Invalid choice...");
                    continue;
                }
                break;
            } while (true);

            var quizzes = courses[choice - 1].GetQuizzes();
            if (quizzes.Count == 0)
            {
                Console.WriteLine("This course does not have any questions yet!");
                return;
            }
            j = 1;
            foreach (var quiz in quizzes)
            {
                Console.WriteLine($"{j++}: {quiz.Name}");
            }

            do
            {
                Console.Write("> Please choose the quiz you want to take: ");
                string input = Console.ReadLine();
                if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                {
                    Console.WriteLine("Returning...");
                    return;
                }
                if (!int.TryParse(input, out choice) || choice <= 0 || choice > quizzes.Count)
                {
                    Console.WriteLine("Invalid choice...");
                    continue;
                }
                break;
            } while (true);

            if (StudentService.CheckQuizTaken(quizzes[choice - 1]))
            {
                Console.WriteLine("You have already taken this quiz!");
                return;
            }

            if (quizzes[choice - 1].GetQuestions().Count == 0)
            {
                Console.WriteLine("This quiz has no questions yet!");
                return;
            }

            Console.WriteLine($"You have {quizzes[choice - 1].Duration.TotalSeconds} seconds to complete this quiz!");

            StartQuiz(quizzes[choice - 1]);
        }

        public void StartQuiz(Quiz quiz)
        {
            DateTime startTime = DateTime.Now;
            List<string> answers = new List<string>();
            TimeSpan studentTime;
            int i = 0;
            var questions = quiz.GetQuestions();
            foreach (var question in questions)
            {
                if (DateTime.Now - startTime > quiz.Duration)
                {
                    Console.WriteLine("Time is up!");
                    for (; i < questions.Count; i++)
                    {
                        answers.Add("");
                    }
                    break;
                }
                Console.WriteLine($"{i + 1}) {question.Display(false)}");
                do
                {
                    Console.Write("> Enter your answer: ");
                    string input = Console.ReadLine();
                    if (!Validation.General(input))
                    {
                        Console.WriteLine("Please enter an answer!");
                        continue;
                    }
                    answers.Add(input);
                    break;
                } while (true);
                i++;
            }
            studentTime = DateTime.Now - startTime;
            if (studentTime > quiz.Duration)
            {
                studentTime = quiz.Duration;
            }
            int score = StudentService.CalculateScore(quiz, answers);

            Console.WriteLine($"You scored {score}/100.");

            StudentService.AddResult(quiz, new QuizResult(answers, score, studentTime));

            StudentService.UpdateGrade(score, StudentService.GetTakenQuizzes().Count);
        }

        public void EnrollCourse()
        {
            Console.WriteLine("=======================");
            Console.WriteLine("> Enroll Menu <");
            Console.WriteLine("=======================");
            Console.WriteLine("Hint: Type 'exit' if you want to return!");
            var courses = StudentService.GetAllCourses();
            var enrolledCourses = StudentService.GetEnrolledCourses();
            Dictionary<int, Course> courseChoice = new Dictionary<int, Course>();
            int j = 1;
            foreach (var course in courses)
            {
                if (!enrolledCourses.Contains(course))
                {
                    Console.WriteLine($"{j}. {course.Name}");
                    courseChoice[j] = course;
                    j++;
                }
            }
            Console.WriteLine("\n=======================");
            int choice;
            do
            {
                Console.Write("> Please choose the course you want to enroll in: ");
                string input = Console.ReadLine();
                if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                {
                    Console.WriteLine("Returning...");
                    return;
                }
                if (!int.TryParse(input, out choice) || choice <= 0 || choice > courseChoice.Count)
                {
                    Console.WriteLine("Invalid choice...");
                    continue;
                }
                break;
            } while (true);

            if (StudentService.Enroll(courseChoice[choice]))
            {
                Console.WriteLine("Enrolled Successfully");
            }
            else
            {
                Console.WriteLine("This course does not have an assigned teacher yet!");
            }
        }
    }

}
