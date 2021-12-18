CREATE PROCEDURE [dbo].[spMensurationMesuresGetAll]
	@MensurationId int
AS
BEGIN
	SELECT
		m.[Id],
		m.[Nom],
		m.[Description],
		m.[Image],
		mm.[Valeur]
	FROM dbo.MensurationMesures mm
	INNER JOIN dbo.Mesures m ON mm.[MesureId] = m.[Id]
	WHERE mm.[MensurationId] = @MensurationId
END