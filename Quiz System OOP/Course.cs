using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public class Course
    {
        public string Name { private set; get; }
        public TimeSpan Duration { private set; get; }
        public Admin Admin { private set; get; }
        private Teacher _teacher;
        public Status Status { private set; get; }
        public Category Category { private set; get; }
        private List<Student> _enrolledStudents;
        private List<Quiz> _quizzes;
        public int NumberofLessons { private set; get; }
        public Course(string Name, TimeSpan Duration, Admin Admin, Category Category, int NumberofLessons)
        {
            if (!Validation.General(Name))
            {
                throw new InvalidDataException("Invalid Course Name");
            }
            if (Duration <= TimeSpan.Zero)
            {
                throw new InvalidDataException("Invalid Course Duration");
            }
            if (NumberofLessons <= 0)
            {
                throw new InvalidDataException("Invalid Number of Lessons");
            }
            this.Name = Name;
            this.Admin = Admin;
            this.Duration = Duration;
            this.Category = Category;
            this.Status = Status.UnAssigned;
            this._enrolledStudents = new List<Student>();
            this._quizzes = new List<Quiz>();
            this.NumberofLessons = NumberofLessons;
        }
        public Teacher Teacher
        {
            set
            {
                if (value == null)
                    throw new InvalidDataException("Teacher is empty!");
                _teacher = value;
            }
            get
            {
                if (_teacher == null || Status == Status.UnAssigned)
                {
                    throw new InvalidOperationException("There is no teacher assigned for this course!");
                }
                return _teacher;
            }
        }
        public void AddQuiz(Quiz quiz)
        {
            if (_quizzes.Contains(quiz))
            {
                throw new InvalidOperationException("Quiz Already Exists in this course!");
            }
            _quizzes.Add(quiz);
        }
        public void AddStudent(Student student)
        {
            _enrolledStudents.Add(student);
        }
        public void SetAssign()
        {
            if (Status == Status.Assigned)
            {
                throw new InvalidOperationException("Status Already Assigned!");
            }
            Status = Status.Assigned;
        }
        public void SetUnAssign()
        {
            if (Status == Status.UnAssigned)
            {
                throw new InvalidOperationException("Status Already UnAssigned!");
            }
            Status = Status.UnAssigned;
        }
        public List<Student> GetEnrolledStudents()
        {
            return _enrolledStudents.ToList();
        }
        public List<Quiz> GetQuizzes()
        {
            return _quizzes.ToList();
        }
    }

}
