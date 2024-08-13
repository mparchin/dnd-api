using api.Schemas;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Endpoints
{
    public static class RacesEndpoint
    {
        public static void MapRacesApi(this RouteGroupBuilder group)
        {
            group.MapGet("/", GetAllAsync);
        }

        private static async Task<Results<Ok<RaceSchema[]>, NoContent>> GetAllAsync(Db db, long lastTime = long.MinValue)
        {
            var items = (await db.Races.ToArrayAsync())
                                        .Select(entity => new RaceSchema(entity))
                                        .ToArray();
            if (items.Length != 0 && items.Max(entity => entity.Time) > lastTime)
                return TypedResults.Ok(items);
            else
                return TypedResults.NoContent();
        }
    }
}