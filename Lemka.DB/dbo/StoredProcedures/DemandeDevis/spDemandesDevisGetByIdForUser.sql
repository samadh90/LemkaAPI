CREATE PROCEDURE [dbo].[spDemandesDevisGetByIdForUser]
	@Id INT
AS
BEGIN
	SELECT * INTO #TempDemandesDevis
	FROM dbo.[vDemandeDevis]
	WHERE [Id] = @Id

	ALTER TABLE #TempDemandesDevis
	DROP COLUMN UtilisateurId

	SELECT * FROM #TempDemandesDevis

	DROP TABLE #TempDemandesDevis
END