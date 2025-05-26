CREATE PROCEDURE [dbo].[spuUpdate]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS
Begin
	UPDATE [dbo].[User]
	SET FirstName = @FirstName, LastName = @LastName
	WHERE Id = @Id;
End