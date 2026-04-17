using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_System_OOP
{
    public enum Grade
    {
        A,//>=90
        B,//>=80
        C,//>=70
        D,//>=60
        F,//<60
        U//For new accounts with no grades
    }

    public enum Category
    {
        Math,
        Science,
        Mechanics,
        Programming,
        English,
        UnAssigned
    }

    public enum Title
    {
        Substitute,
        ClassroomTeacher,
        Specialist,
        LeadTeacher,
        DepartmentHead,
        AcademicCoordinator,
        UnAssigned
    }

    public enum Status
    {
        Assigned,
        UnAssigned
    }

    public enum QuestionType
    {
        MCQ,
        TRUEorFALSE,
        ShortAnswer,
        UnAssigned
    }

}
