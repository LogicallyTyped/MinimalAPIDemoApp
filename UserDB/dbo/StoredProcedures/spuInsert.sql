CREATE PROCEDURE [dbo].[spuInsert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS
begin
	INSERT INTO [dbo].[User] (FirstName, LastName)
	VALUES (@FirstName, @LastName);
end