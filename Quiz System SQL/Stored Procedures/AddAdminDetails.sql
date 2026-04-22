
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE AddAdminDetails
	@Name varchar(100) ,
	@Email varchar(100),
	@Password varchar(256) 
AS
BEGIN
	
	SET NOCOUNT ON;
	Insert into Admins (Name, Email, Password) 
	values (@Name, @Email, @Password)
END
GO
