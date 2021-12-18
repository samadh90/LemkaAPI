CREATE TABLE [dbo].[Devis]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Numero] NVARCHAR(50) NOT NULL,
	[Remarque] TEXT NULL,
	[DemandeDevisId] INT NOT NULL,
	[EstAccepte] BIT NULL,
	[CreatedAt] DATETIME2(0) NOT NULL DEFAULT GETDATE(),
	[SubmittedAt] DATETIME2(0) NULL,

	CONSTRAINT UC_Devis_Numero UNIQUE(Numero),
	CONSTRAINT FK_Devis_DemandeDevis FOREIGN KEY (DemandeDevisId) REFERENCES DemandeDevis(Id)
)
