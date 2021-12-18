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
	UPDATE dbo.Adresses
	SET 
		[UtilisateurId] = @UtilisateurId, 
		[Pays] = @Pays, 
		[Ville] = @Ville, 
		[CodePostal] = @CodePostal, 
		[Rue] = @Rue, 
		[Numero] = @Numero, 
		[Boite] = @Boite
END
