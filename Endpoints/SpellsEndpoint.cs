using System.Net.Http.Headers;
using api.Schemas;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Newtonsoft;
using Newtonsoft.Json;

namespace api.Endpoints
{
    public static class SpellsEndpoint
    {
        public static void MapSpellsApi(this RouteGroupBuilder group)
        {
            group.MapGet("/", GetAllAsync);
        }

        private static async Task<Ok<SpellSchema[]>> GetAllAsync(Db db) =>
            TypedResults.Ok((await db.Spells.Include(spell => spell.RestrictedClasses)
                                            .Include(spell => spell.RelatedConditions)
                                            .Include(spell => spell.School)
                                            .Include(spell => spell.SpellTags).ToArrayAsync())
                                            .Select(spell => new SpellSchema(spell))
                                            .ToArray());
    }
}