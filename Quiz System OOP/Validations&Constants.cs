using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public static class Constant
    {
        public const string EXIT = "exit";
        public const int PASSWORDMIN = 8;
    }

    public static class Validation
    {
        public static bool Email(string email)
        {
            email = email.Trim();
            if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
                return false;
            int index = email.IndexOf("@");
            if (index == -1 || index == 0)
                return false;
            if (email.Count(a => a == '@') > 1 || !char.IsLetterOrDigit(email[0]))
                return false;
            if (email.LastIndexOf(".") <= index + 1 || email.LastIndexOf(".") == email.Length - 1)
                return false;
            if (email.Contains("..") || email.Contains(" "))
                return false;
            return true;

        }
        public static bool Name(string name)
        {
            name = name.TrimEnd();
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                return false;
            foreach (char c in name)
            {
                if (char.IsWhiteSpace(c) || char.IsLetter(c))
                    continue;
                return false;
            }
            if (name.Contains("  "))
                return false;

            return true;
        }
        public static bool Password(string password)
        {
            password = password.Trim();
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                return false;
            if (password.Contains(" "))
                return false;
            if (password.Length < Constant.PASSWORDMIN)
                return false;
            if (!password.Any(char.IsDigit) || !password.Any(char.IsUpper) || !password.Any(char.IsLower))
                return false;
            return true;
        }
        public static bool General(string value)
        {
            value = value.Trim();
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                return false;
            return true;
        }

        public static bool List(List<string> list)
        {
            if (list == null || list.Count == 0)
                return false;
            foreach (var value in list)
            {
                if (string.IsNullOrEmpty(value.Trim()) || string.IsNullOrWhiteSpace(value.Trim()))
                    return false;
            }
            return true;
        }

        public static bool MatchIgnoreCase(string value1, string value2)
        {

            value1 = value1.ToLower().Trim();
            value2 = value2.ToLower().Trim();
            if (string.IsNullOrEmpty(value1) && !string.IsNullOrEmpty(value2))
                return false;
            else if (!string.IsNullOrEmpty(value1) && string.IsNullOrEmpty(value2))
                return false;
            else if (string.IsNullOrEmpty(value1) && string.IsNullOrEmpty(value2))
                return true;
            return value1 == value2;
        }

        public static bool PasswordMatch(string password1, string password2)
        {
            password1 = password1.Trim();
            password2 = password2.Trim();
            if (string.IsNullOrEmpty(password1) && !string.IsNullOrEmpty(password2))
                return false;
            else if (!string.IsNullOrEmpty(password1) && string.IsNullOrEmpty(password2))
                return false;
            else if (string.IsNullOrEmpty(password1) && string.IsNullOrEmpty(password2))
                return true;
            return password1 == password2;
        }

        public static bool ContainsName(List<Quiz> data, string item)
        {
            foreach (var item1 in data)
            {
                if (item1.Name.ToLower().Trim() == item.ToLower().Trim())
                {
                    return true;
                }
            }
            return false;
        }
    }

}
