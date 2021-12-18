CREATE PROCEDURE [dbo].[spUtilisateursUpdate]
	@Id INT,
	@Username NVARCHAR(50),
	@Tel NVARCHAR(50),
	@Prenom NVARCHAR(50),
	@Nom NVARCHAR(50),
	@GenreId INT
AS
BEGIN
	UPDATE dbo.[Utilisateurs]
	SET [Username] = @Username, [Tel] = @Tel, [Prenom] = @Prenom, [Nom] = @Nom, [GenreId] = @GenreId, [UpdatedAt] = GETDATE()
	WHERE [Id] = @Id
END