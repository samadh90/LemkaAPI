CREATE PROCEDURE [dbo].[spUtilisateursUpdate]
	@Id INT,
	@Prenom NVARCHAR(100),
	@Nom NVARCHAR(100),
	@Tel NVARCHAR(50),
	@GenreId INT
AS
BEGIN
	IF EXISTS (SELECT TOP 1 * FROM dbo.Utilisateurs WHERE [Id] = @Id)
	BEGIN
		UPDATE dbo.[Utilisateurs]
		SET [Tel] = @Tel, [Prenom] = @Prenom, [Nom] = @Nom, [GenreId] = @GenreId, [UpdatedAt] = GETDATE()
		WHERE [Id] = @Id
	END
END