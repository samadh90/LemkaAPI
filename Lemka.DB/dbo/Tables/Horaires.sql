﻿CREATE TABLE [dbo].[Horaires]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Jour] NVARCHAR(50) NOT NULL UNIQUE,
    [HeureOuverture] TIME(0) NULL,
    [HeureFermeture] TIME(0) NULL,
	[SurRdv] BIT NOT NULL DEFAULT 0,
	[EstFerme] BIT NOT NULL DEFAULT 1

	CHECK([HeureOuverture] < [HeureFermeture])
)
