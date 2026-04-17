using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public class Student : User
    {
        private Grade _grade;
        public int TotalScore { private set; get; }
        private List<Course> _enrolledCourses;
        private Dictionary<Quiz, QuizResult> _quizzesTaken;

        public Student(string email, string password, string name) : base(email, password, name)
        {
            this._grade = Grade.U;
            this.TotalScore = 0;
            _enrolledCourses = new List<Course>();
            _quizzesTaken = new Dictionary<Quiz, QuizResult>();
        }
        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new InvalidDataException("Course is empty!");
            }
            if (_enrolledCourses.Contains(course))
            {
                throw new InvalidOperationException("Student Already Enrolled!");
            }
            _enrolledCourses.Add(course);
        }
        public void AddQuiz(Quiz quiz, QuizResult result)
        {
            if (quiz == null)
            {
                throw new InvalidDataException("Quiz is empty!");
            }
            if (result == null)
            {
                throw new InvalidDataException("Result is empty!");
            }
            if (_quizzesTaken.ContainsKey(quiz))
            {
                throw new InvalidOperationException("This quiz is already taken!");
            }
            _quizzesTaken.Add(quiz, result);
        }
        public List<Course> GetEnrolledCourses()
        {
            return _enrolledCourses.ToList();
        }
        public Dictionary<Quiz, QuizResult> GetQuizzesTaken()
        {
            return _quizzesTaken.ToDictionary();
        }
        public Grade Grade
        {
            set
            {
                _grade = value;
            }
            get
            {
                return _grade;
            }
        }
        public void AddToTotal(int value)
        {
            if (value < 0)
            {
                throw new InvalidDataException("Score can't be less than zero!");
            }
            TotalScore += value;
        }

    }

}
