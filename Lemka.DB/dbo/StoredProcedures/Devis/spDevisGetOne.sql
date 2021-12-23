CREATE PROCEDURE [dbo].[spDevisGetOne]
	@DemandeDevisId INT
AS
BEGIN
	IF EXISTS (SELECT TOP 1 * FROM dbo.[vDevis] WHERE [DemandeDevisId] = @DemandeDevisId)
	BEGIN
		SELECT * 
		INTO #TempDevis
		FROM dbo.[vDevis]
		WHERE [DemandeDevisId] = @DemandeDevisId

		ALTER TABLE #TempDevis
		DROP COLUMN [DemandeDevisId]
		
		SELECT * FROM #TempDevis

		DROP TABLE #TempDevis
	END
END