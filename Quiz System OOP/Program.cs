using System.Reflection.PortableExecutable;
using System.Text;
using System.Xml.Linq;

namespace Quiz_System_OOP
{
    internal class Program
        {

            static void Main(string[] args)
            {
                Database database = new Database();
                Console.WriteLine("================Welcome to the Quiz/Exam System================");
                Console.WriteLine("");
                Console.WriteLine("");
                do
                {
                    Console.WriteLine("=======================");
                    Console.WriteLine("> Main Menu <");
                    Console.WriteLine("=======================");
                    Console.WriteLine("1. Admin");
                    Console.WriteLine("2. Teacher");
                    Console.WriteLine("3. Student");
                    Console.WriteLine("4. Exit The Program");
                    Console.WriteLine("=======================");
                    Console.Write("> Please Choose the User Type: ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            {
                                AdminMenu adminmenu = new AdminMenu(new AdminService(database));
                                adminmenu.MainMenu();
                                break;
                            }
                        case "2":
                            {
                                TeacherMenu teacherMenu = new TeacherMenu(new TeacherService(database));
                                teacherMenu.MainMenu();
                                break;
                            }
                        case "3":
                            {
                                StudentMenu studentMenu = new StudentMenu(new StudentService(database));
                                studentMenu.MainMenu();
                                break;
                            }
                        case "4":
                            {
                                Console.WriteLine("Exiting the program...");
                                return;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid Input!");
                                break;
                            }

                    }
                } while (true);
            }
        }


    }

