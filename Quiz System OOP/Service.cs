using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public class Service
    {
        protected Database database;
        public Service(Database database)
        {
            this.database = database;
        }
        public List<Course> GetAllCourses()
        {
            return database.GetAllCourses();
        }
    }

}
