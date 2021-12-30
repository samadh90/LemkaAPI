CREATE VIEW [dbo].[vDevis]
	AS 
SELECT 
	d.*,
	ds.[TotalTva],
	ds.[TotalHT],
	ds.[TotalTTC],
	CAST(DATEADD(day, d.[ExpiresInDays], d.[SubmittedAt]) AS DATE) AS 'ExpiresAt'
FROM dbo.Devis d
LEFT JOIN (
	SELECT
		[DevisId],
		SUM([TotalTVA]) AS TotalTva,
		SUM(TotalHT) AS TotalHT,
		SUM(TotalTTC) as TotalTTC
	FROM dbo.[vDetails]
	GROUP BY [DevisId]
) AS ds ON ds.[DevisId] = d.[Id]
