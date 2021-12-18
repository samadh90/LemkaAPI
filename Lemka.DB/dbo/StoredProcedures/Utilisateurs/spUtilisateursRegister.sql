CREATE PROCEDURE [dbo].[spUtilisateursRegister]
	@Email NVARCHAR(255),
	@Username NVARCHAR(100),
	@Password NVARCHAR(128)
AS
BEGIN
	DECLARE @PasswordHash BINARY(64), @SecurityStamp UNIQUEIDENTIFIER, @UtilisateurId INT;

	IF NOT EXISTS (SELECT TOP 1 * FROM dbo.Utilisateurs WHERE [Email] = @Email)
	BEGIN
		SET @SecurityStamp = NEWID()
		SET @PasswordHash = dbo.fHasher (TRIM(@Password), @SecurityStamp)

		INSERT INTO dbo.Utilisateurs([Username], [Email], [PasswordHash], [SecurityStamp])
		VALUES (TRIM(@Username), TRIM(@Email), @PasswordHash, @SecurityStamp)

		SET @UtilisateurId = SCOPE_IDENTITY()

		INSERT INTO dbo.UtilisateurStatuts ([UtilisateurId], [StatutId]) VALUES (@UtilisateurId, 1)
		INSERT INTO dbo.UtilisateurRoles ([UtilisateurId], [RoleId]) VALUES (@UtilisateurId, 4)
	END
END