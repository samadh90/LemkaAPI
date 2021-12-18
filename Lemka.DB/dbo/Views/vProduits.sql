CREATE VIEW [dbo].[vProduits]
AS

SELECT 
	p.*,
	(
		SELECT TOP 1 t.[Id]
		FROM dbo.ProduitTvas pt
		INNER JOIN dbo.Tvas t ON pt.[TvaId] = t.[Id]
		WHERE pt.[EndedAt] IS NULL AND pt.[ProduitId] = p.[Id]
	) as 'TvaId',
	(
		SELECT TOP 1 [Montant]
		FROM dbo.Prix
		WHERE [EndedAt] IS NULL AND [ProduitId] = p.[Id]
	) as 'Prix',
	(
		SELECT TOP 1 s.[Nom]
		FROM dbo.ProduitStatuts ps
		INNER JOIN dbo.Statuts s ON ps.StatutId = s.[Id]
		WHERE ps.[EndedAt] IS NULL AND ps.ProduitId = p.[Id]
	) as 'Statut',
	(
		SELECT TOP 1 [Image] 
		FROM dbo.Images 
		WHERE [ProduitId] = p.[Id] 
		ORDER BY [Id]
	) as 'Image'
FROM dbo.Produits p
