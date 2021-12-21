using System.Text;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Lemka.DAL.Interfaces;
using Lemka.DAL.Repositories;
using Lemka.BLL.Interfaces;
using Lemka.BLL.Services;
using Lemka.UIL.Infrastructure;
using DevHopTools.Connection;

#region Services Configuration

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiExceptionFilter>();
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LemkaAPI", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer { token }\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IsConnected", policy => policy.RequireAuthenticatedUser());
    options.AddPolicy("Webmaster", policy => policy.RequireAuthenticatedUser().RequireRole("Webmaster"));
    options.AddPolicy("Admin", policy => policy.RequireAuthenticatedUser().RequireRole("Admin"));
    options.AddPolicy("Staff", policy => policy.RequireAuthenticatedUser().RequireRole("Staff"));
    options.AddPolicy("Membre", policy => policy.RequireAuthenticatedUser().RequireRole("Membre"));
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Secret"])),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["AppSettings:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["AppSettings:Audience"]
    };
});

/****************/
/*  Singletons  */
/****************/

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSingleton(sp => new Connection(connectionString, SqlClientFactory.Instance));

builder.Services.AddSingleton<ITokenManager>(new TokenManager(builder));

/******************/
/*  Repositories  */
/******************/

builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<ITvaRepository, TvaRepository>();
builder.Services.AddScoped<IMesureRepository, MesureRepository>();
builder.Services.AddScoped<IAdresseRepository, AdresseRepository>();
builder.Services.AddScoped<IHoraireRepository, HoraireRepository>();
builder.Services.AddScoped<IMensurationRepository, MensurationRepository>();
builder.Services.AddScoped<ICategorieRepository, CategorieRepository>();
builder.Services.AddScoped<IDemandeDevisRepository, DemandeDevisRepository>();
builder.Services.AddScoped<IDevisRepository, DevisRepository>();
builder.Services.AddScoped<IRendezVousRepository, RendezVousRepository>();

/**************/
/*  Services  */
/**************/

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<ITvaService, TvaService>();
builder.Services.AddScoped<IMesureService, MesureService>();
builder.Services.AddScoped<IAdresseService, AdresseService>();
builder.Services.AddScoped<IHoraireService, HoraireService>();
builder.Services.AddScoped<IMensurationService, MensurationService>();
builder.Services.AddScoped<ICategorieService, CategorieService>();
builder.Services.AddScoped<IDemandeDevisService, DemandeDevisService>();
builder.Services.AddScoped<IDevisService, DevisService>();
builder.Services.AddScoped<IRendezVousService, RendezVousService>();

#endregion

#region Configuration

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lemka v1"));
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion