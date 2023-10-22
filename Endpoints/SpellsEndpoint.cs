using api.Schemas;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Endpoints
{
    public static class SpellsEndpoint
    {
        public static void MapSpellsApi(this RouteGroupBuilder group)
        {
            group.MapGet("/", GetAllAsync);
            group.MapGet("/Count", CountAsync);
        }

        private static async Task<Ok<SpellSchema[]>> GetAllAsync(Db db) =>
            TypedResults.Ok((await db.Spells
                                    .Include(spell => spell.RestrictedClasses)
                                    .Include(spell => spell.RelatedConditions)
                                    .Include(spell => spell.School)
                                    .Include(spell => spell.SpellTags)
                                    .ToArrayAsync())
                                    .Select(spell => new SpellSchema(spell))
                                    .ToArray());

        private static async Task<Ok<int>> CountAsync(Db db) =>
            TypedResults.Ok(await db.Spells.CountAsync());

    }
}