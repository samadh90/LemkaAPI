CREATE VIEW [dbo].[vDemandeDevis]
	AS 
SELECT 
	dd.*,
	CASE
		WHEN dd.[SubmittedAt] IS NULL THEN NULL
		WHEN dd.[SubmittedAt] IS NOT NULL AND (SELECT COUNT(*) FROM dbo.Devis WHERE [Id] = dd.[Id]) = 0 THEN NULL
		WHEN dd.[SubmittedAt] IS NOT NULL AND (SELECT COUNT(*) FROM dbo.Devis WHERE [Id] = dd.[Id]) = 1 AND (SELECT [SubmittedAt] FROM dbo.Devis WHERE [Id] = dd.[Id]) IS NULL THEN CAST(0 AS BIT)
		WHEN dd.[SubmittedAt] IS NOT NULL AND (SELECT COUNT(*) FROM dbo.Devis WHERE [Id] = dd.[Id]) = 1 AND (SELECT [SubmittedAt] FROM dbo.Devis WHERE [Id] = dd.[Id]) IS NOT NULL THEN CAST(1 AS BIT)
	END as 'DevisStatut',
	IIF(
		(SELECT COUNT(*) FROM dbo.Devis WHERE [Id] = dd.[Id]) = 1,
		CAST((SELECT [EstAccepte] FROM dbo.Devis WHERE [Id] = dd.[Id]) AS BIT),
		NULL
	) as 'DevisDecision'
FROM dbo.DemandeDevis dd