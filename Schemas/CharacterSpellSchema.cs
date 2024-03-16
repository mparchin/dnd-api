using api.Models;

namespace api.Schemas
{
    public class CharacterSpellSchema : BaseSchema<CharacterSpell>
    {

        public bool IsPrepared { get; set; }
        public CharacterSpellSchema()
        {

        }

        public CharacterSpellSchema(CharacterSpell model) : base(model)
        {
            IsPrepared = model.IsPrepared;
        }
        public CharacterSpell ToModel(CharacterSpell? model = null)
        {
            model ??= new();
            model.IsPrepared = IsPrepared;
            return model;
        }
    }
}