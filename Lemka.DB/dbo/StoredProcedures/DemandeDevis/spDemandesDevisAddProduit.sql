CREATE PROCEDURE [dbo].[spDemandesDevisAddProduit]
	@DemandeDevisId INT,
	@ProduitId INT
AS
BEGIN
	DECLARE
	
	@CountDDP INT,
	@CountP INT

	SELECT @CountDDP = COUNT(*) FROM dbo.[DemandeDevis] WHERE [Id] = @DemandeDevisId AND [SubmittedAt] IS NOT NULL;
	SELECT @CountP = COUNT(*) FROM dbo.[vProduits] WHERE [Id] = @ProduitId AND [Statut] NOT LIKE 'Inactive';

	IF @CountDDP != 0 AND @CountP !=0
	BEGIN
		IF NOT EXISTS (SELECT TOP 1 * FROM dbo.[DemandeDevisProduits] WHERE [DemandeDevisId] = @DemandeDevisId AND [ProduitId] = @ProduitId)
		BEGIN
			INSERT INTO dbo.[DemandeDevisProduits] ([DemandeDevisId], [ProduitId]) VALUES (@DemandeDevisId, @ProduitId)
		END
	END
END