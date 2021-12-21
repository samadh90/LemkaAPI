CREATE PROCEDURE [dbo].[spDemandesDevisInsert]
	@UtilisateurId INT,
	@Titre NVARCHAR(80),
	@Remarque TEXT,
	@MensurationId INT,
	@ServiceId INT,
	@EstUrgent BIT
AS
BEGIN
	DECLARE @Reference NVARCHAR(50) = dbo.fGenerateReference('Q')
	INSERT INTO dbo.DemandeDevis ([Reference], [UtilisateurId], [Titre], [Remarque], [MensurationId], [ServiceId], [EstUrgent])
	VALUES (@Reference, @UtilisateurId, @Titre, @Remarque, @MensurationId, @ServiceId, @EstUrgent)

	SELECT SCOPE_IDENTITY() as 'Id'
END