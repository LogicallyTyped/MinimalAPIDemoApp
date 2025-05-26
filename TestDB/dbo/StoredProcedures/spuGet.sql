CREATE PROCEDURE [dbo].[spuGet]
	@Id int
AS
BEGIN
	SELECT *
	FROM dbo.[User]
	WHERE Id = @Id;
END