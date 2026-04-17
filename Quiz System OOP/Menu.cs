using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public abstract class Menu
    {

        public abstract void MainMenu();
        public abstract void ServiceMenu();
        public T Login<T>(List<T> data) where T : User
        {
            string input, email, password;
            Console.WriteLine("=======================");
            Console.WriteLine("Login Menu");
            Console.WriteLine("=======================");
            if (data.Count == 0)
            {
                Console.WriteLine("No users of this type exist in the system yet!");
                return null;
            }
            Console.WriteLine("Hint: Type 'exit' if you want to return to Menu!");

            do
            {
                do
                {
                    Console.Write("> Enter your email: ");
                    input = Console.ReadLine();
                    if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                    {
                        Console.WriteLine("Returning...");
                        return null;
                    }
                    if (!Validation.Email(input))
                    {
                        Console.WriteLine("Invalid Email Format!");
                        continue;
                    }
                    email = input;
                    break;
                } while (true);

                do
                {
                    Console.Write("> Enter your password: ");
                    input = Console.ReadLine();
                    if (Validation.MatchIgnoreCase(input, Constant.EXIT))
                    {
                        Console.WriteLine("Returning...");
                        return null;
                    }
                    if (!Validation.General(input))
                    {
                        Console.WriteLine("Please enter a password!");
                        continue;
                    }
                    password = input;
                    break;
                } while (true);

                foreach (var item in data)
                {
                    if (Validation.MatchIgnoreCase(item.Email, email))
                    {
                        if (Validation.PasswordMatch(item.Password, password))
                        {
                            Console.WriteLine($"Welcome {item.Name}!");
                            return item;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine("Incorrect Email or Password!");
            } while (true);
        }
    }

}
