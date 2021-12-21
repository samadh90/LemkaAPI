CREATE PROCEDURE [dbo].[spDemandesDevisDelete]
	@Id INT
AS
BEGIN
	IF EXISTS (SELECT TOP 1 * FROM dbo.DemandeDevis WHERE [Id] = @Id)
	BEGIN
		IF ((SELECT [submittedAt] FROM dbo.DemandesDevis WHERE [Id] = @Id) IS NULL)
		BEGIN
			DELETE FROM dbo.DemandeDevis WHERE [Id] = @Id
		END
	END
END