CREATE FUNCTION [dbo].[fGenerateText] 
(
	@Length INT, 
	@Format VARCHAR(6) = 'Mixed'
)
RETURNS VARCHAR(256)
AS
BEGIN

	--	Formats:	
	--	'Proper' - proper name form (i.e. Xxxxx)
	--	'Upper'  - all uppercase (i.e. XXXXX)
	--	'Lower'  - all lowercase (i.e. xxxxx)
	--	'Mixed'  - randomly mixed case (i.e. xXxxxXXxx)
	--	 null    - randomly mixed case (i.e. xXxXxxxxxX)
	--

	DECLARE 
		@RandomValue             VARCHAR(256), 
		@Count                   integer,
		@RandomNumber            float, 
		@RandomNumberInteger     integer, 
		@CurrentCharacter        char(1),
		@ValidCharactersLength   integer,
		@ValidCharacters         varchar(255) 

	SET @RandomValue = '';

	IF (@Length = 0) 
		GOTO ReturnData


	IF (@Format = 'Mixed') 
		SET @ValidCharacters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789'; 
	ELSE
		SET @ValidCharacters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz';


	SET @ValidCharactersLength = Len(@ValidCharacters); 
	SET @CurrentCharacter      = ''; 
	SET @RandomNumber          = 0; 
	SET @RandomNumberInteger   = 0; 

	SET @Count = 1; 


	WHILE @Count <= @Length 
	BEGIN
		SET @RandomNumber = (SELECT RandomNumber FROM dbo.vRandom); 

		SET @RandomNumberInteger = Convert(INTEGER, ((@ValidCharactersLength - 1) * @RandomNumber + 1)); 
 
		SET @CurrentCharacter = SubString(@ValidCharacters, @RandomNumberInteger, 1); 

		SET @RandomValue = @RandomValue + @CurrentCharacter; 

		SET @Count = @Count + 1; 
	END


	IF @Format = 'Lower' 
		SET @RandomValue = Lower(@RandomValue); 

	IF @Format = 'Upper' 
		SET @RandomValue = Upper(@RandomValue); 

	IF @Format = 'Proper' 
		SET @RandomValue = Upper(Left(@RandomValue, 1)) + Substring(Lower(@RandomValue), 2, (@Length - 1));  

	--	... or the default  gives random `casing`, and 'Mixed' gives random alphanumeric `casing`


	ReturnData:

	RETURN @RandomValue 

END