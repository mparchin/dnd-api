using api.Models;

namespace api.Schemas
{
    public class CharacterSpellSchema : BaseSchema<CharacterSpell>
    {

        public bool IsPrepared { get; set; }
        public bool IsAlwaysPrepared { get; set; }
        public int SpellId { get; set; }
        public CharacterSpellSchema()
        {

        }

        public CharacterSpellSchema(CharacterSpell model) : base(model)
        {
            SpellId = model.Spell?.Id ?? 0;
            IsPrepared = model.IsPrepared;
            IsAlwaysPrepared = model.IsAlwaysPrepared;
        }
        public CharacterSpell ToModel(Spell spell, CharacterSpell? model = null)
        {
            model ??= new();
            model.IsPrepared = IsPrepared;
            model.IsAlwaysPrepared = IsAlwaysPrepared;
            model.Spell = spell;
            return model;
        }
    }
}