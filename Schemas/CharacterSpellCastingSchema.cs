using api.Models;

namespace api.Schemas
{
    public class CharacterSpellCastingSchema(CharacterSpellCasting model) : BaseSchema<CharacterSpellCasting>(model)
    {
        public int UsedMana { get; set; } = model.UsedMana;
        public string CastingAbility { get; set; } = model.CastingAbility;
        public string AttackExtra { get; set; } = model.AttackExtra;
        public string DcExtra { get; set; } = model.DcExtra;

        public CharacterSpellCasting ToModel() => new()
        {
            UsedMana = UsedMana,
            CastingAbility = CastingAbility,
            AttackExtra = AttackExtra,
            DcExtra = DcExtra
        };
    }
}