using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api
{
    public static class Seed
    {
        private const string alphabet = "qwertyuiopasdfghjklzxcvbnm";
        private static readonly Random _rnd = new();
        private static string NextString(this Random random, int len = 10) =>
            Enumerable.Range(0, len)
                    .Select(i => alphabet[random.Next(0, alphabet.Length - 1)])
                    .Aggregate("", (current, next) => $"{current}{next}");

        private static string NextWords(this Random random, int wordCount = 50) =>
            Enumerable.Range(0, wordCount)
                    .Select(i => random.NextString(random.Next(0, 11)))
                    .Aggregate("", (current, next) => current == "" ? next : $"{current} {next}");

        private static bool NextBool(this Random random) =>
            random.Next(0, 2) == 1;

        private static TEntity? Next<TEntity>(this IQueryable<TEntity> entities) =>
            entities.OrderBy(entity => EF.Functions.Random()).FirstOrDefault();

        private static List<TEntity> Pick<TEntity>(this IQueryable<TEntity> entities, int number)
        {
            var ret = new List<TEntity>();
            while (ret.Count != number)
            {
                var candidate = entities.Next();
                if (candidate is null || ret.Contains(candidate))
                    continue;
                ret.Add(candidate);
            }
            return ret;
        }

        private static TEnum Next<TEnum>(this Random random)
            where TEnum : Enum
        {
            var vals = typeof(TEnum).GetEnumValues();
            return (TEnum)vals.GetValue(random.Next(0, vals.Length))!;
        }

        private static List<TEnum> Pick<TEnum>(this Random random, int number)
            where TEnum : Enum
        {
            var ret = new List<TEnum>();
            while (ret.Count != number)
            {
                var candidate = random.Next<TEnum>();
                if (ret.Contains(candidate))
                    continue;
                ret.Add(candidate);
            }
            return ret;
        }

        private static IEnumerable<TEntity> CreateFakeEntities<TEntity>(int count, Action<TEntity> fill)
            where TEntity : IModel, new() =>
                Enumerable.Range(1, count).Select(i =>
                {
                    var entity = new TEntity
                    {
                        Id = i
                    };
                    fill(entity);
                    return entity;
                });

        private static async Task SeedEntityAsync<TEntity>(this DbContext db, int count, Action<TEntity> fill)
            where TEntity : class, IModel, new()
        {
            CreateFakeEntities(count, fill).ToList().ForEach(entity =>
            {
                if (db.Find<TEntity>(entity.Id) is { })
                    return;
                entity.Id = default;
                db.Add(entity);
            });
            await db.SaveChangesAsync();
        }

        public static Task SeedClassesAsync(this DbContext db) =>
            db.SeedEntityAsync<Class>(10, @class => @class.Name = _rnd.NextString());

        public static Task SeedConditionsAsync(this DbContext db) =>
            db.SeedEntityAsync<Condition>(5, condition =>
            {
                condition.Name = _rnd.NextString();
                condition.Description = _rnd.NextWords();
            });

        public static Task SeedSchoolsAsync(this DbContext db) =>
            db.SeedEntityAsync<School>(6, school => school.Name = _rnd.NextString());

        public static Task SeedSpellTagsAsync(this DbContext db) =>
            db.SeedEntityAsync<SpellTag>(20, spellTag => spellTag.Name = _rnd.NextString());

        public static Task SeedSpellsAsync(this Db db) =>
            db.SeedEntityAsync<Spell>(100, spell =>
            {
                spell.Name = _rnd.NextString();
                spell.Level = _rnd.Next(0, 10);
                spell.Book = _rnd.NextBool() ? _rnd.NextString() : null;
                spell.School = db.Schools.Next();
                spell.HasVerbalComponent = _rnd.NextBool();
                spell.HasSomaticComponent = _rnd.NextBool();
                spell.Materials = (!spell.HasVerbalComponent && !spell.HasSomaticComponent) || _rnd.NextBool()
                    ? _rnd.NextWords(10)
                    : null;
                db.SpellTags.Pick(_rnd.Next(1, 6)).ForEach(spell.SpellTags.Add);
                spell.SavingThrow = _rnd.NextBool() ? _rnd.Next<SavingThrows>() : null;
                spell.DamageTypes = _rnd.Pick<DamageTypes>(_rnd.Next(0, 4)).ToArray();
                spell.Action = _rnd.Next<Actions>();
                spell.LongerAction = _rnd.NextBool() ? _rnd.NextString() : null;
                spell.Range = _rnd.NextString();
                spell.Duration = _rnd.NextString();
                spell.IsConcentration = _rnd.NextBool();
                spell.IsRitual = _rnd.NextBool();
                db.Classes.Pick(_rnd.Next(0, 6)).ForEach(spell.RestrictedClasses.Add);
                spell.Description = _rnd.NextWords(250);
                spell.HigherLevelDescription = _rnd.NextBool() ? _rnd.NextWords(50) : null;
                spell.DamageFormula = null; // TODO: later
                db.Conditions.Pick(_rnd.Next(0, 6)).ForEach(spell.RelatedConditions.Add);
                spell.SpellLists = _rnd.Pick<SpellLists>(_rnd.Next(1, 4)).ToArray();
            });
    }
}