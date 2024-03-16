using api.Models;

namespace api.Schemas
{
    public class CharacterSpellCastingSchema : BaseSchema<CharacterSpellCasting>
    {
        public int UsedMana { get; set; }
        public string CastingAbility { get; set; } = "";
        public string AttackExtra { get; set; } = "";
        public string DcExtra { get; set; } = "";
        public bool Used6thLevel { get; set; }
        public bool Used7thLevel { get; set; }
        public bool Used8thLevel { get; set; }
        public bool Used9thLevel { get; set; }

        public CharacterSpellCastingSchema()
        {

        }

        public CharacterSpellCastingSchema(CharacterSpellCasting model) : base(model)
        {
            UsedMana = model.UsedMana;
            CastingAbility = model.CastingAbility;
            AttackExtra = model.AttackExtra;
            DcExtra = model.DcExtra;
            Used6thLevel = model.Used6thLevel;
            Used7thLevel = model.Used7thLevel;
            Used8thLevel = model.Used8thLevel;
            Used9thLevel = model.Used9thLevel;
        }
        public CharacterSpellCasting ToModel(CharacterSpellCasting? model = null)
        {
            model ??= new();
            model.UsedMana = UsedMana;
            model.CastingAbility = CastingAbility;
            model.AttackExtra = AttackExtra;
            model.DcExtra = DcExtra;
            model.Used6thLevel = Used6thLevel;
            model.Used7thLevel = Used7thLevel;
            model.Used8thLevel = Used8thLevel;
            model.Used9thLevel = Used9thLevel;
            return model;
        }
    }
}