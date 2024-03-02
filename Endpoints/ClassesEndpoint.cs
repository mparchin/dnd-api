using api.Schemas;
using Microsoft.EntityFrameworkCore;

namespace api.Endpoints
{
    public static class ClassesEndpoint
    {
        public static void MapClassesApi(this RouteGroupBuilder group)
        {
            group.MapGet("/", GetAllAsync);
        }

        private static async Task<IResult> GetAllAsync(Db db, long lastTime = long.MinValue)
        {
            var classes = (await db.Classes.ToArrayAsync())
                                        .Select(spell => new ClassSchema(spell))
                                        .ToArray();
            if (classes.Any() && classes.Max(spell => spell.Time) > lastTime)
                return TypedResults.Ok(classes);
            else
                return TypedResults.NoContent();
        }
    }
}