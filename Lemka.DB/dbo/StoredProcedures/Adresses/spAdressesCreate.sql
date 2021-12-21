CREATE PROCEDURE [dbo].[spAdressesCreate]
	@UtilisateurId INT,
	@Pays NVARCHAR(100),
	@Ville NVARCHAR(100),
	@CodePostal NVARCHAR(100),
	@Rue NVARCHAR(255),
	@Numero NVARCHAR(50),
	@Boite NVARCHAR(50)
AS
BEGIN
	IF NOT EXISTS (SELECT TOP 1 * FROM dbo.Adresses WHERE [UtilisateurId] = @UtilisateurId)
	BEGIN
		INSERT INTO dbo.Adresses ([UtilisateurId], [Pays], [Ville], [CodePostal], [Rue], [Numero], [Boite])
		VALUES (@UtilisateurId, @Pays, @Ville, @CodePostal, @Rue, @Numero, @Boite)

		UPDATE dbo.Utilisateurs SET [UpdatedAt] = GETDATE() WHERE [Id] = @UtilisateurId
	END
END
