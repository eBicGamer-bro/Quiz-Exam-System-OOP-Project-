using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public class AdminService : Service
    {
        private Admin _admin;
        public AdminService(Database database) : base(database)
        {
        }
        public bool AddCourse(Course course)
        {
            if (_admin == null)
            {
                throw new InvalidOperationException("Admin Service is not attached to an Admin!");
            }
            if (course == null)
            {
                throw new InvalidDataException("Course is empty!");
            }
            var List = database.GetAllCourses();
            foreach (var item in List)
            {
                if (Validation.MatchIgnoreCase(item.Name, course.Name))
                {
                    return false;
                }
            }
            _admin.AddCourse(course);
            database.AddCourse(course);
            return true;
        }
        public Admin Admin
        {
            set
            {
                if (value == null)
                {
                    throw new InvalidDataException("Admin is Null");
                }
                if (!database.GetAdmins().Contains(value))
                {
                    throw new InvalidOperationException("This admin does not exist");
                }
                _admin = value;
            }
            get
            {
                return _admin;
            }
        }
        public List<Admin> GetAdmins()
        {
            return database.GetAdmins();
        }
        public List<Student> GetStudents()
        {
            return database.GetAllStudents();
        }
        public List<Teacher> GetTeachers()
        {
            return database.GetAllTeachers();
        }
    }

}
