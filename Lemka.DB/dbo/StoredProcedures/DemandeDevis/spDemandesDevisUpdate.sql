CREATE PROCEDURE [dbo].[spDemandesDevisUpdate]
	@Id INT,
	@Titre NVARCHAR(80),
	@Remarque TEXT,
	@MensurationId INT,
	@ServiceId INT,
	@EstUrgent BIT
AS
BEGIN
	IF EXISTS (SELECT TOP 1 * FROM dbo.DemandeDevis WHERE [Id] = @Id)
	BEGIN
		IF ((SELECT [SubmittedAt] FROM dbo.DemandeDevis WHERE [Id] = @Id) IS NOT NULL)
		BEGIN
			UPDATE dbo.DemandeDevis 
			SET [Titre] = @Titre, [Remarque] = @Remarque, [MensurationId] = @MensurationId, [ServiceId] = @ServiceId, [EstUrgent] = @EstUrgent
			WHERE [Id] = @Id
		END
	END
END