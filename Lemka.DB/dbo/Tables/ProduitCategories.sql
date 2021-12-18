CREATE TABLE [dbo].[ProduitCategories]
(
	[ProduitId] INT NOT NULL,
	[CategorieId] INT NOT NULL,

	PRIMARY KEY ([ProduitId], [CategorieId]),
	FOREIGN KEY ([ProduitId]) REFERENCES Produits([Id]),
	FOREIGN KEY ([CategorieId]) REFERENCES Categories([Id])
)
