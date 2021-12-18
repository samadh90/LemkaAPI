CREATE PROCEDURE [dbo].[spGenererNumero]
	@Type CHAR(5) = 'Q',
	@Output NVARCHAR(50) OUTPUT
AS
BEGIN
	DECLARE @Date DATE = GETDATE(), @RandomInt INT, @Result NVARCHAR(50);
	SET @RandomInt = ABS(CAST(CAST(NEWID() AS VARBINARY) AS INT))
	SET @Result = CONCAT(
		'LEM',
		'-',
		TRIM(@Type),
		SUBSTRING(convert(NVARCHAR(50), @RandomInt), 1, 5),
		'-',
		SUBSTRING(CONVERT(NVARCHAR(50), REPLACE(@Date, '-', '')), 3,6)
	)
	SELECT @Output = @Result
END
