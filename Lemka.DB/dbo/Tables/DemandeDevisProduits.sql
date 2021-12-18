CREATE TABLE [dbo].[DemandeDevisProduits]
(
	[DemandeDevisId] INT NOT NULL,
	[ProduitId] INT NOT NULL,

	PRIMARY KEY (DemandeDevisId, [ProduitId]),
	FOREIGN KEY (DemandeDevisId) REFERENCES DemandeDevis(Id),
	FOREIGN KEY ([ProduitId]) REFERENCES Produits(Id)
)
