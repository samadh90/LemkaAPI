CREATE VIEW [dbo].[vDemandesDevis]
	AS 
SELECT 
	dd.*,
	CASE
		WHEN dd.[SubmittedAt] IS NULL THEN NULL
		WHEN dd.[SubmittedAt] IS NOT NULL AND d.[Id] IS NULL THEN NULL
		WHEN dd.[SubmittedAt] IS NOT NULL AND d.[Id] IS NOT NULL AND d.[SubmittedAt] IS NULL THEN CAST(0 AS BIT)
		WHEN dd.[SubmittedAt] IS NOT NULL AND d.[Id] IS NOT NULL AND d.[SubmittedAt] IS NOT NULL THEN CAST(1 AS BIT)
	END as 'DevisStatut',
	IIF(d.[Id] IS NOT NULL, CAST(d.[EstAccepte] AS BIT), NULL) as 'DevisDecision',
	CASE
		WHEN d.[SubmittedAt] IS NULL THEN CAST(0 AS BIT)
		WHEN d.[SubmittedAt] IS NOT NULL AND CAST(GETDATE() AS DATE) > CAST(d.[ExpiresAt] AS DATE) AND (d.[EstAccepte] = 0 OR d.[EstAccepte] IS NULL) THEN CAST(1 AS BIT)
		WHEN d.[SubmittedAt] IS NOT NULL AND CAST(GETDATE() AS DATE) < CAST(d.[ExpiresAt] AS DATE) AND d.[EstAccepte] = 0 THEN CAST(1 AS BIT)
		ELSE CAST(0 AS BIT)
	END as 'EstArchive'
FROM dbo.DemandeDevis dd
LEFT JOIN dbo.[vDevis] d ON d.[DemandeDevisId] = dd.[Id]