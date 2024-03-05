using api.Models;
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
            group.MapPost("/", CreateCharacter);
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

        private static async Task<Results<Created<CharacterSchema>, BadRequest<string>>> CreateCharacter(Db db, CharacterSchema characterSchema)
        {
            var @class = await db.Classes.FirstOrDefaultAsync(c => c.Id == characterSchema.Id);
            if (@class is null)
                return TypedResults.BadRequest("class id not found");

            var model = characterSchema.ToModel(@class, out var attributes, out var inititive, out var hp,
                out var spellCasting, out var strengthSave, out var dextritySave, out var constitutionSave,
                out var intelligenceSave, out var wisdomSave, out var charismaSave, out var athletics,
                out var acrobatics, out var sleightOfHands, out var stealth, out var arcana, out var history,
                out var investigation, out var nature, out var religion, out var animalHandling,
                out var insight, out var medicine, out var perception, out var survival, out var deception,
                out var intimidation, out var performance, out var persuasion);

            await db.CharacterAttributes.AddAsync(attributes);
            await db.CharacterExperts.AddAsync(inititive);
            await db.CharacterHitpoints.AddAsync(hp);
            await db.CharacterSpellCastings.AddAsync(spellCasting);

            await db.CharacterExperts.AddAsync(strengthSave);
            await db.CharacterExperts.AddAsync(dextritySave);
            await db.CharacterExperts.AddAsync(constitutionSave);
            await db.CharacterExperts.AddAsync(intelligenceSave);
            await db.CharacterExperts.AddAsync(wisdomSave);
            await db.CharacterExperts.AddAsync(charismaSave);

            await db.CharacterExperts.AddAsync(athletics);
            await db.CharacterExperts.AddAsync(acrobatics);
            await db.CharacterExperts.AddAsync(sleightOfHands);
            await db.CharacterExperts.AddAsync(stealth);
            await db.CharacterExperts.AddAsync(arcana);
            await db.CharacterExperts.AddAsync(history);
            await db.CharacterExperts.AddAsync(investigation);
            await db.CharacterExperts.AddAsync(nature);
            await db.CharacterExperts.AddAsync(religion);
            await db.CharacterExperts.AddAsync(animalHandling);
            await db.CharacterExperts.AddAsync(insight);
            await db.CharacterExperts.AddAsync(medicine);
            await db.CharacterExperts.AddAsync(perception);
            await db.CharacterExperts.AddAsync(survival);
            await db.CharacterExperts.AddAsync(deception);
            await db.CharacterExperts.AddAsync(intimidation);
            await db.CharacterExperts.AddAsync(performance);
            await db.CharacterExperts.AddAsync(persuasion);

            await db.SaveChangesAsync();

            await db.Characters.AddAsync(model);

            await db.SaveChangesAsync();

            return TypedResults.Created($"/Characters/{model.Id}", new CharacterSchema(model));
        }
    }
}