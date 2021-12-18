CREATE TABLE [dbo].[MensurationMesures]
(
	[MensurationId] INT NOT NULL,
	[MesureId] INT NOT NULL,
	[Valeur] DECIMAL(16, 2) NOT NULL DEFAULT 0.0,

	CONSTRAINT [PK_MensurationMesures] PRIMARY KEY (MensurationId, MesureId),
	CONSTRAINT [FK_MensurationMesures_MensurationId] FOREIGN KEY (MensurationId) REFERENCES Mensurations(Id) ON DELETE CASCADE,
	CONSTRAINT [FK_MensurationMesures_MesureId] FOREIGN KEY (MesureId) REFERENCES Mesures(Id) ON DELETE CASCADE,
    CONSTRAINT [CK_MensurationMesures_Valeur] CHECK (Valeur >= 0.0)
)
