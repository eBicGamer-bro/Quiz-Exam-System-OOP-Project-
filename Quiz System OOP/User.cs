using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public class User
    {
        public string Email { private set; get; }
        public string Password { private set; get; }
        public string Name { private set; get; }

        public User(string email, string password, string name)
        {
            if (!Validation.Name(name))
            {
                throw new InvalidDataException("Invalid name format!");
            }
            if (!Validation.Email(email))
            {
                throw new InvalidDataException("Invalid email format!");
            }
            if (!Validation.Password(password))
            {
                throw new InvalidDataException("Invalid password format!");
            }
            Email = email;
            Password = password;
            Name = name;
        }
    }

}
