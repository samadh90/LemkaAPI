CREATE PROCEDURE [dbo].[spDemandesDevisGetByIdForStaff]
	@Id INT
AS
BEGIN
	SELECT * FROM dbo.vDemandeDevis WHERE [Id] = @Id
END