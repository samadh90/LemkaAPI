CREATE PROCEDURE [dbo].[spMesuresInsert]
	@Nom VARCHAR(100),
	@Description TEXT,
	@Image NVARCHAR(255)
AS
BEGIN
	DECLARE @MensurationId INT
	DECLARE @MesureId INT
	
	INSERT INTO dbo.Mesures ([Nom], [Description], [Image]) VALUES (@Nom, @Description, @Image)

	SET @MesureId = SCOPE_IDENTITY()

	DECLARE CR_Mensurations CURSOR FAST_FORWARD FOR
	SELECT [Id] FROM dbo.Mensurations

	OPEN CR_Mensurations
	FETCH NEXT FROM CR_Mensurations INTO @MensurationId
	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF NOT EXISTS (SELECT TOP 1 * FROM dbo.MensurationMesures WHERE MensurationId = @MensurationId AND MesureId = @MesureId)
		BEGIN
			INSERT INTO dbo.MensurationMesures (MensurationId, MesureId) VALUES (@MensurationId, @MesureId)
		END
		FETCH NEXT FROM CR_Mensurations INTO @MensurationId
	END
	CLOSE CR_Mensurations;
	DEALLOCATE CR_Mensurations;

	SELECT @MesureId as 'Id'
END