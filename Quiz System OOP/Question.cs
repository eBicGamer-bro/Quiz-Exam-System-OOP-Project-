using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public abstract class Question
    {
        public string Body { protected set; get; }
        public string Answer { protected set; get; }
        public Question(string Body, string Answer)
        {
            if (!Validation.General(Body))
            {
                throw new InvalidDataException("Questions can't be empty!");
            }
            if (!Validation.General(Answer))
            {
                throw new InvalidDataException("Answer can't be empty!");
            }
            this.Body = Body;
            this.Answer = Answer;
        }
        public abstract string Display(bool showAnswer);

    }

}
