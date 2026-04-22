
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION GetAllEnrolledStudents
(	
	@CourseID int
)
RETURNS TABLE 
AS
RETURN 
(
	Select S.Name, C.CourseName from Enrollments e 
	inner join Students s
	on s.StudentID = e.StudentID 
	inner join Courses C 
	on c.CourseID = e.CourseID
	where e.CourseID = @CourseID
)
GO
