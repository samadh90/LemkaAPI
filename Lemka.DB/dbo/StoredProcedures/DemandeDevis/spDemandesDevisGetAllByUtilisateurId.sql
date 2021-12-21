CREATE PROCEDURE [dbo].[spDemandesDevisGetAllByUtilisateurId]
	@UtilisateurId INT
AS
BEGIN
    SELECT * 
    INTO #TempDemandesDevis
    FROM dbo.[vDemandeDevis]
    WHERE [UtilisateurId] = @UtilisateurId

    ALTER TABLE #TempDemandesDevis
    DROP COLUMN UtilisateurId

    SELECT * FROM #TempDemandesDevis

    DROP TABLE #TempDemandesDevis
END