CREATE TABLE [dbo].[Adresses]
(
	[UtilisateurId] INT PRIMARY KEY NOT NULL,
	[Pays] NVARCHAR(100) NOT NULL,
	[Ville] NVARCHAR(100) NOT NULL,
	[CodePostal] NVARCHAR(100) NOT NULL,
	[Rue] NVARCHAR (255) NOT NULL,
	[Numero] NVARCHAR(50) NOT NULL,
	[Boite] NVARCHAR(50) NULL,

	CONSTRAINT [FK_Adresses_Utilisateur] FOREIGN KEY ([UtilisateurId]) REFERENCES Utilisateurs([Id]),
    CONSTRAINT [CK_Adresses_Numero] CHECK (LEN(LTRIM([Numero])) > 1)
)
