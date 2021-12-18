﻿CREATE TABLE [dbo].[Images]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[ProduitId] INT NOT NULL,
	[Image] NVARCHAR(255) NOT NULL,

	FOREIGN KEY ([ProduitId]) REFERENCES Produits(Id)
)