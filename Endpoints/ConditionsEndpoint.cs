using api.Schemas;
using Microsoft.EntityFrameworkCore;

namespace api.Endpoints
{
    public static class ConditionsEndpoint
    {
        public static void MapConditionsApi(this RouteGroupBuilder group)
        {
            group.MapGet("/", GetAllAsync);
        }

        private static async Task<IResult> GetAllAsync(Db db, long lastTime = long.MinValue)
        {
            var conditions = (await db.Conditions.ToArrayAsync())
                                        .Select(spell => new ConditionSchema(spell))
                                        .ToArray();
            if (conditions.Any() && conditions.Max(spell => spell.Time) > lastTime)
                return TypedResults.Ok(conditions);
            else
                return TypedResults.NoContent();
        }
    }
}