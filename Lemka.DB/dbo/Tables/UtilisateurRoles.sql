CREATE TABLE [dbo].[UtilisateurRoles]
(
	[UtilisateurId] INT NOT NULL,
	[RoleId] INT NOT NULL,

	CONSTRAINT [PK_UtilisateurRoles] PRIMARY KEY (UtilisateurId, RoleId),
	CONSTRAINT [FK_UtilisateurRoles_Utilisateur] FOREIGN KEY (UtilisateurId) REFERENCES Utilisateurs(Id),
	CONSTRAINT [FK_UtilisateurRoles_Role] FOREIGN KEY (RoleId) REFERENCES Roles(Id)
)
