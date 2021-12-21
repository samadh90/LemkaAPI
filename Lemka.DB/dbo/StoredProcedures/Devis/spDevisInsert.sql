CREATE PROCEDURE [dbo].[spDevisInsert]
	@DemandeDevisId INT,
	@Remarque TEXT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM dbo.Devis WHERE [DemandeDevisId] = @DemandeDevisId)
	BEGIN
		DECLARE @Reference NVARCHAR(50) = dbo.fGenerateReference('A')
		INSERT INTO dbo.Devis ([Reference], [Remarque], [DemandeDevisId])
		VALUES (@Reference, @Remarque, @DemandeDevisId)

		SELECT SCOPE_IDENTITY() as 'Id'
	END
END