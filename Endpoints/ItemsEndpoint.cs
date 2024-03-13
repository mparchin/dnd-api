using api.Schemas;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Endpoints
{
    public static class ItemsEndpoint
    {
        public static void MapItemsApi(this RouteGroupBuilder group)
        {
            group.MapGet("/", GetAllAsync);
        }

        private static async Task<Results<Ok<ItemSchema[]>, NoContent>> GetAllAsync(Db db, long lastTime = long.MinValue)
        {
            var items = (await db.Items.ToArrayAsync())
                                        .Select(entity => new ItemSchema(entity))
                                        .ToArray();
            if (items.Length != 0 && items.Max(entity => entity.Time) > lastTime)
                return TypedResults.Ok(items);
            else
                return TypedResults.NoContent();
        }
    }
}