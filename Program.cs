using System.Text.Json;
using System.Text.Json.Serialization;
using api;
using api.Endpoints;
using api.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<Db>(options =>
    {
        Directory.CreateDirectory(builder.Configuration.GetValue<string>("Local_Db_Path") ?? "");
        options.UseSqlite(Db.GetLocalDbConnection(builder));
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
        }
    }
}



app.UseCors(builder =>
{
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    builder.AllowAnyOrigin();
});

// app.MapGet("/", (IWebHostEnvironment environment, IConfiguration configuration) => $"Hello {environment.EnvironmentName} World! \rdev db:{Db.GetLocalDbConnection(builder)}\rpro db:{Db.GetProductionDbConnetion(builder)}");

app.MapGroup("/spells").MapSpellsApi();
app.MapGroup("/spelltags").MapSpellTagsApi();
app.MapControllers();

app.Run();
