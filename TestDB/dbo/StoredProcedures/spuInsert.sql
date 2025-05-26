CREATE PROCEDURE [dbo].[spuInsert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS
BEGIN
	INSERT INTO DBO.[User] (FirstName, LastName)
	VALUES (@FirstName, @LastName);
END