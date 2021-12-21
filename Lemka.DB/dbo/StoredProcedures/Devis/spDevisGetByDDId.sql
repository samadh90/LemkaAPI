CREATE PROCEDURE [dbo].[spDevisGetByDDId]
	@DemandeDevisId INT
AS
BEGIN
	IF EXISTS (SELECT TOP 1 * FROM dbo.Devis WHERE [DemandeDevisId] = @DemandeDevisId)
	BEGIN
		SELECT 
			ds.[Id],
			ds.[Reference],
			ds.[Remarque],
			(
				SELECT SUM(cast(round((d.Quantite * d.PrixUHt * d.Tva), 2) AS NUMERIC(36,2)))
				FROM dbo.Details d WHERE d.[DevisId] = ds.[Id]
			) AS TotalTva,
			(
				SELECT SUM(d.Quantite * d.PrixUHt) FROM dbo.Details d WHERE d.[DevisId] = ds.[Id]
			) AS TotalHT,
			(
				(SELECT SUM(cast(round((d.Quantite * d.PrixUHt * d.Tva), 2) AS NUMERIC(36,2))) FROM dbo.Details d WHERE d.[DevisId] = ds.[Id])
				+
				(SELECT SUM(d.Quantite * d.PrixUHt) FROM dbo.Details d WHERE d.[DevisId] = ds.[Id])
			) AS 'TotalTTC',
			ds.[EstAccepte],
			ds.[CreatedAt],
			ds.[SubmittedAt]
		FROM dbo.Devis ds
		WHERE ds.[DemandeDevisId] = @DemandeDevisId
	END
END