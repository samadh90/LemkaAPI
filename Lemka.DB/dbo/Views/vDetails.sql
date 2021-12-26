CREATE VIEW [dbo].[vDetails]
	AS 
SELECT
	*,
	CAST([Quantite] * [PrixUHt] * [Tva] AS DECIMAL(36,2)) AS TotalTva,
	CAST([Quantite] * [PrixUHt] AS DECIMAL(36,2)) AS TotalHT,
	CAST([Quantite] * [PrixUHt] * [Tva] + [Quantite] * [PrixUHt] AS DECIMAL(36,2)) as TotalTTC
FROM dbo.[Details]