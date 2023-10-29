using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    public class SpellsController : BaseODataController<Spell>
    {
        public SpellsController(Db db, ILogger<SpellsController> logger) :
            base(db, db.Spells, logger, (spell, updatedSpell) =>
        {
            spell.Name = updatedSpell.Name;
            spell.Level = updatedSpell.Level;
            spell.Book = updatedSpell.Book;
            spell.SchoolId = updatedSpell.SchoolId;
            spell.SpellLists = updatedSpell.SpellLists;
            spell.HasVerbalComponent = updatedSpell.HasVerbalComponent;
            spell.HasSomaticComponent = updatedSpell.HasSomaticComponent;
            spell.Materials = updatedSpell.Materials;
            spell.SavingThrow = updatedSpell.SavingThrow;
            spell.DamageTypes = updatedSpell.DamageTypes;
            spell.Action = updatedSpell.Action;
            spell.LongerAction = updatedSpell.LongerAction;
            spell.Range = updatedSpell.Range;
            spell.Duration = updatedSpell.Duration;
            spell.IsConcentration = updatedSpell.IsConcentration;
            spell.IsRitual = updatedSpell.IsRitual;
            spell.Description = updatedSpell.Description;
            spell.HigherLevelDescription = updatedSpell.HigherLevelDescription;
            spell.DamageFormula = updatedSpell.DamageFormula;

            spell.SpellTags.AddRange(spell.SpellTagIds.GetAddedIds(updatedSpell.SpellTagIds)
                                                        .Select(id => db.SpellTags.Find(id)!));
            spell.SpellTags.RemoveAll(tag => spell.SpellTagIds.GetDeletedIds(updatedSpell.SpellTagIds)
                                                            .Contains(tag.Id));

            spell.RelatedConditions.AddRange(spell.RelatedConditionIds.GetAddedIds(updatedSpell.RelatedConditionIds)
                                                                        .Select(id => db.Conditions.Find(id)!));
            spell.RelatedConditions.RemoveAll(condition => spell.RelatedConditionIds.GetDeletedIds(updatedSpell.RelatedConditionIds)
                                                                                    .Contains(condition.Id));

            spell.RestrictedClasses.AddRange(spell.RestrictedClassIds.GetAddedIds(updatedSpell.RestrictedClassIds)
                                                                        .Select(id => db.Classes.Find(id)!));
            spell.RestrictedClasses.RemoveAll(@class => spell.RestrictedClassIds.GetDeletedIds(updatedSpell.RestrictedClassIds)
                                                                                .Contains(@class.Id));
        }, db.Spells.Include(spell => spell.School)
                    .Include(spell => spell.RestrictedClasses)
                    .Include(spell => spell.RelatedConditions)
                    .Include(spell => spell.SpellTags))
        {
        }

    }
}