CREATE TABLE [dbo].[Details]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[DevisId] INT NOT NULL,
	[Designation] NVARCHAR(255) NOT NULL,
	[PrixUHt] DECIMAL(9, 2) NOT NULL,
	[Quantite] FLOAT NOT NULL,
	[Tva] FLOAT NOT NULL DEFAULT 0.0,

    CONSTRAINT [CK_Details_PrixUHt] CHECK (PrixUHt >= 0),
    CONSTRAINT [CK_Details_Quantite] CHECK (Quantite >= 0),
	CONSTRAINT [CK_Details_Tva]CHECK ([Tva] >= 0.0 AND [Tva] <= 1.0),
	CONSTRAINT [FK_Details_Devis] FOREIGN KEY (DevisId) REFERENCES Devis(Id)
)
