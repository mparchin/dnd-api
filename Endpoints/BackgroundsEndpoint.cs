using api.Schemas;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Endpoints
{
    public static class BackgroundsEndpoint
    {
        public static void MapBackgroundsApi(this RouteGroupBuilder group)
        {
            group.MapGet("/", GetAllAsync);
        }

        private static async Task<Results<Ok<BackgroundSchema[]>, NoContent>> GetAllAsync(Db db, long lastTime = long.MinValue)
        {
            var items = (await db.Backgrounds.ToArrayAsync())
                                        .Select(entity => new BackgroundSchema(entity))
                                        .ToArray();
            if (items.Length != 0 && items.Max(entity => entity.Time) > lastTime)
                return TypedResults.Ok(items);
            else
                return TypedResults.NoContent();
        }
    }
}