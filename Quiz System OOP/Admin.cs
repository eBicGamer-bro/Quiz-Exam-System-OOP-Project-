using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public class Admin : User
    {
        private List<Course> _coursesCreated;
        public Admin(string email, string password, string name) : base(email, password, name)
        {
            _coursesCreated = new List<Course>();
        }

        public void AddCourse(Course course)
        {
            _coursesCreated.Add(course);
        }
        public List<Course> GetCreatedCourses()
        {
            return _coursesCreated.ToList();
        }
    }

}
