CREATE PROCEDURE [dbo].[spDemandesDevisGetOneOrAll]
	@Id INT,
	@UtilisateurId INT
AS
BEGIN
	IF (@Id IS NOT NULL AND @UtilisateurId IS NULL)
	BEGIN
		SELECT 
			dd.*,
			CASE
				WHEN dd.[SubmittedAt] IS NULL THEN NULL
				WHEN dd.[SubmittedAt] IS NOT NULL AND (SELECT COUNT(*) FROM dbo.Devis WHERE [Id] = dd.[Id]) = 0 THEN NULL
				WHEN dd.[SubmittedAt] IS NOT NULL AND (SELECT COUNT(*) FROM dbo.Devis WHERE [Id] = dd.[Id]) = 1 AND (SELECT [SubmittedAt] FROM dbo.Devis WHERE [Id] = dd.[Id]) IS NULL THEN 0
				WHEN dd.[SubmittedAt] IS NOT NULL AND (SELECT COUNT(*) FROM dbo.Devis WHERE [Id] = dd.[Id]) = 1 AND (SELECT [SubmittedAt] FROM dbo.Devis WHERE [Id] = dd.[Id]) IS NOT NULL THEN 1
			END as 'DevisStatut',
			IIF((SELECT COUNT(*) FROM dbo.Devis WHERE [Id] = dd.[Id]) = 1, (SELECT [EstAccepte] FROM dbo.Devis WHERE [Id] = dd.[Id]), NULL) as 'DevisDecision'
		FROM dbo.DemandeDevis dd
		WHERE dd.[Id] = @Id
	END

	ELSE IF (@UtilisateurId IS NOT NULL AND @Id IS NULL)
	BEGIN
		SELECT 
			dd.*,
			CASE
				WHEN dd.[SubmittedAt] IS NULL THEN NULL
				WHEN dd.[SubmittedAt] IS NOT NULL AND (SELECT COUNT(*) FROM dbo.Devis WHERE [Id] = dd.[Id]) = 0 THEN NULL
				WHEN dd.[SubmittedAt] IS NOT NULL AND (SELECT COUNT(*) FROM dbo.Devis WHERE [Id] = dd.[Id]) = 1 AND (SELECT [SubmittedAt] FROM dbo.Devis WHERE [Id] = dd.[Id]) IS NULL THEN 0
				WHEN dd.[SubmittedAt] IS NOT NULL AND (SELECT COUNT(*) FROM dbo.Devis WHERE [Id] = dd.[Id]) = 1 AND (SELECT [SubmittedAt] FROM dbo.Devis WHERE [Id] = dd.[Id]) IS NOT NULL THEN 1
			END as 'DevisStatut',
			IIF((SELECT COUNT(*) FROM dbo.Devis WHERE [Id] = dd.[Id]) = 1, (SELECT [EstAccepte] FROM dbo.Devis WHERE [Id] = dd.[Id]), NULL) as 'DevisDecision'
		FROM dbo.DemandeDevis dd
		WHERE dd.[UtilisateurId] = @UtilisateurId
	END

	ELSE
	BEGIN
		SELECT 
			dd.*,
			CASE
				WHEN dd.[SubmittedAt] IS NULL THEN NULL
				WHEN dd.[SubmittedAt] IS NOT NULL AND (SELECT COUNT(*) FROM dbo.Devis WHERE [Id] = dd.[Id]) = 0 THEN NULL
				WHEN dd.[SubmittedAt] IS NOT NULL AND (SELECT COUNT(*) FROM dbo.Devis WHERE [Id] = dd.[Id]) = 1 AND (SELECT [SubmittedAt] FROM dbo.Devis WHERE [Id] = dd.[Id]) IS NULL THEN 0
				WHEN dd.[SubmittedAt] IS NOT NULL AND (SELECT COUNT(*) FROM dbo.Devis WHERE [Id] = dd.[Id]) = 1 AND (SELECT [SubmittedAt] FROM dbo.Devis WHERE [Id] = dd.[Id]) IS NOT NULL THEN 1
			END as 'DevisStatut',
			IIF((SELECT COUNT(*) FROM dbo.Devis WHERE [Id] = dd.[Id]) = 1, (SELECT [EstAccepte] FROM dbo.Devis WHERE [Id] = dd.[Id]), NULL) as 'DevisDecision'
		FROM dbo.DemandeDevis dd
	END
END