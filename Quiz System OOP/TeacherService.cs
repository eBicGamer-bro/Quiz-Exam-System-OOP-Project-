using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public class TeacherService : Service
    {
        private Teacher _teacher;
        public TeacherService(Database database) : base(database)
        {
        }
        public void AddCourse(Course course)
        {
            if (_teacher == null)
            {
                throw new InvalidOperationException("Teacher Service is not attached to a Teacher!");
            }
            if (course == null)
            {
                throw new InvalidDataException("Course is Empty!");
            }
            if (course.Status == Status.Assigned)
            {
                throw new InvalidOperationException("Course Already Assigned to Another Teacher!");
            }
            course.SetAssign();
            course.Teacher = _teacher;
            _teacher.AddCourse(course);
        }
        public void AddQuiz(Quiz quiz, Course course)
        {
            if (_teacher == null)
            {
                throw new InvalidOperationException("Teacher Service is not attached to a Teacher!");
            }
            if (quiz == null)
            {
                throw new InvalidDataException("Quiz is empty!");
            }
            if (course == null)
            {
                throw new InvalidDataException("Course is empty!");
            }
            _teacher.AddQuiz(quiz);
            course.AddQuiz(quiz);
        }
        public bool RemoveCourse(Course course)
        {
            if (_teacher == null)
            {
                throw new InvalidOperationException("Teacher Service is not attached to a Teacher!");
            }
            if (!_teacher.GetAssignedCourses().Contains(course))
            {
                throw new InvalidOperationException($"This course is not attached to {this._teacher.Name}!");
            }
            if (course.GetEnrolledStudents().Count > 0)
            {
                return false;
            }
            _teacher.RemoveCourse(course);
            course.SetUnAssign();
            return true;
        }
        public void AddQuestion(Quiz quiz, Question question)
        {
            if (_teacher == null)
            {
                throw new InvalidOperationException("Teacher Service is not attached to a Teacher!");
            }
            if (quiz == null)
            {
                throw new InvalidDataException("Quiz is empty!");
            }
            if (question == null)
            {
                throw new InvalidDataException("Question is empty!");
            }
            if (!_teacher.GetCreatedQuizzes().Contains(quiz))
            {
                throw new InvalidOperationException($"This quiz is not attached to {this._teacher.Name}!");

            }
            _teacher.AddQuestion(quiz, question);
        }
        public void RemoveQuestion(Quiz quiz, Question question)
        {
            if (_teacher == null)
            {
                throw new InvalidOperationException("Teacher Service is not attached to a Teacher!");
            }
            if (quiz == null)
            {
                throw new InvalidDataException("Quiz is empty!");
            }
            if (question == null)
            {
                throw new InvalidDataException("Question is empty!");
            }
            if (!_teacher.GetCreatedQuizzes().Contains(quiz))
            {
                throw new InvalidOperationException($"This quiz is not attached to {this._teacher.Name}!");

            }
            _teacher.RemoveQuestion(quiz, question);
        }
        public void SetTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new InvalidDataException("Teacher is empty!");

            }
            if (!database.GetAllTeachers().Contains(teacher))
            {
                throw new InvalidOperationException("Teacher Does not exist");
            }
            _teacher = teacher;
        }
        public List<Course> GetAssignedCourses()
        {
            return _teacher.GetAssignedCourses();
        }
        public List<Quiz> GetCreatedQuizzes()
        {
            return _teacher.GetCreatedQuizzes();
        }
        public void AddTeacher(Teacher teacher)
        {
            database.AddTeacher(teacher);
        }
        public List<Teacher> GetTeachers()
        {
            return database.GetAllTeachers();
        }
    }

}
