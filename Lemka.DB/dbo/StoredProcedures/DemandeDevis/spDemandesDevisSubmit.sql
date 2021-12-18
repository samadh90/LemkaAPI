CREATE PROCEDURE [dbo].[spDemandesDevisSubmit]
	@Id INT
AS
BEGIN
	IF EXISTS (SELECT TOP 1 * FROM dbo.DemandeDevis WHERE [Id] = @Id)
	BEGIN
		UPDATE dbo.DemandeDevis SET [SubmittedAt] = GETDATE() WHERE [Id] = @Id
	END
END