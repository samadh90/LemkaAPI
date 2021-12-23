CREATE VIEW [dbo].[vDevis]
	AS 
SELECT 
	ds.*,
	(
		SELECT SUM(CAST(ROUND((d.Quantite * d.PrixUHt * d.Tva), 2) AS NUMERIC(36,2)))
		FROM dbo.Details d WHERE d.[DevisId] = ds.[Id]
	) AS TotalTva,
	(
		SELECT SUM(d.Quantite * d.PrixUHt) FROM dbo.Details d WHERE d.[DevisId] = ds.[Id]
	) AS TotalHT,
	(
		(SELECT SUM(cast(round((d.Quantite * d.PrixUHt * d.Tva), 2) AS NUMERIC(36,2))) FROM dbo.[Details] d WHERE d.[DevisId] = ds.[Id])
		+
		(SELECT SUM(d.Quantite * d.PrixUHt) FROM dbo.Details d WHERE d.[DevisId] = ds.[Id])
	) AS 'TotalTTC',
	CAST(DATEADD(day, ds.[ExpiresInDays], ds.[SubmittedAt]) AS DATE) AS 'ExpiresAt'
FROM dbo.Devis ds
