CREATE PROCEDURE [dbo].[spProduitsInsert]
	@Titre NVARCHAR(80),
	@Description TEXT,
	@EnAffiche BIT,
	@Montant DECIMAL(9, 2),
	@TvaId INT,
	@CategorieId INT,
	@IsPromotion BIT
AS
BEGIN
	DECLARE @ProduitId INT = NULL, @Slug NVARCHAR(100);
	SET @Slug = dbo.fSlugify(TRIM(@Titre))

	IF EXISTS (SELECT TOP 1 * FROM dbo.Produits WHERE [Slug] = @Slug)
	BEGIN
		SET @Slug = CONCAT(@Slug, '-', convert(NVARCHAR(100), dbo.fGenerateText(6, 'Lower')))
	END

	INSERT INTO dbo.Produits ([Slug], [Titre], [Description], [EnAffiche])
	VALUES (@Slug, @Titre, @Description, @EnAffiche)

	SET @ProduitId = SCOPE_IDENTITY()

	INSERT INTO dbo.Prix ([ProduitId], [Montant], [IsPromotion])
	VALUES (@ProduitId, @Montant, @IsPromotion)

	IF @CategorieId IS NOT NULL AND @ProduitId IS NOT NULL
	BEGIN
		INSERT INTO dbo.ProduitCategories ([ProduitId], [CategorieId])
		VALUES (@ProduitId, @CategorieId)
	END

	IF @TvaId IS NOT NULL AND @ProduitId IS NOT NULL
	BEGIN
		INSERT INTO dbo.ProduitTvas ([ProduitId], [TvaId])
		VALUES (@ProduitId, @TvaId)
	END

	IF @ProduitId IS NOT NULL
	BEGIN
		INSERT INTO dbo.ProduitStatuts ([ProduitId], [StatutId])
		VALUES (@ProduitId, 200)
	END

	SELECT @ProduitId AS 'Id'
END
