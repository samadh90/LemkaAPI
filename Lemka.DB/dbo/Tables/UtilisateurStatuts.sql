CREATE TABLE [dbo].[UtilisateurStatuts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[UtilisateurId] INT NOT NULL,
	[StatutId] INT NOT NULL,
	[StartedAt] DATETIME2(0) NOT NULL DEFAULT GETDATE(),
	[EndedAt] DATETIME2(0) NULL,

	FOREIGN KEY ([UtilisateurId]) REFERENCES Utilisateurs([Id]),
	FOREIGN KEY ([StatutId]) REFERENCES Statuts([Id])
)
