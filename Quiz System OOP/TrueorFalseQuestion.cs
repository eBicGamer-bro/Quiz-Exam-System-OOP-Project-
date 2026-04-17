using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public class TrueorFalseQuestion : Question
    {
        public TrueorFalseQuestion(string choice, string question) : base(question, choice)
        {
        }

        public override string Display(bool showAnswer)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{Body}?");
            stringBuilder.AppendLine("1. True\n2. False\n");
            if (showAnswer)
            {
                stringBuilder.AppendLine($"Correct Answer: {Answer}");
            }
            return stringBuilder.ToString();
        }

    }

}
