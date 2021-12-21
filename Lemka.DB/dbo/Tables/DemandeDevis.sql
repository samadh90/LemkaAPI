CREATE TABLE [dbo].[DemandeDevis]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[UtilisateurId] INT NOT NULL,
	[Reference] NVARCHAR(50) NOT NULL UNIQUE,
	[Titre] NVARCHAR(80) NOT NULL,
	[Remarque] TEXT NULL,
	[MensurationId] INT NULL,
	[ServiceId] INT NOT NULL,
	[EstUrgent] BIT NOT NULL DEFAULT 0,
	[CreatedAt] DATETIME2(0) NOT NULL DEFAULT GETDATE(),
	[SubmittedAt] DATETIME2(0) NULL,

	FOREIGN KEY (UtilisateurId) REFERENCES [Utilisateurs](Id),
	FOREIGN KEY (ServiceId) REFERENCES [Services](Id),
	FOREIGN KEY (MensurationId) REFERENCES Mensurations(Id) ON DELETE SET NULL
)
