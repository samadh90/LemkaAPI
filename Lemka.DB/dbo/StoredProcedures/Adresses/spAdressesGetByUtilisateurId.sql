CREATE PROCEDURE [dbo].[spAdressesGetByUtilisateurId]
	@UtilisateurId INT
AS
BEGIN
	SELECT [Pays], [Ville], [CodePostal], [Rue], [Numero], [Boite]
	FROM dbo.[Adresses]
	WHERE [UtilisateurId] = @UtilisateurId
END