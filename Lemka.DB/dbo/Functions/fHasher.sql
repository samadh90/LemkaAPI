CREATE FUNCTION [dbo].[fHasher]
(
	@password NVARCHAR(128),
	@securityStamp UNIQUEIDENTIFIER
)
RETURNS BINARY(64)
AS
BEGIN
	DECLARE 
		@hashedValue BINARY(64)

	SET @hashedValue = CONVERT(BINARY(64), CONCAT(HASHBYTES('SHA2_512', (@password + CAST(@securityStamp AS NVARCHAR(36)))), @securityStamp))

	RETURN @hashedvalue
END