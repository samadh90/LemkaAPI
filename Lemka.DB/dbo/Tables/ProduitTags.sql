CREATE TABLE [dbo].[ProduitTags]
(
	[ProduitId] INT NOT NULL,
	[TagId] INT NOT NULL,

	PRIMARY KEY ([ProduitId], [TagId]),
	FOREIGN KEY ([ProduitId]) REFERENCES Produits(Id),
	FOREIGN KEY (TagId) REFERENCES Tags(Id)
)
