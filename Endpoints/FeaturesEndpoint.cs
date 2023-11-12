using api.Schemas;
using Microsoft.EntityFrameworkCore;

namespace api.Endpoints
{
    public static class FeaturesEndpoint
    {
        public static void MapFeaturesApi(this RouteGroupBuilder group)
        {
            group.MapGet("/", GetAllAsync);
        }

        private static async Task<IResult> GetAllAsync(Db db, long lastTime = long.MinValue)
        {
            var features = (await db.Features.ToArrayAsync())
                                        .Select(feature => new FeaturesSchema(feature))
                                        .ToArray();
            if (features.Any() && features.Max(spell => spell.Time) > lastTime)
                return TypedResults.Ok(features);
            else
                return TypedResults.NoContent();
        }
    }
}