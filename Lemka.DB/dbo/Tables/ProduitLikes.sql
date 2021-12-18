CREATE TABLE [dbo].[ProduitLikes]
(
	[ProduitId] INT NOT NULL,
	[UtilisateurId] INT NOT NULL,
	[CreatedAt] DATETIME2(0) NOT NULL DEFAULT GETDATE(),

	PRIMARY KEY ([ProduitId], [UtilisateurId]),
	FOREIGN KEY ([ProduitId]) REFERENCES Produits([Id]),
	FOREIGN KEY ([UtilisateurId]) REFERENCES Utilisateurs([Id])
)
