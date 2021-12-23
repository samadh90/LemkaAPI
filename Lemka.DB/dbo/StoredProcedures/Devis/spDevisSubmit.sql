CREATE PROCEDURE [dbo].[spDevisSubmit]
	@DemandeDevisId INT
AS
BEGIN
	IF EXISTS (SELECT TOP 1 * FROM dbo.[Devis] WHERE [DemandeDevisId] = @DemandeDevisId)
	BEGIN
		UPDATE dbo.[Devis] SET [SubmittedAt] = GETDATE() WHERE [DemandeDevisId] = @DemandeDevisId
	END
END