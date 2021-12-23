CREATE PROCEDURE [dbo].[spDevisDecision]
	@DemandeDevisId INT,
	@Decision BIT
AS
BEGIN
	IF EXISTS (SELECT TOP 1 * FROM dbo.[Devis] WHERE [DemandeDevisId] = @DemandeDevisId)
	BEGIN
		DECLARE 
			@EstArchive BIT = (SELECT [EstArchive] FROM dbo.[vDemandesDevis] WHERE [Id] = @DemandeDevisId),
			@EstAccepte BIT = (SELECT [EstAccepte] FROM dbo.[vDevis] WHERE [DemandeDevisId] = @DemandeDevisId)

		IF @EstArchive = 0 AND @EstAccepte IS NULL
		BEGIN
			UPDATE dbo.[Devis]
			SET [EstAccepte] = @Decision
			WHERE [DemandeDevisId] = @DemandeDevisId
		END
	END
END