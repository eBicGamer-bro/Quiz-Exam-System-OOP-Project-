
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION GetAllQuestions
(	
	@QuizID int
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT * from Questions where QuizID = @QuizID
)
GO
