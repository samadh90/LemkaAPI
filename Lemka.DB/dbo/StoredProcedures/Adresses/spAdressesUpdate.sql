CREATE PROCEDURE [dbo].[spAdressesUpdate]
	@UtilisateurId INT,
	@Pays NVARCHAR(100),
	@Ville NVARCHAR(100),
	@CodePostal NVARCHAR(100),
	@Rue NVARCHAR(255),
	@Numero NVARCHAR(50),
	@Boite NVARCHAR(50)
AS
BEGIN
	IF EXISTS (SELECT TOP 1 * FROM dbo.Adresses WHERE [UtilisateurId] = @UtilisateurId)
	BEGIN
		UPDATE dbo.Adresses
		SET 
			[UtilisateurId] = @UtilisateurId, 
			[Pays] = @Pays, 
			[Ville] = @Ville, 
			[CodePostal] = @CodePostal, 
			[Rue] = @Rue, 
			[Numero] = @Numero, 
			[Boite] = @Boite
		WHERE [UtilisateurId] = @UtilisateurId

		UPDATE dbo.Utilisateurs SET [UpdatedAt] = GETDATE() WHERE [Id] = @UtilisateurId
	END
END
