CREATE VIEW [dbo].[vProduits]
AS
SELECT 
	p.*,
	CAST(t.[Taux] AS DECIMAL(9,2)) AS 'Tva',
	CAST(px.Montant AS DECIMAL(9,2)) AS 'Prix',
	px.[IsPromotion],
	ps.[Nom] AS 'Statut',
	i.[Image]
FROM dbo.[Produits] p
LEFT JOIN (
	SELECT TOP 1 * 
	FROM dbo.[Images] i 
	ORDER BY i.[Id]
) AS i ON i.[ProduitId] = p.[Id]
LEFT JOIN (
	SELECT ps.[Id], ps.[ProduitId], ps.[StartedAt], ps.[EndedAt], s.[Nom], s.[StatutPour]
	FROM dbo.[ProduitStatuts] ps
	INNER JOIN dbo.Statuts s ON ps.[StatutId] = s.[Id]
	WHERE ps.[EndedAt] IS NULL
) AS ps ON ps.[ProduitId] = p.[Id]
LEFT JOIN (
	SELECT *
	FROM dbo.[Prix]
	WHERE [EndedAt] IS NULL
) AS px ON px.[ProduitId] = p.[Id]
LEFT JOIN (
	SELECT pt.[Id], pt.[ProduitId], pt.[StartedAt], pt.[EndedAt], t.[Taux]
	FROM dbo.[ProduitTvas] pt
	INNER JOIN dbo.[Tvas] t ON pt.[TvaId] = t.[Id]
	WHERE pt.[EndedAt] IS NULL
) AS t ON t.[ProduitId] = p.[Id]