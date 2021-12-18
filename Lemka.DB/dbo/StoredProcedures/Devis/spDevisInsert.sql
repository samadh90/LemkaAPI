CREATE PROCEDURE [dbo].[spDevisInsert]
	@DemandeDevisId INT,
	@Remarque TEXT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM dbo.Devis WHERE [DemandeDevisId] = @DemandeDevisId)
	BEGIN
		DECLARE @Numero NVARCHAR(50);
		EXEC [dbo].[spGenererNumero] N'A', @Numero OUTPUT
		INSERT INTO dbo.Devis ([Numero], [Remarque], [DemandeDevisId])
		VALUES (@Numero, @Remarque, @DemandeDevisId)

		SELECT SCOPE_IDENTITY() as 'Id'
	END
END