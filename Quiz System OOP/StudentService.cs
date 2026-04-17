using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public class StudentService : Service
    {
        private Student _student;
        public StudentService(Database database) : base(database)
        {
        }

        public bool Enroll(Course course)
        {
            if (_student == null)
            {
                throw new InvalidOperationException("Student Service is not attached to a Student!");
            }
            if (course == null)
            {
                throw new InvalidDataException("Course is null");
            }
            if (course.Status == Status.UnAssigned)
            {
                return false;
            }
            _student.AddCourse(course);
            course.AddStudent(_student);
            return true;
        }
        public void UpdateGrade(int score, int QuizzesTaken)
        {
            if (_student == null)
            {
                throw new InvalidOperationException("Student Service is not attached to a Student!");
            }
            if (score < 0)
            {
                throw new InvalidDataException("Score can't be less than zero");
            }
            if (QuizzesTaken <= 0)
            {
                throw new InvalidDataException("Number of Quizzes Taken can't be zero or less");
            }
            _student.AddToTotal(score);
            var finalScore = (_student.TotalScore) / QuizzesTaken;
            if (finalScore >= 90)
                _student.Grade = Grade.A;
            else if (finalScore >= 80)
                _student.Grade = Grade.B;
            else if (finalScore >= 70)
                _student.Grade = Grade.C;
            else if (finalScore >= 60)
                _student.Grade = Grade.D;
            else
                _student.Grade = Grade.F;
        }
        public int CalculateScore(Quiz quiz, List<string> choices)
        {
            if (_student == null)
            {
                throw new InvalidOperationException("Student Service is not attached to a Student!");
            }
            int score = 0;
            List<Question> questions = quiz.GetQuestions();
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].Answer.ToLower().Trim() == choices[i].Trim().ToLower())
                {
                    score++;
                }
            }
            return (100 * score / questions.Count);
        }

        public void AddResult(Quiz quiz, QuizResult result)
        {
            if (quiz == null)
            {
                throw new InvalidDataException("Quiz is null");
            }
            if (result == null)
            {
                throw new InvalidDataException("Result is null");
            }
            if (_student.GetQuizzesTaken().ContainsKey(quiz))
            {
                throw new InvalidOperationException("This quiz already exists");
            }
            _student.AddQuiz(quiz, result);
            quiz.AddStudentScore(this._student, result.score);
        }

        public void SetStudent(Student student)
        {
            if (student == null)
            {
                throw new InvalidDataException("Student is empty!");

            }
            if (!database.GetAllStudents().Contains(student))
            {
                throw new InvalidOperationException("Student Does not exist");
            }
            _student = student;
        }
        public List<Student> GetStudents()
        {
            return database.GetAllStudents();
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new InvalidDataException("Student can't be null");
            }
            database.AddStudent(student);
        }

        public Dictionary<Quiz, QuizResult> GetTakenQuizzes()
        {
            return _student.GetQuizzesTaken();
        }

        public List<Course> GetEnrolledCourses()
        {
            return _student.GetEnrolledCourses();
        }

        public bool CheckQuizTaken(Quiz quiz)
        {
            if (_student.GetQuizzesTaken().Keys.Contains(quiz))
            {
                return true;
            }
            return false;
        }
    }

}
