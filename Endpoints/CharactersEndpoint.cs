using api.Schemas;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Endpoints
{
    public static class CharactersEndpoint
    {
        public static void MapCharactersApi(this RouteGroupBuilder group)
        {
            group.MapGet("/", GetAllAsync);
        }

        private static async Task<Results<Ok<CharacterSchema[]>, NoContent>> GetAllAsync(Db db, long lastTime = long.MinValue)
        {
            var characters = (await db.Characters.ToArrayAsync())
                                        .Select(character => new CharacterSchema(character))
                                        .ToArray();
            if (characters.Length != 0 && characters.Max(character => character.Time) > lastTime)
                return TypedResults.Ok(characters);
            return TypedResults.NoContent();
        }
    }
}