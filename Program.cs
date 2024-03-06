using System.Text.Json;
using System.Text.Json.Serialization;
using api;
using api.Endpoints;
using api.Models;
using authority;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine($"Running app in {builder.Environment.EnvironmentName} mode");

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JSON Web Token based security"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        Array.Empty<string>()
    }
    });
});

if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<Db>(options =>
    {
        options.UseNpgsql(Db.GetProductionDbConnetion(builder));
        options.EnableSensitiveDataLogging();
    });
else
    builder.Services.AddDbContext<Db>(options => options.UseNpgsql(Db.GetProductionDbConnetion(builder)));

builder.Services.AddCors();

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Class>("Classes");
modelBuilder.EntitySet<Condition>("Conditions");
modelBuilder.EntitySet<School>("Schools");
modelBuilder.EntitySet<SpellTag>("SpellTags");
modelBuilder.EntitySet<Spell>("Spells");
modelBuilder.EntitySet<Feature>("Features");
modelBuilder.EntitySet<Feat>("Feats");
modelBuilder.EntitySet<Rule>("Rules");
modelBuilder.EnableLowerCamelCase();

builder.Services.AddControllers()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                })
                .AddOData(options => options.Select()
                                            .Filter()
                                            .OrderBy()
                                            .Expand()
                                            .Count()
                                            .SetMaxTop(null)
                                            .AddRouteComponents("odata", modelBuilder.GetEdmModel()));

builder.AddJWTAuthentication();
builder.Services.AddAuthorization(options => options.AddPolicies());

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    if (scope.ServiceProvider.GetService<Db>() is { } db)
    {
        await db.Database.MigrateAsync();
        if (builder.Environment.IsDevelopment())
        {
            await db.SeedClassesAsync();
            await db.SeedConditionsAsync();
            await db.SeedSchoolsAsync();
            await db.SeedSpellTagsAsync();
            await db.SeedSpellsAsync();
            await db.SeedFeatsAsync();
        }
    }
}



app.UseCors(builder =>
{
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    builder.AllowAnyOrigin();
});

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGroup("/spells").MapSpellsApi();
app.MapGroup("/conditions").MapConditionsApi();
app.MapGroup("/features").MapFeaturesApi();
app.MapGroup("/Feats").MapFeatsApi();
app.MapGroup("/Rules").MapRulesApi();
app.MapGroup("/Classes").MapClassesApi();

app.MapGroup("/Characters")
    .RequireAuthorization(Authorization.User)
    .MapCharactersApi();

app.MapControllers();

app.Run();
