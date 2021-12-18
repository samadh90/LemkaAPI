CREATE PROCEDURE [dbo].[spUtilisateursLogin]
	@Email NVARCHAR(256),
	@Password NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Role NVARCHAR(100), @Status NVARCHAR(100), @PasswordHash BINARY(64), @SecurityStamp UNIQUEIDENTIFIER;

	IF EXISTS (SELECT TOP 1 * FROM dbo.Utilisateurs WHERE [Email] = @Email)
	BEGIN
		SELECT @SecurityStamp = SecurityStamp FROM dbo.Utilisateurs WHERE Email = @Email
		SET @PasswordHash = dbo.fHasher(@Password, @SecurityStamp)

		IF EXISTS (SELECT TOP 1 * FROM dbo.Utilisateurs WHERE Email = @Email AND PasswordHash = @PasswordHash)
		BEGIN
			UPDATE dbo.Utilisateurs SET [LastLogin] = GETDATE() WHERE [Email] = @Email

			SELECT TOP 1
				u.[Id],
				u.[Email],
				u.[Username],
				r.[Nom] AS 'Role',
				s.[Nom] as 'Statut'
			FROM dbo.UtilisateurStatuts us
			INNER JOIN dbo.Statuts s ON us.[StatutId] = s.[Id]
			INNER JOIN dbo.Utilisateurs u ON us.[UtilisateurId] = u.[Id]
			INNER JOIN dbo.UtilisateurRoles ur ON ur.[UtilisateurId] = u.[Id]
			INNER JOIN dbo.Roles r ON ur.[RoleId] = r.[Id]
			WHERE [Email] = @Email AND [PasswordHash] = @PasswordHash AND us.[EndedAt] IS NULL
		END
	END
END