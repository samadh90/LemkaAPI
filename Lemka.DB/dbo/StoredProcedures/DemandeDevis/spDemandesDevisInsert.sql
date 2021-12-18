CREATE PROCEDURE [dbo].[spDemandesDevisInsert]
	@UtilisateurId INT,
	@Titre NVARCHAR(80),
	@Remarque TEXT,
	@MensurationId INT,
	@ServiceId INT,
	@EstUrgent BIT
AS
BEGIN
	DECLARE @Numero NVARCHAR(50)
	EXEC [dbo].[spGenererNumero] N'Q', @Numero OUTPUT
	INSERT INTO dbo.DemandeDevis ([Numero], [UtilisateurId], [Titre], [Remarque], [MensurationId], [ServiceId], [EstUrgent])
	VALUES (@Numero, @UtilisateurId, @Titre, @Remarque, @MensurationId, @ServiceId, @EstUrgent)

	SELECT SCOPE_IDENTITY() as 'Id'
END