using api.Schemas;
using Microsoft.EntityFrameworkCore;

namespace api.Endpoints
{
    public static class RulesEndpoint
    {
        public static void MapRulesApi(this RouteGroupBuilder group)
        {
            group.MapGet("/", GetAllAsync);
        }

        private static async Task<IResult> GetAllAsync(Db db, long lastTime = long.MinValue)
        {
            var rules = (await db.Rules.ToArrayAsync())
                                        .Select(rule => new RuleSchema(rule))
                                        .ToArray();
            if (rules.Any() && rules.Max(rule => rule.Time) > lastTime)
                return TypedResults.Ok(rules);
            else
                return TypedResults.NoContent();
        }
    }
}