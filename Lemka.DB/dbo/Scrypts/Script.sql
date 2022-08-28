Use LemkaDB

-- Roles
SET IDENTITY_INSERT dbo.Roles ON

INSERT INTO Roles (Id, Nom) VALUES (1, 'Webmaster')
INSERT INTO Roles (Id, Nom) VALUES (2, 'Admin')
INSERT INTO Roles (Id, Nom) VALUES (3, 'Staff')
INSERT INTO Roles (Id, Nom) VALUES (4, 'Membre')

SET IDENTITY_INSERT dbo.Roles OFF

-- Statuts
SET IDENTITY_INSERT dbo.Statuts ON

INSERT INTO dbo.Statuts (Id, Nom, StatutPour) VALUES (1, 'Inactive', 'Utilisateur')
INSERT INTO dbo.Statuts (Id, Nom, StatutPour) VALUES (2, 'Active', 'Utilisateur')
INSERT INTO dbo.Statuts (Id, Nom, StatutPour) VALUES (3, 'Blocked', 'Utilisateur')
INSERT INTO dbo.Statuts (Id, Nom, StatutPour) VALUES (4, 'Deleted', 'Utilisateur')

INSERT INTO dbo.Statuts (Id, Nom, StatutPour) VALUES (200, 'Inactive', 'Produit')
INSERT INTO dbo.Statuts (Id, Nom, StatutPour) VALUES (201, 'Active', 'Produit')
INSERT INTO dbo.Statuts (Id, Nom, StatutPour) VALUES (202, 'Deleted', 'Produit')

SET IDENTITY_INSERT dbo.Statuts OFF

-- Genres
SET IDENTITY_INSERT dbo.Genres ON

INSERT INTO dbo.Genres (Id, Nom) VALUES (1, 'Homme')
INSERT INTO dbo.Genres (Id, Nom) VALUES (2, 'Femme')
INSERT INTO dbo.Genres (Id, Nom) VALUES (3, 'X')

SET IDENTITY_INSERT dbo.Genres OFF

-- Mesures
SET IDENTITY_INSERT dbo.Mesures ON

INSERT INTO dbo.Mesures (Id, Nom) VALUES (1, 'Hauteur')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (2, 'Avant bras (tour)')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (3, 'Biceps (tour)')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (4, 'Cou jusqu''à cheville')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (5, 'Entrejambre à cheville')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (6, 'Épaule au coude')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (7, 'Épaule au poignet')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (8, 'Épaules à épaules')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (9, 'Genoux à cheville')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (10, 'Genoux (tour)')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (11, 'Longueur dos')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (12, 'Mollet (tour)')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (13, 'Poignet au coude')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (14, 'Taille à la cheville')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (15, 'Tour de cheville')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (16, 'Tour de cou')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (17, 'Tour de cuisse')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (18, 'Tour de hanches')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (19, 'Tour de poignet')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (20, 'Tour de poitrine')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (21, 'Tour de taille')
INSERT INTO dbo.Mesures (Id, Nom) VALUES (22, 'Tour sous poitrine (femme)')

SET IDENTITY_INSERT dbo.Mesures OFF

-- Services
SET IDENTITY_INSERT dbo.[Services] ON

INSERT INTO dbo.[Services] (Id, Nom, DureeMinute) VALUES (1, 'Confection', 90)
INSERT INTO dbo.[Services] (Id, Nom, DureeMinute) VALUES (2, 'Reparation', 30)
INSERT INTO dbo.[Services] (Id, Nom, DureeMinute) VALUES (3, 'Retouche', 45)

SET IDENTITY_INSERT dbo.[Services] OFF

-- Tvas
SET IDENTITY_INSERT dbo.[Tvas] ON

INSERT INTO dbo.[Tvas] ([Id], [Taux]) VALUES (1, 0.00)
INSERT INTO dbo.[Tvas] ([Id], [Taux]) VALUES (2, 0.06)
INSERT INTO dbo.[Tvas] ([Id], [Taux]) VALUES (3, 0.12)
INSERT INTO dbo.[Tvas] ([Id], [Taux]) VALUES (4, 0.21)

SET IDENTITY_INSERT dbo.[Tvas] OFF

-- Categories
SET IDENTITY_INSERT dbo.Categories ON

INSERT INTO dbo.Categories (Id, Nom) VALUES (1, 'Merceries')
INSERT INTO dbo.Categories (Id, Nom) VALUES (2, 'Réalisations')
INSERT INTO dbo.Categories ([Id], [ParentId], [Nom]) VALUES (3, 1, 'Tissus')

SET IDENTITY_INSERT dbo.Categories OFF

-- Horaires
SET IDENTITY_INSERT dbo.Horaires ON

INSERT INTO dbo.Horaires ([Id], [Jour]) VALUES (1, 'Lundi')
INSERT INTO dbo.Horaires ([Id], [Jour]) VALUES (2, 'Mardi')
INSERT INTO dbo.Horaires ([Id], [Jour]) VALUES (3, 'Mercredi')
INSERT INTO dbo.Horaires ([Id], [Jour]) VALUES (4, 'Jeudi')
INSERT INTO dbo.Horaires ([Id], [Jour]) VALUES (5, 'Vendredi')
INSERT INTO dbo.Horaires ([Id], [Jour]) VALUES (6, 'Samedi')
INSERT INTO dbo.Horaires ([Id], [Jour]) VALUES (7, 'Dimanche')

SET IDENTITY_INSERT dbo.Horaires OFF

-- Create first dummy data

-- Création d'un admin
EXEC dbo.spUtilisateursRegister 'test2@test.com', 'HelloWorld!', 'Kent', 'Clark';
EXEC dbo.spUtilisateursUpdateStatut 1, 2;
UPDATE dbo.UtilisateurRoles SET [RoleId] = 1 WHERE [UtilisateurId] = 1;

-- Création d'un membre
EXEC dbo.spUtilisateursRegister 'test@test.com', 'HelloWorld!', 'Price', 'John';
EXEC dbo.spUtilisateursUpdateStatut 2, 2;
EXEC dbo.spMensurationsInsert 2, N'Premiere mensuration', N'Simple description', 1;
EXEC dbo.spDemandesDevisInsert 2, N'Réparation de la tirette du pantalon', N'C''est une tirette verte de 10 cm', 1, 2, 0;

-- Création d'un article
EXEC dbo.spProduitsInsert N'Tissus', N'Description du tissus', 1, 49.99, 4, 3, 0;
