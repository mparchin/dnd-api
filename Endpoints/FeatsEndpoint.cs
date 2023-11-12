using api.Schemas;
using Microsoft.EntityFrameworkCore;

namespace api.Endpoints
{
    public static class FeatsEndpoint
    {
        public static void MapFeatsApi(this RouteGroupBuilder group)
        {
            group.MapGet("/", GetAllAsync);
        }

        private static async Task<IResult> GetAllAsync(Db db, long lastTime = long.MinValue)
        {
            var feats = (await db.Feats.ToArrayAsync())
                                        .Select(feat => new FeatSchema(feat))
                                        .ToArray();
            if (feats.Max(spell => spell.Time) > lastTime)
                return TypedResults.Ok(feats);
            else
                return TypedResults.NoContent();
        }
    }
}