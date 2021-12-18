CREATE TABLE [dbo].[Services]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Nom] NVARCHAR(50) NOT NULL,
	[DureeMinute] INT NOT NULL,

	CONSTRAINT [UC_Services_Nom] UNIQUE(Nom), 
    CONSTRAINT [CK_Services_DureeMinute] CHECK (DureeMinute > 0)
)
