using System.Security.Claims;
using api.Models;
using api.Schemas;
using authority;
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
            group.MapPut("/", EditCharacter);
            group.MapDelete("/{id}", Delete);

            group.MapPost("/{id}/extras", CreateExtra);
            group.MapPut("/{id}/extras", EditExtra);
            group.MapDelete("/{id}/extras/{extraId}", DeleteExtra);

            group.MapPost("/{id}/spells", CreateSpell);
            group.MapPut("/{id}/spells", EditSpell);
            group.MapDelete("/{id}/spells/{spellId}", DeleteSpell);
        }

        private static async Task<Results<Ok<CharacterSchema[]>, NoContent>> GetAllAsync(Db db,
            ClaimsPrincipal claimsPrincipal, long lastTime = long.MinValue)
        {
            var user = claimsPrincipal.GetUser();
            var characters = (await db.Characters
                    .Include(c => c.Class)
                    .Include(c => c.Attributes)
                    .Include(c => c.Hp)
                    .Include(c => c.SpellCasting)
                    .Include(c => c.Inititive)
                    .Include(c => c.StrengthSave)
                    .Include(c => c.DextritySave)
                    .Include(c => c.ConstitutionSave)
                    .Include(c => c.IntelligenceSave)
                    .Include(c => c.WisdomSave)
                    .Include(c => c.CharismaSave)
                    .Include(c => c.Athletics)
                    .Include(c => c.Acrobatics)
                    .Include(c => c.SleightOfHands)
                    .Include(c => c.Stealth)
                    .Include(c => c.Arcana)
                    .Include(c => c.History)
                    .Include(c => c.Investigation)
                    .Include(c => c.Nature)
                    .Include(c => c.Religion)
                    .Include(c => c.AnimalHandling)
                    .Include(c => c.Insight)
                    .Include(c => c.Medicine)
                    .Include(c => c.Perception)
                    .Include(c => c.Survival)
                    .Include(c => c.Deception)
                    .Include(c => c.Intimidation)
                    .Include(c => c.Performance)
                    .Include(c => c.Persuasion)
                    .Include(c => c.Extras)
                    .Include(c => c.Spells)
                    .Include("Spells.Spell")
                    .Where(c => c.UserId == user.Guid)
                    .ToArrayAsync())
                .Select(character => new CharacterSchema(character))
                .ToArray();
            if (characters.Length != 0 && characters.Max(character => character.Time) > lastTime)
                return TypedResults.Ok(characters);
            return TypedResults.NoContent();
        }

        private static async Task<Results<Created<CharacterSchema>, BadRequest<string>>> CreateCharacter(Db db,
            ClaimsPrincipal claimsPrincipal, CharacterSchema characterSchema)
        {
            var user = claimsPrincipal.GetUser();
            var @class = await db.Classes.FirstOrDefaultAsync(c => c.Id == characterSchema.Class.Id);
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

            model.UserId = user.Guid;
            await db.Characters.AddAsync(model);

            await db.SaveChangesAsync();

            return TypedResults.Created($"/Characters/{model.Id}", new CharacterSchema(model));
        }

        private static async Task<Results<Ok<CharacterSchema>, NotFound<string>>> EditCharacter(Db db,
            ClaimsPrincipal claimsPrincipal, CharacterSchema characterSchema)
        {
            var user = claimsPrincipal.GetUser();
            var model = await db.Characters.Include(c => c.Attributes)
                .Include(c => c.Class)
                .Include(c => c.Hp)
                .Include(c => c.SpellCasting)
                .Include(c => c.Inititive)
                .Include(c => c.StrengthSave)
                .Include(c => c.DextritySave)
                .Include(c => c.ConstitutionSave)
                .Include(c => c.IntelligenceSave)
                .Include(c => c.WisdomSave)
                .Include(c => c.CharismaSave)
                .Include(c => c.Athletics)
                .Include(c => c.Acrobatics)
                .Include(c => c.SleightOfHands)
                .Include(c => c.Stealth)
                .Include(c => c.Arcana)
                .Include(c => c.History)
                .Include(c => c.Investigation)
                .Include(c => c.Nature)
                .Include(c => c.Religion)
                .Include(c => c.AnimalHandling)
                .Include(c => c.Insight)
                .Include(c => c.Medicine)
                .Include(c => c.Perception)
                .Include(c => c.Survival)
                .Include(c => c.Deception)
                .Include(c => c.Intimidation)
                .Include(c => c.Performance)
                .Include(c => c.Persuasion)
                .Include(c => c.Extras)
                .Include(c => c.Spells)
                .Include("Spells.Spell")
                .Where(c => c.UserId == user.Guid)
                .FirstOrDefaultAsync(c => c.Id == characterSchema.Id);

            if (model is null)
                return TypedResults.NotFound($"id not found {characterSchema.Id}");

            characterSchema.EditModel(model, model.Attributes, model.Inititive, model.Hp, model.SpellCasting,
                model.StrengthSave, model.DextritySave, model.ConstitutionSave, model.IntelligenceSave, model.WisdomSave, model.CharismaSave,
                model.Athletics,
                model.Acrobatics, model.SleightOfHands, model.Stealth,
                model.Arcana, model.History, model.Investigation, model.Nature, model.Religion,
                model.AnimalHandling, model.Insight, model.Medicine, model.Perception, model.Survival,
                model.Deception, model.Intimidation, model.Performance, model.Persuasion);

            model.UpdatedOn = DateTime.UtcNow;

            if ((await db.Classes.FirstOrDefaultAsync(c => c.Id == characterSchema.Class.Id)) is { } newClass)
                model.Class = newClass;

            await db.SaveChangesAsync();

            return TypedResults.Ok(new CharacterSchema(model));
        }

        private static async Task<Results<NoContent, NotFound<string>>> Delete(Db db,
            ClaimsPrincipal claimsPrincipal, int id)
        {
            var user = claimsPrincipal.GetUser();
            var model = await db.Characters.Include(c => c.Attributes)
                .Include(c => c.Hp)
                .Include(c => c.SpellCasting)
                .Include(c => c.Inititive)
                .Include(c => c.StrengthSave)
                .Include(c => c.DextritySave)
                .Include(c => c.ConstitutionSave)
                .Include(c => c.IntelligenceSave)
                .Include(c => c.WisdomSave)
                .Include(c => c.CharismaSave)
                .Include(c => c.Athletics)
                .Include(c => c.Acrobatics)
                .Include(c => c.SleightOfHands)
                .Include(c => c.Stealth)
                .Include(c => c.Arcana)
                .Include(c => c.History)
                .Include(c => c.Investigation)
                .Include(c => c.Nature)
                .Include(c => c.Religion)
                .Include(c => c.AnimalHandling)
                .Include(c => c.Insight)
                .Include(c => c.Medicine)
                .Include(c => c.Perception)
                .Include(c => c.Survival)
                .Include(c => c.Deception)
                .Include(c => c.Intimidation)
                .Include(c => c.Performance)
                .Include(c => c.Persuasion)
                .Include(c => c.Extras)
                .Include(c => c.Spells)
                .Include("Spells.Spell")
                .Where(m => m.UserId == user.Guid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (model is null)
                return TypedResults.NotFound($"Id not found {id}");

            db.Remove(model.Attributes);
            db.Remove(model.Inititive);
            db.Remove(model.Hp);
            db.Remove(model.SpellCasting);
            db.Remove(model.StrengthSave);
            db.Remove(model.DextritySave);
            db.Remove(model.ConstitutionSave);
            db.Remove(model.IntelligenceSave);
            db.Remove(model.WisdomSave);
            db.Remove(model.CharismaSave);
            db.Remove(model.Athletics);
            db.Remove(model.Acrobatics);
            db.Remove(model.SleightOfHands);
            db.Remove(model.Stealth);
            db.Remove(model.Arcana);
            db.Remove(model.History);
            db.Remove(model.Investigation);
            db.Remove(model.Nature);
            db.Remove(model.Religion);
            db.Remove(model.AnimalHandling);
            db.Remove(model.Insight);
            db.Remove(model.Medicine);
            db.Remove(model.Perception);
            db.Remove(model.Survival);
            db.Remove(model.Deception);
            db.Remove(model.Intimidation);
            db.Remove(model.Performance);
            db.Remove(model.Persuasion);

            model.Extras.ForEach(extra => db.Remove(extra));
            model.Spells.ForEach(spell =>
            {
                spell.Spell = null;
                db.Remove(spell);
            });

            model.Class = null;

            db.Remove(model);

            await db.SaveChangesAsync();

            return TypedResults.NoContent();
        }

        private static async Task<Results<Created<CharacterExtraSchema>, NotFound<string>>> CreateExtra(Db db,
            ClaimsPrincipal claimsPrincipal, int id, CharacterExtraSchema schema)
        {
            var user = claimsPrincipal.GetUser();
            if (!((await db.Characters.FirstOrDefaultAsync(c => c.Id == id && c.UserId == user.Guid)) is { } character))
                return TypedResults.NotFound($"CharId: {id} not found");

            var model = schema.ToModel();

            model.Character = character;

            await db.CharacterExtras.AddAsync(model);
            await db.SaveChangesAsync();

            return TypedResults.Created($"/characters/{id}/extras/{model.Id}", new CharacterExtraSchema(model));
        }

        private static async Task<Results<Ok<CharacterExtraSchema>, NotFound<string>, BadRequest<string>>> EditExtra(Db db,
            ClaimsPrincipal claimsPrincipal, int id, CharacterExtraSchema schema)
        {
            var user = claimsPrincipal.GetUser();
            if (!((await db.Characters.FirstOrDefaultAsync(c => c.Id == id && c.UserId == user.Guid)) is { } character))
                return TypedResults.NotFound($"CharId: {id} not found");

            if (!((await db.CharacterExtras.FirstOrDefaultAsync(extra => extra.Id == schema.Id)) is { } model))
                return TypedResults.BadRequest($"Id: {schema.Id} not found");

            schema.ToModel(model);

            model.Character = character;

            await db.SaveChangesAsync();

            return TypedResults.Ok(new CharacterExtraSchema(model));
        }

        private static async Task<Results<NoContent, NotFound<string>>> DeleteExtra(Db db,
            ClaimsPrincipal claimsPrincipal, int id, int extraId)
        {
            var user = claimsPrincipal.GetUser();
            if (!((await db.Characters.FirstOrDefaultAsync(c => c.Id == id && c.UserId == user.Guid)) is { } character))
                return TypedResults.NotFound($"CharId: {id} not found");

            if (!((await db.CharacterExtras.FirstOrDefaultAsync(extra => extra.Id == extraId)) is { } model))
                return TypedResults.NotFound($"Id: {extraId} not found");

            db.Remove(model);
            await db.SaveChangesAsync();

            return TypedResults.NoContent();
        }

        private static async Task<Results<Created<CharacterSpellSchema>, NotFound<string>>> CreateSpell(Db db,
            ClaimsPrincipal claimsPrincipal, int id, CharacterSpellSchema schema)
        {
            var user = claimsPrincipal.GetUser();
            if (!((await db.Characters.FirstOrDefaultAsync(c => c.Id == id && c.UserId == user.Guid)) is { } character))
                return TypedResults.NotFound($"CharId: {id} not found");

            if (!((await db.Spells.FirstOrDefaultAsync(s => s.Id == schema.SpellId)) is { } spell))
                return TypedResults.NotFound($"spellId: {schema.SpellId} not found");


            var model = schema.ToModel(spell);

            model.Character = character;

            await db.CharacterSpells.AddAsync(model);
            await db.SaveChangesAsync();

            return TypedResults.Created($"/characters/{id}/spells/{model.Id}", new CharacterSpellSchema(model));
        }

        private static async Task<Results<Ok<CharacterSpellSchema>, NotFound<string>, BadRequest<string>>> EditSpell(Db db,
            ClaimsPrincipal claimsPrincipal, int id, CharacterSpellSchema schema)
        {
            var user = claimsPrincipal.GetUser();
            if (!((await db.Characters.FirstOrDefaultAsync(c => c.Id == id && c.UserId == user.Guid)) is { } character))
                return TypedResults.NotFound($"CharId: {id} not found");

            if (!((await db.CharacterSpells.FirstOrDefaultAsync(spell => spell.Id == schema.Id)) is { } model))
                return TypedResults.BadRequest($"Id: {schema.Id} not found");

            if (!((await db.Spells.FirstOrDefaultAsync(s => s.Id == schema.SpellId)) is { } spell))
                return TypedResults.NotFound($"spellId: {schema.SpellId} not found");

            schema.ToModel(spell, model);

            model.Character = character;

            await db.SaveChangesAsync();

            return TypedResults.Ok(new CharacterSpellSchema(model));
        }

        private static async Task<Results<NoContent, NotFound<string>>> DeleteSpell(Db db,
            ClaimsPrincipal claimsPrincipal, int id, int spellId)
        {
            var user = claimsPrincipal.GetUser();
            if (!((await db.Characters.FirstOrDefaultAsync(c => c.Id == id && c.UserId == user.Guid)) is { } character))
                return TypedResults.NotFound($"CharId: {id} not found");

            if (!((await db.CharacterSpells.FirstOrDefaultAsync(spell => spell.Id == spellId)) is { } model))
                return TypedResults.NotFound($"Id: {spellId} not found");

            model.Spell = null;
            db.Remove(model);
            await db.SaveChangesAsync();

            return TypedResults.NoContent();
        }
    }
}