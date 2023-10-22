using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Endpoints
{
    public static class SpellTagsEndpoint
    {
        public static void MapSpellTagsApi(this RouteGroupBuilder group)
        {
            group.MapGet("/", GetAllAsync);
        }

        private static async Task<Ok<SpellTag[]>> GetAllAsync(Db db) =>
            TypedResults.Ok(await db.SpellTags.ToArrayAsync());
    }
}