CREATE PROCEDURE [dbo].[spDetailsGetByDevisId]
	@DevisId INT
AS
BEGIN
	SELECT
		[Designation],
		[Tva],
		[Quantite],
		[PrixUHt],
		[Quantite] * [PrixUHt] as 'TotalHT'
	FROM dbo.Details WHERE [DevisId] = @DevisId
		IF EXISTS (SELECT TOP 1 * FROM dbo.Devis WHERE [Id] = @DevisId)
	BEGIN
		SELECT
			d.[Id],
			d.[Designation],
			d.[PrixUHt],
			d.[Quantite],
			d.[Tva],
			CAST(ROUND((d.Quantite * d.PrixUHt * d.Tva), 2) AS NUMERIC(36,2)) AS TotalTva,
			d.Quantite * d.PrixUHt AS TotalHT
		FROM dbo.Details d
		WHERE d.[DevisId] = @DevisId		
	END
END