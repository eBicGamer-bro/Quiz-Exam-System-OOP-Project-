SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE UpdateDuration
	@CourseID int,
	@NewDuration int
AS
BEGIN
	SET NOCOUNT ON;

	Update Courses
	SET CourseDuration = @NewDuration
	WHERE CourseID = @CourseID

END
GO
