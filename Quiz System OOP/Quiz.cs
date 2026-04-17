using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public class Quiz
    {
        public string Name { private set; get; }
        public TimeSpan Duration { private set; get; }
        public Course Course { private set; get; }
        private Dictionary<Student, int> _studentMarks;
        private List<Question> _questions;

        public Quiz(string Name, TimeSpan Duration, Course Course)
        {
            if (!Validation.General(Name))
            {
                throw new InvalidDataException("Invalid Quiz Name");
            }
            if (Duration <= TimeSpan.Zero)
            {
                throw new InvalidDataException("Invalid Quiz Duration");
            }
            this.Name = Name;
            this.Duration = Duration;
            this.Course = Course;
            this._questions = new List<Question>();
            this._studentMarks = new Dictionary<Student, int>();
        }

        public void AddQuestion(Question question)
        {
            if (_questions.Contains(question))
            {
                throw new InvalidOperationException("Question Already Exists!");
            }
            _questions.Add(question);
        }
        public void RemoveQuestion(Question question)
        {
            if (!_questions.Remove(question))
            {
                throw new InvalidOperationException("Question does not exist!");
            }
        }
        public void AddStudentScore(Student student, int score)
        {
            if (_studentMarks.ContainsKey(student))
            {
                throw new InvalidOperationException("Student Already took this quiz!");
            }
            if (score < 0)
            {
                throw new InvalidDataException("Score can't be less than 0!");
            }
            _studentMarks.Add(student, score);
        }
        public List<Question> GetQuestions()
        {
            return _questions.ToList();
        }
        public List<Student> GetStudents()
        {
            return _studentMarks.Keys.ToList();
        }
    }

}
