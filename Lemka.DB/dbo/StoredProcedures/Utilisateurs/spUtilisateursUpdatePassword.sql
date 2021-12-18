CREATE PROCEDURE [dbo].[spUtilisateursUpdatePassword]
	@UtilisateurId INT,
	@OldPassword NVARCHAR(100),
	@NewPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @NewPasswordHash BINARY(64), @OldPasswordHash BINARY(64), @SecurityStamp UNIQUEIDENTIFIER;

	SELECT @SecurityStamp = [SecurityStamp] FROM dbo.Utilisateurs WHERE [Id] = @UtilisateurId
	SET @OldPasswordHash = dbo.fHasher (TRIM(@OldPassword), @SecurityStamp)

	IF ((SELECT [PasswordHash] FROM dbo.Utilisateurs WHERE [Id] = @UtilisateurId) = @OldPasswordHash)
	BEGIN
		SET @NewPasswordHash = dbo.fHasher (TRIM(@NewPassword), @SecurityStamp)
		UPDATE dbo.Utilisateurs SET [PasswordHash] = @NewPasswordHash WHERE [Id] = @UtilisateurId
	END
END
