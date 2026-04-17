using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public class ShortAnswer : Question
    {
        public ShortAnswer(string Body, string Answer) : base(Body, Answer)
        {
        }

        public override string Display(bool showAnswer)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{Body}?");
            if (showAnswer)
            {
                stringBuilder.AppendLine($"Correct Answer: {Answer}");
            }
            return stringBuilder.ToString();
        }
    }

}
