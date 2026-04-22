SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION GenerateReport
(	
	@StudentID int
)
RETURNS TABLE 
AS
RETURN 
(
	Select
	(Select Name from Students where Students.StudentID = QuizAttempts.StudentID) as StudentName,
	(Select CourseName from Courses where Courses.CourseID = (Select CourseID from Quizzes where Quizzes.QuizID = QuizAttempts.QuizID)) as CourseName,
	(Select QuizName from Quizzes where Quizzes.QuizID = QuizAttempts.QuizID) as QuizName,
	score as TotalScore,
	Case 
		When score >= 50 then 'Pass'
		Else 'Fail'
	End as Result
	from QuizAttempts
	where QuizAttempts.StudentID = @StudentID
)
GO
