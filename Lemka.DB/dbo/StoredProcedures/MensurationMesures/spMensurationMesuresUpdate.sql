CREATE PROCEDURE [dbo].[spMensurationMesuresUpdate]
	@MensurationId INT,
	@MesureId INT,
	@Valeur FLOAT
AS
BEGIN
	IF EXISTS (SELECT TOP 1 * FROM dbo.MensurationMesures WHERE [MensurationId] = @MensurationId AND [MesureId] = @MesureId)
	BEGIN
		UPDATE dbo.MensurationMesures SET [Valeur] = @Valeur WHERE [MensurationId] = @MensurationId AND [MesureId] = @MesureId
	END
END