
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION GetStudentsCourse
(	
	@CourseID int
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT (Select Name from Students where Students.StudentID = Enrollments.StudentID) as StudentName, 
	(Select CourseName from Courses where Courses.CourseID = Enrollments.CourseID) as CourseName
	from Enrollments where Enrollments.CourseID = @CourseID
)
GO
