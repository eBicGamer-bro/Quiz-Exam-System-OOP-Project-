Select c.CourseName ,t.name, c.category from Courses c 
left join Teachers t 
on c.TeacherID = t.TeacherID

Select quz.QuizName , COUNT(qus.QuestionID) as NumberOfQuestions from Quizzes quz 
left join Questions qus 
on quz.QuizID = qus.QuizID 
Group by quz.QuizID, quz.QuizName

select * from GetAllQuestions(3)

select * from GetAllEnrolledStudents(1) --This is the same as GetStudentsCourse

select * from GetStudentsCourse(1)

select [dbo].[GetNumberOfQuizzesForCourse](7) as NumberOfQuizzes

Select * from Courses c 
left join Teachers t 
on c.TeacherID = t.TeacherID

exec UpdateDuration @CourseID = 1, @NewDuration = 40

exec DeleteQuiz @QuizID = 20

Select AVG(QuizDuration) as AverageDuration from Quizzes

Select QuizID, AVG(Score) as AverageScore from QuizAttempts Group by QuizID

SELECT 
    (SELECT Name FROM Students WHERE Students.StudentID = StudentAnswer.StudentID) AS StudentName,
    
    Answer AS StudentAnswer,
    
    (SELECT Answer FROM Questions WHERE Questions.QuestionID = StudentAnswer.QuestionID) AS CorrectAnswer,
    
    (SELECT Score FROM QuizAttempts 
     WHERE QuizAttempts.StudentID = StudentAnswer.StudentID 
     AND QuizAttempts.QuizID = (SELECT QuizID FROM Questions WHERE Questions.QuestionID = StudentAnswer.QuestionID)) AS Score

FROM StudentAnswer

Select * from Courses where (select count(StudentID) from Enrollments where Enrollments.CourseID = Courses.CourseID) > 5

Select * from Courses where exists (select QuizID from Quizzes where Quizzes.CourseID = Courses.CourseID)

/*Create table AdminDetails --I didn't know if Add Admin Details means to create a new Table with a 1:1 relationship with Admin or create a new Procedure to add a new Admin or Add Details coloum so I did all three.
(
    AdminID int primary key,
    Age int not null check (Age > 18 and Age < 65),
    Address varchar(255) not null,
)

Alter table Admins
Add Age int check (Age > 18 and Age < 65),
Address varchar(255)

exec AddAdminDetails @Name = 'AdminU', @Email = 'Admin21@gmail.com', @Password = 'AdminU123'*/

select * from GenerateReport(7)






