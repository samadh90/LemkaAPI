CREATE PROCEDURE [dbo].[spDevisInsert]
	@DemandeDevisId INT,
	@Remarque TEXT,
	@ExpiresInDays INT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM dbo.Devis WHERE [DemandeDevisId] = @DemandeDevisId)
	BEGIN
		DECLARE @Reference NVARCHAR(50) = dbo.fGenerateReference('A')
		INSERT INTO dbo.Devis ([DemandeDevisId], [Reference], [Remarque], [ExpiresInDays])
		VALUES (@DemandeDevisId, @Reference, @Remarque, @ExpiresInDays)

		SELECT SCOPE_IDENTITY() as 'Id'
	END
END