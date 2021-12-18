CREATE TABLE [dbo].[Mensurations]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[UtilisateurId] INT NOT NULL,
	[Titre] NVARCHAR(128) NOT NULL,
	[Description] TEXT NULL,
	[IsMain] BIT NOT NULL DEFAULT 0,

	FOREIGN KEY (UtilisateurId) REFERENCES Utilisateurs(Id)
)
