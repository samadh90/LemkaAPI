CREATE PROCEDURE [dbo].[spDevisUpdate]
	@DemandeDevisId INT,
	@Remarque TEXT,
	@ExpiresInDays INT
AS
BEGIN
	IF EXISTS (SELECT TOP 1 * FROM dbo.[Devis] WHERE [DemandeDevisId] = @DemandeDevisId)
	BEGIN
		IF (SELECT [SubmittedAt] FROM dbo.[Devis] WHERE [DemandeDevisId] = @DemandeDevisId) IS NOT NULL
		BEGIN
			UPDATE dbo.[Devis]
			SET [Remarque] = @Remarque, [ExpiresInDays] = @ExpiresInDays
			WHERE [DemandeDevisId] = @DemandeDevisId
		END
	END
END