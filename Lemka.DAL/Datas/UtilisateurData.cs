namespace Lemka.DAL.Datas;

public class UtilisateurData
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Tel { get; set; }
    public string? Image { get; set; }
    public string? Prenom { get; set; }
    public string? Nom { get; set; }
    public int? GenreId { get; set; }
    public string? Role { get; set; }
    public string? Statut { get; set; }
    public DateTime? LastLogin { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}


/*
 	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Email] NVARCHAR(255) NOT NULL,
	[PasswordHash] BINARY(64) NOT NULL,
    [SecurityStamp] UNIQUEIDENTIFIER NOT NULL,
	[Image] NVARCHAR(255) NULL,
	[Prenom] NVARCHAR(100) NULL,
	[Nom] NVARCHAR(100) NULL,
	[Tel] NVARCHAR(25) NULL,
	[GenreId] INT NULL,
	[LastLogin] DATETIME2(7) NULL,
	[CreatedAt] DATETIME2(7) NOT NULL DEFAULT GETDATE(),
	[UpdatedAt] DATETIME2 NULL,
 */