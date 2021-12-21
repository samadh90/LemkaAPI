CREATE PROCEDURE [dbo].[spDetailsInsertForDevis]
	@DevisId INT,
	@Designation NVARCHAR(255),
	@PrixUHt DECIMAL(9,2),
	@Quantite FLOAT,
	@Tva FLOAT
AS
BEGIN
	IF EXISTS (SELECT TOP 1 * FROM dbo.[Devis] WHERE [Id] = @DevisId)
	BEGIN
		INSERT INTO dbo.[Details] ([DevisId], [Designation], [Quantite], [Tva], [PrixUHt])
		VALUES (@DevisId, @Designation, @PrixUHt, @Quantite, @Tva)
	END
END

/*
	[DevisId] INT NOT NULL,
	[Designation] NVARCHAR(255) NOT NULL,
	[PrixUHt] DECIMAL(9, 2) NOT NULL,
	[Quantite] FLOAT NOT NULL,
	[Tva] FLOAT NOT NULL DEFAULT 0.0,
*/