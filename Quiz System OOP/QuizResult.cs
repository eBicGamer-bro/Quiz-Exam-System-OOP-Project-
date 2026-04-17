using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public class QuizResult
    {
        private List<string> _answers;
        public int score { private set; get; }

        public TimeSpan duration { private set; get; }

        public QuizResult(List<string> answers, int score, TimeSpan duration)
        {
            _answers = answers;
            this.score = score;
            this.duration = duration;
        }

        public List<string> GetAnswers()
        {
            return _answers.ToList();
        }
    }

}
