﻿CREATE TABLE [dbo].[Utilisateurs]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Email] NVARCHAR(255) NOT NULL,
	[PasswordHash] BINARY(64) NOT NULL,
    [SecurityStamp] UNIQUEIDENTIFIER NOT NULL,
	[Image] NVARCHAR(255) NULL,
	[Prenom] NVARCHAR(100) NOT NULL,
	[Nom] NVARCHAR(100) NOT NULL,
	[Tel] NVARCHAR(25) NULL,
	[GenreId] INT NULL,
	[LastLogin] DATETIME2(0) NULL,
	[CreatedAt] DATETIME2(0) NOT NULL DEFAULT GETDATE(),
	[UpdatedAt] DATETIME2(0) NULL,

	CONSTRAINT [UC_Utilisateurs_Email] UNIQUE (Email),
	CONSTRAINT [FK_Utilisateurs_Genre] FOREIGN KEY (GenreId) REFERENCES Genres(Id) ON DELETE SET NULL
)