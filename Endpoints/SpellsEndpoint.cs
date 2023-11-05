using api.Schemas;
using Microsoft.EntityFrameworkCore;

namespace api.Endpoints
{
    public static class SpellsEndpoint
    {
        public static void MapSpellsApi(this RouteGroupBuilder group)
        {
            group.MapGet("/", GetAllAsync);
        }

        private static async Task<IResult> GetAllAsync(Db db, long lastTime = long.MinValue)
        {
            var spells = (await db.Spells.Include(spell => spell.RestrictedClasses)
                                        .Include(spell => spell.RelatedConditions)
                                        .Include(spell => spell.School)
                                        .Include(spell => spell.SpellTags)
                                        .ToArrayAsync())
                                        .Select(spell => new SpellSchema(spell))
                                        .ToArray();
            if (spells.Max(spell => spell.Time) > lastTime)
                return TypedResults.Ok(spells);
            else
                return TypedResults.NoContent();
        }
    }
}