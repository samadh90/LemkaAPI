CREATE PROCEDURE [dbo].[spMensurationsInsert]
	@UtilisateurId INT,
	@Titre NVARCHAR(100),
	@Description TEXT,
	@IsMain BIT
AS
BEGIN
	DECLARE @MensurationId INT, @MesureId INT;

	INSERT INTO dbo.Mensurations ([UtilisateurId], [Titre], [Description], [IsMain])
	VALUES (@UtilisateurId, @Titre, @Description, @IsMain)

	SET @MensurationId = SCOPE_IDENTITY()

	-- TODO - Récupérer chaque mesure et l'ajouter avec une valeur 0

	DECLARE CR_Mesures CURSOR FAST_FORWARD FOR SELECT [Id] FROM dbo.Mesures

	OPEN CR_Mesures

	FETCH NEXT FROM CR_Mesures INTO @MesureId

	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF NOT EXISTS (SELECT TOP 1 * FROM dbo.MensurationMesures WHERE MensurationId = @MensurationId AND MesureId = @MesureId)
		BEGIN
			INSERT INTO dbo.MensurationMesures (MensurationId, MesureId) VALUES (@MensurationId, @MesureId)
		END
		
		FETCH NEXT FROM CR_Mesures INTO @MesureId
	END

	CLOSE CR_Mesures;

	DEALLOCATE CR_Mesures;

	SELECT @MensurationId as 'Id'
END
