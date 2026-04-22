SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE DeleteQuiz
	@QuizID int 

AS
BEGIN
	SET NOCOUNT ON;

    Begin Transaction;
	If @QuizID not in (select QuizID from QuizAttempts where QuizID = @QuizID)
	Begin

	delete from Choices where QuestionID in (select QuestionID from Questions where QuizID = @QuizID)

	delete from Questions where QuizID = @QuizID

	delete from Quizzes where QuizID = @QuizID

	end

	If @@ERROR <> 0
	Begin
		Rollback Transaction;
	End
	else
	Begin
		Commit Transaction;
	End
END
GO
