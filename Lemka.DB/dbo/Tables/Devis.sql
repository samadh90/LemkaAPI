CREATE TABLE [dbo].[Devis]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Reference] NVARCHAR(50) NOT NULL UNIQUE,
	[Remarque] TEXT NULL,
	[DemandeDevisId] INT NOT NULL,
	[ExpiresInDays] INT NOT NULL,
	[EstAccepte] BIT NULL,
	[CreatedAt] DATETIME2(0) NOT NULL DEFAULT GETDATE(),
	[SubmittedAt] DATETIME2(0) NULL,

	CONSTRAINT FK_Devis_DemandeDevis FOREIGN KEY (DemandeDevisId) REFERENCES DemandeDevis(Id)
)
