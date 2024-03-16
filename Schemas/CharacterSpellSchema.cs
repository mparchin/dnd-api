using api.Models;

namespace api.Schemas
{
    public class CharacterSpellSchema : BaseSchema<CharacterSpell>
    {

        public bool IsPrepared { get; set; }
        public int SpellId { get; set; }
        public CharacterSpellSchema()
        {

        }

        public CharacterSpellSchema(CharacterSpell model) : base(model)
        {
            SpellId = model.Spell.Id;
            IsPrepared = model.IsPrepared;
        }
        public CharacterSpell ToModel(Spell spell, CharacterSpell? model = null)
        {
            model ??= new();
            model.IsPrepared = IsPrepared;
            model.Spell = spell;
            return model;
        }
    }
}