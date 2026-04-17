using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public class TeacherMenu : Menu, IQuizViewable, IRegisterable
    {
        public TeacherService TeacherService { private set; get; }
        public TeacherMenu(TeacherService teacherService)
        {
            TeacherService = teacherService;
        }

        public override void MainMenu()
        {
            do
            {
                Console.WriteLine("=======================");
                Console.WriteLine("> Teacher Menu <");
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
                            Teacher teacher = Login(TeacherService.GetTeachers());
                            if (teacher != null)
                            {
                                TeacherService.SetTeacher(teacher);
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
            Console.WriteLine("> Teacher Register Menu <");
            Console.WriteLine("=======================");
            Console.WriteLine("Hint: Type 'exit' if you want to return!");
            string input, name, email, password;
            Title title = Title.UnAssigned;
            var teachers = TeacherService.GetTeachers();

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
                foreach (var teacher in teachers)
                {
                    if (Validation.MatchIgnoreCase(teacher.Email, input))
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

            Console.WriteLine("=======================");
            Console.WriteLine("1. Substitute\n2. ClassroomTeacher\n3. Specialist\n4. LeadTeacher\n5. DepartmentHead\n6. AcademicCoordinator");
            Console.WriteLine("=======================");

            do
            {
                bool flag = true;
                Console.Write("> Please select the job title: ");
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
                            title = Title.Substitute;
                            break;
                        }
                    case "2":
                        {
                            title = Title.ClassroomTeacher;
                            break;
                        }
                    case "3":
                        {
                            title = Title.Specialist;
                            break;
                        }
                    case "4":
                        {
                            title = Title.LeadTeacher;
                            break;
                        }
                    case "5":
                        {
                            title = Title.DepartmentHead;
                            break;
                        }
                    case "6":
                        {
                            title = Title.AcademicCoordinator;
                            break;
                        }
                    default:
                        {
                            flag = false;
                            Console.WriteLine("Invalid Input!");
                            break;
                        }
                }
                if (flag)
                {
                    break;
                }
            } while (true);

            TeacherService.AddTeacher(new Teacher(title, email, password, name));
            Console.WriteLine("Teacher account created successfully!");

        }

        public override void ServiceMenu()
        {
            do
            {
                Console.WriteLine("=======================");
                Console.WriteLine("> Teacher Menu <");
                Console.WriteLine("=======================");
                Console.WriteLine("1. Assign to a Course");
                Console.WriteLine("2. UnAssign from a Course");
                Console.WriteLine("3. View Assigned Courses");
                Console.WriteLine("4. View UnAssigned Courses");
                Console.WriteLine("5. View A Quiz");
                Console.WriteLine("6. Create a Quiz");
                Console.WriteLine("7. Edit a Quiz");
                Console.WriteLine("8. Logout");
                Console.WriteLine("=======================");
                Console.Write("> Please Enter your choice: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            AssignCourse();
                            break;
                        }
                    case "2":
                        {
                            UnAssignCourse();
                            break;
                        }
                    case "3":
                        {
                            ViewAssignedCourses();
                            break;
                        }
                    case "4":
                        {
                            ViewUnAssignedCourses();
                            break;
                        }
                    case "5":
                        {
                            ViewQuiz();
                            break;
                        }
                    case "6":
                        {
                            CreateQuiz();
                            break;
                        }
                    case "7":
                        {
                            EditQuizMenu();
                            break;
                        }
                    case "8":
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

        public void UnAssignCourse()
        {
            var courses = TeacherService.GetAssignedCourses();
            Console.WriteLine("=======================");
            Console.WriteLine($"UnAssign Menu");
            Console.WriteLine("=======================");
            if (courses.Count == 0)
            {
                Console.WriteLine("You have no Assigned Courses!");
                return;
            }
            Console.WriteLine("Hint: Type 'exit' if you want to return!");

            int i = 1;
            string input;
            int choice;
            foreach (var course in courses)
            {
                Console.WriteLine($"{i++}. {course.Name}");
            }
            do
            {
                Console.Write("> Please choose the course you want to UnAssign: ");
                input = Console.ReadLine();

                if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                {
                    Console.WriteLine("Returning...");
                    return;
                }

                if (!int.TryParse(input, out choice) || choice <= 0 || choice > courses.Count)
                {
                    Console.WriteLine("Invalid Choice!");
                    continue;
                }
                break;
            } while (true);

            if (!TeacherService.RemoveCourse(courses[choice - 1]))
            {
                Console.WriteLine($"Students are already enrolled in this course!");
                return;
            }
            ;
            Console.WriteLine("Course removed successfully!");
        }
        public void ViewQuiz()
        {
            string input;
            int choice;
            Console.WriteLine("=======================");
            Console.WriteLine($"View Quiz Menu");
            Console.WriteLine("=======================");
            Console.WriteLine("Hint: Type 'exit' if you want to return!");
            var quizzes = TeacherService.GetCreatedQuizzes();
            if (quizzes.Count == 0)
            {
                Console.WriteLine("You have not created any quizzes yet!");
                return;
            }
            for (int i = 0; i < quizzes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {quizzes[i].Name}");
            }
            Console.WriteLine("=======================");
            do
            {
                Console.WriteLine("> Please choose the quiz you want to view: ");
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
            Console.WriteLine("=======================");
            Console.WriteLine($"Name: {quizzes[choice - 1].Name}");
            Console.WriteLine($"Duration: {quizzes[choice - 1].Duration.TotalSeconds}S");
            Console.WriteLine($"Number of takers: {quizzes[choice - 1].GetStudents().Count}");
            Console.WriteLine($"Questions: ");
            int j = 1;
            foreach (var question in quizzes[choice - 1].GetQuestions())
            {
                Console.Write($"Q{j++}) {question.Display(true)}");

            }

        }

        public void ViewAssignedCourses()
        {
            var assignedCourses = TeacherService.GetAssignedCourses();
            if (assignedCourses.Count == 0)
            {
                Console.WriteLine("You have no assigned courses!");
                return;
            }
            Console.WriteLine("=======================");
            Console.WriteLine($"Assigned Courses Menu");
            foreach (var course in assignedCourses)
            {
                Console.WriteLine("=======================");
                Console.WriteLine($"Course Name: {course.Name}");
                Console.WriteLine($"Course Category: {course.Category}");
                Console.WriteLine($"Course Duration: {course.Duration.TotalHours}H");
                Console.WriteLine($"Number of Lessons: {course.NumberofLessons}");
                Console.WriteLine($"Number of quizzes: {course.GetQuizzes().Count}");
            }
            Console.WriteLine("=======================");
        }

        public void ViewUnAssignedCourses()
        {
            var assignedCourses = TeacherService.GetAssignedCourses();
            bool flag = true;
            Console.WriteLine("=======================");
            Console.WriteLine("UnAssigned Courses Menu");
            foreach (var course in TeacherService.GetAllCourses())
            {
                if (!assignedCourses.Contains(course))
                {
                    Console.WriteLine("=======================");
                    Console.WriteLine($"Course Name: {course.Name}");
                    Console.WriteLine($"Course Category: {course.Category}");
                    Console.WriteLine($"Course Duration: {course.Duration.TotalHours}H");
                    flag = false;
                }
            }
            if (flag)
            {
                Console.WriteLine("There are no UnAssigned Courses!");
                return;
            }
            Console.WriteLine("=======================");
        }
        public void AssignCourse()
        {
            var courses = TeacherService.GetAllCourses();
            courses = courses.Where(a => a.Status == Status.UnAssigned).ToList();
            if (courses.Count == 0)
            {
                Console.WriteLine("There are currently no UnAssigned Courses!");
                return;
            }
            string input;
            int choice;
            Console.WriteLine("=======================");
            Console.WriteLine("Assign to Course Menu");
            Console.WriteLine("=======================");
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {courses[i].Name}");
            }
            Console.WriteLine("=======================");
            do
            {
                Console.Write("> Please choose the course you want to assign to: ");
                input = Console.ReadLine();

                if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                {
                    Console.WriteLine("Returning...");
                    return;
                }

                if (!int.TryParse(input, out choice) || choice <= 0 || choice > courses.Count)
                {
                    Console.WriteLine("Invalid Choice!");
                    continue;
                }

                break;
            } while (true);
            TeacherService.AddCourse(courses[choice - 1]);
            Console.WriteLine("Course Assigned Successfully!");
        }
        public void CreateQuiz()
        {
            string input, name;
            int choice;
            TimeSpan duration;
            var courses = TeacherService.GetAssignedCourses();
            Console.WriteLine("=======================");
            Console.WriteLine($"Create Quiz Menu");
            Console.WriteLine("=======================");
            if (courses.Count == 0)
            {
                Console.WriteLine("You have no assigned courses");
            }
            Console.WriteLine("Hint: Type 'exit' if you want to return!");
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {courses[i].Name}");
            }
            Console.WriteLine("=======================");
            do
            {
                Console.Write("> Please choose the course you want to create a quiz in: ");
                input = Console.ReadLine();

                if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                {
                    Console.WriteLine("Returning...");
                    return;
                }

                if (!int.TryParse(input, out choice) || choice <= 0 || choice > courses.Count)
                {
                    Console.WriteLine("Invalid Choice!");
                    continue;
                }

                break;
            } while (true);

            do
            {
                Console.Write("> Enter quiz name: ");
                input = Console.ReadLine();

                if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                {
                    Console.WriteLine("Returning...");
                    return;
                }
                if (!Validation.General(input))
                {
                    Console.WriteLine("Quiz Name can't be empty!");
                    continue;
                }
                if (Validation.ContainsName(TeacherService.GetCreatedQuizzes(), input))
                {
                    Console.WriteLine("This quiz name already exists!");
                }
                name = input;
                break;
            } while (true);

            do
            {
                Console.Write("> Enter The duration of the quiz in Seconds: ");
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
                duration = TimeSpan.FromSeconds(number);
                break;
            } while (true);

            Quiz quiz = new Quiz(name, duration, courses[choice - 1]);
            TeacherService.AddQuiz(quiz, courses[choice - 1]);
            EditQuizMenu(quiz);
        }
        public void EditQuizMenu(Quiz? quiz = null)
        {
            string choice;
            int index;
            if (quiz == null)
            {
                var quizzes = TeacherService.GetCreatedQuizzes();
                if (quizzes.Count == 0)
                {
                    Console.WriteLine("You have no quizzes created to edit");
                    return;
                }
                Console.WriteLine("=======================");
                Console.WriteLine($"Edit Quiz Menu");
                Console.WriteLine("=======================");
                Console.WriteLine("Hint: Type 'exit' if you want to return!");
                int i = 1;
                foreach (var quiz1 in quizzes)
                {
                    Console.WriteLine($"{i++}. {quiz1.Name}");
                }

                do
                {
                    Console.Write("> Please choose the quiz you want to edit: ");
                    string input = Console.ReadLine();

                    if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                    {
                        Console.WriteLine("Returning...");
                        return;
                    }

                    if (!int.TryParse(input, out index) || index <= 0 || index > quizzes.Count)
                    {
                        Console.WriteLine("Invalid Choice!");
                        continue;
                    }
                    break;
                } while (true);
                quiz = quizzes[index - 1];
                int count = quiz.GetStudents().Count;
                if (count > 0)
                {
                    Console.WriteLine($"{count} students have already taken this quiz!");
                    return;
                }
            }

            do
            {
                Console.WriteLine("=======================");
                Console.WriteLine("1. Add Question");
                Console.WriteLine("2. Remove Question");
                Console.WriteLine("3. Exit");
                Console.WriteLine("=======================");
                do
                {
                    bool flag = true;
                    Console.Write("> Please enter your choice: ");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            {
                                AddQuestionMenu(quiz);
                                break;
                            }
                        case "2":
                            {
                                RemoveQuestionMenu(quiz);
                                break;
                            }
                        case "3":
                            {
                                return;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid Input!");
                                flag = false;
                                break;
                            }
                    }
                    if (flag)
                    {
                        break;
                    }

                } while (true);

            } while (true);
        }
        public void AddQuestionMenu(Quiz quiz)
        {
            string input, question;
            QuestionType type = QuestionType.UnAssigned;
            Console.WriteLine("=======================");
            Console.WriteLine("Hint: Type 'exit' if you want to return!");

            Console.WriteLine("=======================");
            Console.WriteLine($"1. MCQ\n2. TrueOrFalse\n3. Short Answer");
            Console.WriteLine("=======================");
            do
            {
                bool flag = true;
                Console.Write("> Please choose the question Type: ");
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
                            type = QuestionType.MCQ;
                            break;
                        }
                    case "2":
                        {
                            type = QuestionType.TRUEorFALSE;
                            break;
                        }
                    case "3":
                        {
                            type = QuestionType.ShortAnswer;
                            break;
                        }
                    default:
                        {
                            flag = false;
                            break;
                        }
                }
                if (flag)
                {
                    break;
                }

            } while (true);


            do
            {
                Console.Write("> Please enter the question: ");
                input = Console.ReadLine();
                if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                {
                    Console.WriteLine("Returning...");
                    return;
                }
                if (!Validation.General(input))
                {
                    Console.WriteLine("Question can't be empty!");
                    continue;
                }
                question = input;
                break;
            } while (true);

            switch (type)
            {
                case QuestionType.MCQ:
                    {
                        List<string> choices = new List<string>();
                        int amount;
                        string input1;
                        do
                        {
                            Console.Write("> Please enter the number of choices: ");
                            input1 = Console.ReadLine();
                            if (Validation.MatchIgnoreCase(input1, Constant.EXIT))
                            {
                                Console.WriteLine("Returning...");
                                return;
                            }
                            if (!int.TryParse(input1, out amount) || amount <= 0)
                            {
                                Console.WriteLine("Invalid Number of choices!");
                                continue;
                            }
                            break;

                        } while (true);
                        int i = 0;
                        do
                        {
                            Console.Write($"> Please enter choice {i + 1}: ");
                            input1 = Console.ReadLine();
                            if (Validation.MatchIgnoreCase(input1, Constant.EXIT))
                            {
                                Console.WriteLine("Returning...");
                                return;
                            }
                            if (!Validation.General(input1))
                            {
                                Console.WriteLine("choice can't be empty!");
                                continue;
                            }
                            i++;
                            choices.Add(input1);
                            if (i == amount)
                            {
                                break;
                            }

                        } while (true);
                        int answer;
                        do
                        {
                            Console.Write($"> Please choose the number of the correct answer: ");
                            input1 = Console.ReadLine();
                            if (Validation.MatchIgnoreCase(input1, Constant.EXIT))
                            {
                                Console.WriteLine("Returning...");
                                return;
                            }
                            if (!int.TryParse(input1, out answer) || answer <= 0 || answer > amount)
                            {
                                Console.WriteLine("Invalid choice!");
                                continue;
                            }
                            break;
                        } while (true);
                        TeacherService.AddQuestion(quiz, new MCQQuestion(question, (answer).ToString(), choices));
                        break;
                    }
                case QuestionType.TRUEorFALSE:
                    {
                        int answer;
                        bool choice;
                        Console.WriteLine("1. True\n2. False");
                        do
                        {
                            Console.Write("> Please select the correct choice: ");
                            string input1 = Console.ReadLine();
                            if (Validation.MatchIgnoreCase(input1, Constant.EXIT))
                            {
                                Console.WriteLine("Returning...");
                                return;
                            }
                            if (!int.TryParse(input1, out answer) || (answer != 1 && answer != 2))
                            {
                                Console.WriteLine("Invalid choice!");
                                continue;
                            }

                            break;
                        } while (true);
                        TeacherService.AddQuestion(quiz, new TrueorFalseQuestion(answer.ToString(), question));
                        break;
                    }
                case QuestionType.ShortAnswer:
                    {
                        string input1, answer;
                        do
                        {
                            Console.Write($"> Please type the answer: ");
                            input1 = Console.ReadLine();
                            if (Validation.MatchIgnoreCase(input1, Constant.EXIT))
                            {
                                Console.WriteLine("Returning...");
                                return;
                            }
                            if (!Validation.General(input1))
                            {
                                Console.WriteLine("choice can't be empty!");
                                continue;
                            }
                            answer = input1;
                            break;
                        } while (true);
                        TeacherService.AddQuestion(quiz, new ShortAnswer(question, answer));
                        break;
                    }
            }
            Console.WriteLine("Question added successfully!");
        }

        public void RemoveQuestionMenu(Quiz quiz)
        {
            int i = 1;
            var questions = quiz.GetQuestions();
            string input;
            int choice;
            int count = questions.Count;
            if (count == 0)
            {
                Console.WriteLine("No questions exist in this quiz!");
                return;
            }
            foreach (var question in questions)
            {
                Console.WriteLine($"{i++}. {question.Body}?");
            }
            do
            {
                Console.Write("> Please choose the question you want to remove: ");
                input = Console.ReadLine();

                if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                {
                    Console.WriteLine("Returning...");
                    return;
                }

                if (!int.TryParse(input, out choice) || choice <= 0 || choice > questions.Count)
                {
                    Console.WriteLine("Invalid Choice!");
                    continue;
                }
                break;
            } while (true);
            TeacherService.RemoveQuestion(quiz, questions[choice - 1]);
            Console.WriteLine("Question Removed!");
        }
    }

}
