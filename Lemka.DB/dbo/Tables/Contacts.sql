﻿CREATE TABLE [dbo].[Contacts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Email] NVARCHAR(100) NOT NULL,
	[Nom] NVARCHAR(100) NOT NULL,
	[Prenom] NVARCHAR(100) NOT NULL,
	[Tel] NVARCHAR(100) NULL,
	[Genre] NVARCHAR(50) NULL,
	[Sujet] NVARCHAR(100) NOT NULL,
	[Message] TEXT NOT NULL,
	[CreatedAt] DATETIME2(0) NOT NULL DEFAULT GETDATE(),
	[AnsweredAt] DATETIME2(0) NULL
)
