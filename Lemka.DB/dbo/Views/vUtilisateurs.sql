CREATE VIEW [dbo].[vUtilisateurs]
AS
SELECT
	u.[Id],
	u.[Email],
	u.[Tel],
	u.[Image],
	u.[Prenom],
	u.[Nom],
	u.[GenreId],
	r.[Nom] as 'Role',
	s.[Nom] as 'Statut',
	u.[LastLogin],
	u.[CreatedAt],
	u.[UpdatedAt]
FROM dbo.Utilisateurs u
INNER JOIN dbo.UtilisateurStatuts us ON us.[UtilisateurId] = u.[Id]
INNER JOIN dbo.UtilisateurRoles ur ON ur.[UtilisateurId] = u.[Id]
INNER JOIN dbo.Statuts s ON us.[StatutId] = s.[Id]
INNER JOIN dbo.Roles r ON ur.[RoleId] = r.[Id]
WHERE us.[EndedAt] IS NULL