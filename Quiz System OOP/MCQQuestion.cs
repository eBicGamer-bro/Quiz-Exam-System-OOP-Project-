using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public class MCQQuestion : Question
    {
        private List<string> _choices;

        public MCQQuestion(string question, string Answer, List<string> Choices) : base(question, Answer)
        {
            if (!Validation.List(Choices))
            {
                throw new InvalidDataException("Invalid Choices!");
            }
            if (Choices.Count < 2)
            {
                throw new InvalidDataException("There has to be atleast 2 Choices!");
            }
            this._choices = Choices.ToList();
        }

        public override string Display(bool showAnswer)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{Body}?");
            int j = 1;
            foreach (var choice in _choices)
            {
                stringBuilder.AppendLine($"{j++}. {choice}");
            }
            if (showAnswer)
            {
                stringBuilder.AppendLine($"Correct Answer: {Answer}");
            }
            return stringBuilder.ToString();
        }
    }

}
