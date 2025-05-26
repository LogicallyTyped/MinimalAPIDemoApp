CREATE PROCEDURE [dbo].[spuDelete]
	@Id int
AS
begin
	DELETE FROM [dbo].[User]
	WHERE Id = @Id;
end