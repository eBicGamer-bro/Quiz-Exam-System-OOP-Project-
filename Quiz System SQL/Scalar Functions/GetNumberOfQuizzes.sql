
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION GetNumberOfQuizzesForCourse
(
	@CourseID int
)
RETURNS int
AS
BEGIN
Declare @NumberOfQuizzes int
SELECT @NumberOfQuizzes = COUNT(CourseID) from Quizzes where CourseID = @CourseID
RETURN @NumberOfQuizzes
END
GO

