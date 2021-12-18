CREATE PROCEDURE [dbo].[spUtilisateursUpdateStatut]
	@UtilisateurId INT,
	@StatutId INT
AS
BEGIN
	DECLARE @DateNow DATETIME2(0) = GETDATE();

	UPDATE dbo.UtilisateurStatuts SET [EndedAt] = @DateNow WHERE [UtilisateurId] = @UtilisateurId
	INSERT INTO dbo.UtilisateurStatuts (UtilisateurId, StatutId, StartedAt) VALUES (@UtilisateurId, @StatutId, @DateNow)
END