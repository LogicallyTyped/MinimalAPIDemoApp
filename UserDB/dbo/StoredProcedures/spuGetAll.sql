CREATE PROCEDURE [dbo].[spuGetAll]
	@param1 int = 0,
	@param2 int
AS
BEGIN
	SELECT Id, FirstName, LastName
	FROM [dbo].[User];
END