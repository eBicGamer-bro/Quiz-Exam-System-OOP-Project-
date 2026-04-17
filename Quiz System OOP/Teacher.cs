using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public class Teacher : User
    {
        public Title Title { private set; get; }
        private List<Course> _assignedCourses;
        private List<Quiz> _quizzesCreated;
        public Teacher(Title title, string email, string password, string name) : base(email, password, name)
        {
            Title = title;
            _assignedCourses = new List<Course>();
            _quizzesCreated = new List<Quiz>();
        }

        public void AddCourse(Course course)
        {
            _assignedCourses.Add(course);
        }
        public void AddQuiz(Quiz quiz)
        {
            _quizzesCreated.Add(quiz);
        }
        public void RemoveCourse(Course course)
        {
            if (!_assignedCourses.Remove(course))
            {
                throw new InvalidOperationException("This course does not exist for the Teacher");
            }
        }
        public List<Course> GetAssignedCourses()
        {
            return _assignedCourses.ToList();
        }
        public List<Quiz> GetCreatedQuizzes()
        {
            return _quizzesCreated.ToList();
        }
        public void AddQuestion(Quiz quiz, Question question)
        {
            if (!_quizzesCreated.Contains(quiz))
            {
                throw new InvalidOperationException("Quiz not found!");
            }
            quiz.AddQuestion(question);
        }
        public void RemoveQuestion(Quiz quiz, Question question)
        {
            if (!_quizzesCreated.Contains(quiz))
            {
                throw new InvalidOperationException("Quiz not found!");
            }
            quiz.RemoveQuestion(question);
        }


    }

}
