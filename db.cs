using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api
{
    public class Db : DbContext
    {
        public static string GetLocalDbConnection(WebApplicationBuilder builder) =>
            $"Data Source={builder.Configuration.GetValue<string>("Local_Db_Path")}" +
            $"{builder.Configuration.GetValue<string>("Local_Db_File")};";

        public static string GetProductionDbConnetion(WebApplicationBuilder builder) =>
            $"USER ID={builder.Configuration.GetValue<string>("Postgres_User") ?? "postgres"};" +
            $"Password={builder.Configuration.GetValue<string>("Postgres_Password") ?? "postgres"};" +
            $"Server={builder.Configuration.GetValue<string>("Postgres") ?? "localhost"};" +
            $"Port={builder.Configuration.GetValue<string>("Postgres_Port") ?? "5432"};" +
            $"Database={builder.Configuration.GetValue<string>("Postgres_Db") ?? "dnd"};" +
            $"Integrated Security=true;" +
            $"Pooling=true;";

        public Db(DbContextOptions<Db> options) : base(options) { }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<SpellTag> SpellTags { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Feat> Feats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.UseIdentityAlwaysColumns();
    }
}