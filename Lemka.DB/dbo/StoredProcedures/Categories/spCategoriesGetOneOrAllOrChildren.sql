CREATE PROCEDURE [dbo].[spCategoriesGetOneOrAllOrChildren]
	@Id INT = NULL,
	@ParentId INT = NULL
AS
BEGIN
	IF @Id IS NULL
	BEGIN
		IF @ParentId IS NULL
		BEGIN
			SELECT 
				[Id],
				[ParentId],
				[Nom],
				(SELECT COUNT(*) FROM dbo.Categories WHERE [ParentId] = c.Id) as 'NbEnfants'
			FROM dbo.Categories c
			WHERE [ParentId] IS NULL
		END

		ELSE
		BEGIN
			SELECT 
				[Id],
				[ParentId],
				[Nom],
				(SELECT COUNT(*) FROM dbo.Categories WHERE [ParentId] = c.Id) as 'NbEnfants'
			FROM dbo.Categories c
			WHERE [ParentId] = @ParentId
		END
	END

	ELSE
	BEGIN
		SELECT 
			[Id], 
			[ParentId], 
			[Nom], 
			(SELECT COUNT(*) FROM dbo.Categories WHERE [ParentId] = c.Id) as 'NbEnfants' 
		FROM dbo.Categories c 
		WHERE [Id] = @Id
	END
END