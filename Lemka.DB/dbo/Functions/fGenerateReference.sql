CREATE FUNCTION [dbo].[fGenerateReference]
(
	@Type CHAR(5)
)
RETURNS NVARCHAR(50)
AS
BEGIN
	DECLARE 
		@Date DATE = GETDATE(), 
		@RandomInt INT, 
		@Result NVARCHAR(50)

	SET @RandomInt = (SELECT RandomInt FROM dbo.vRandomInt); 
	SET @Result = CONCAT(
		'LEM',
		'-',
		TRIM(@Type),
		SUBSTRING(CONVERT(NVARCHAR(50), @RandomInt), 1, 5),
		'-',
		SUBSTRING(CONVERT(NVARCHAR(50), REPLACE(@Date, '-', '')), 3,6)
	)
	RETURN @Result
END
