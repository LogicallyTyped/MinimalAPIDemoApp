CREATE PROCEDURE [dbo].[spuDelete]
	@Id int
AS
BEGIN
	DELETE
	FROM DBO.[User]
	WHERE Id = @Id;
END