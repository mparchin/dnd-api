using api.Models;

namespace api.Schemas
{
    public class CharacterSpellCastingSchema : BaseSchema<CharacterSpellCasting>
    {
        public int UsedMana { get; set; }
        public string CastingAbility { get; set; } = "";
        public string AttackExtra { get; set; } = "";
        public string DcExtra { get; set; } = "";

        public CharacterSpellCastingSchema()
        {

        }

        public CharacterSpellCastingSchema(CharacterSpellCasting model) : base(model)
        {
            UsedMana = model.UsedMana;
            CastingAbility = model.CastingAbility;
            AttackExtra = model.AttackExtra;
            DcExtra = model.DcExtra;
        }
        public CharacterSpellCasting ToModel(CharacterSpellCasting? model = null)
        {
            model ??= new();
            model.UsedMana = UsedMana;
            model.CastingAbility = CastingAbility;
            model.AttackExtra = AttackExtra;
            model.DcExtra = DcExtra;
            return model;
        }
    }
}