CREATE PROCEDURE [dbo].[spUtilisateursRegister]
	@Email NVARCHAR(255),
	@Password NVARCHAR(128),
	@Nom NVARCHAR(100),
	@Prenom NVARCHAR(100)
AS
BEGIN
	IF NOT EXISTS (SELECT TOP 1 * FROM dbo.Utilisateurs WHERE [Email] = @Email)
	BEGIN
		DECLARE @PasswordHash BINARY(64), @SecurityStamp UNIQUEIDENTIFIER, @UtilisateurId INT;
		SET @SecurityStamp = NEWID()
		SET @PasswordHash = dbo.fHasher (TRIM(@Password), @SecurityStamp)

		INSERT INTO dbo.Utilisateurs ([Email], [PasswordHash], [SecurityStamp], [Nom], [Prenom])
		VALUES (TRIM(@Email), @PasswordHash, @SecurityStamp, TRIM(@Nom), TRIM(@Prenom))

		SET @UtilisateurId = SCOPE_IDENTITY()

		INSERT INTO dbo.UtilisateurStatuts ([UtilisateurId], [StatutId]) VALUES (@UtilisateurId, 1)
		INSERT INTO dbo.UtilisateurRoles ([UtilisateurId], [RoleId]) VALUES (@UtilisateurId, 4)
	END
END