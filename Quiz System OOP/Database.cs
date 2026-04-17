using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public class Database
    {
        private List<Student> _allStudents;
        private List<Teacher> _allTeachers;
        private List<Course> _allCourses;
        private List<Admin> _admins = new List<Admin>(){new Admin("Admin1@gmail.com", "Admin123", "Admin A"),
                                                        new Admin("Admin2@gmail.com", "Admin123", "Admin B"),
                                                        new Admin("Admin3@gmail.com", "Admin123", "Admin C") };
        public Database()
        {
            _allStudents = new List<Student>();
            _allTeachers = new List<Teacher>();
            _allCourses = new List<Course>();
        }

        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new InvalidDataException("Course is empty!");
            }
            _allCourses.Add(course);
        }
        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new InvalidDataException("Student is empty!");
            }
            _allStudents.Add(student);
        }
        public void AddTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new InvalidDataException("Teacher is empty!");
            }
            _allTeachers.Add(teacher);
        }
        public List<Student> GetAllStudents()
        {
            return _allStudents.ToList();
        }
        public List<Teacher> GetAllTeachers()
        {
            return _allTeachers.ToList();
        }
        public List<Course> GetAllCourses()
        {
            return _allCourses.ToList();
        }
        public List<Admin> GetAdmins()
        {
            return _admins.ToList();
        }
    }

}
