CREATE TABLE [dbo].[Statuts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Nom] NVARCHAR(50) NOT NULL,
	[StatutPour] NVARCHAR(50) NULL,

	UNIQUE ([Nom], [StatutPour])
)
