CREATE TABLE [dbo].[RendezVous]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Jour] DATE NOT NULL,
	[HeureDebut] TIME NOT NULL,
	[HeureFin] TIME NOT NULL,
	[ServiceId] INT NOT NULL,
	[DevisId] INT NULL,
	[UtilisateurId] INT NOT NULL,
	[CreatedAt] DATETIME2(0) NOT NULL DEFAULT GETDATE(),
	[CanceledAt] DATETIME2(0) NULL,

	CONSTRAINT [FK_RendezVous_Service] FOREIGN KEY (ServiceId) REFERENCES [Services](Id),
	CONSTRAINT [FK_RendezVous_Devis] FOREIGN KEY (DevisId) REFERENCES Devis(Id) ON DELETE SET NULL,
	CONSTRAINT [FK_RendezVous_Utilisateur] FOREIGN KEY (UtilisateurId) REFERENCES Utilisateurs(Id),
	CONSTRAINT [CK_RendezVous_Start] CHECK([HeureFin] > [HeureDebut]),
)
