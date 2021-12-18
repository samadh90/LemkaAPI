CREATE FUNCTION [dbo].[fSlugify]
(
	@string  NVARCHAR(MAX)
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    DECLARE @out VARCHAR(MAX)
  
    --convert to ASCII
    SET @out = LOWER(@string COLLATE SQL_Latin1_General_CP1251_CS_AS)

    DECLARE @pi INT
    --I'm sorry T-SQL have no regex. Thanks for patindex, MS .. :-)  
    SET @pi = patindex('%[^a-z0-9 -]%',@out) 
    WHILE @pi>0
    BEGIN
        SET @out = REPLACE(@out, SUBSTRING(@out,@pi,1), '') 
        --set @out = left(@out,@pi-1) + substring(@out,@pi+1,8000) 
        SET @pi = PATINDEX('%[^a-z0-9 -]%',@out) 
    END
 
    SET @out = LTRIM(RTRIM(@out)) 
 
    -- replace space to hyphen
    SET @out = REPLACE(@out, ' ', '-') 
 
    -- remove double hyphen
    WHILE CHARINDEX('--', @out) > 0 SET @out = REPLACE(@out, '--', '-')  
      
    RETURN (@out)
END
