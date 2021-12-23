CREATE PROCEDURE [dbo].[spDetailsInsert]
	@DevisId INT,
	@Designation nvarchar(255),
	@PrixUHt decimal(9,2),
	@Quantite float,
	@Tva float
AS
BEGIN
	IF EXISTS (SELECT TOP 1 * FROM dbo.[Devis] WHERE [Id] = @DevisId)
	BEGIN
		INSERT INTO dbo.[Details] ([DevisId], [Designation], [Tva], [PrixUHt], [Quantite])
		VALUES (@DevisId, @Designation, @Tva, @PrixUHt, @Quantite)

		SELECT SCOPE_IDENTITY() as 'Id'
	END
END
