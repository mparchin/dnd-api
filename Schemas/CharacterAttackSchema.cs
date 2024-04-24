using api.Models;

namespace api.Schemas
{
    public class CharacterAttackSchema : BaseSchema<CharacterAttack>
    {
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public bool IsProficient { get; set; } = false;
        public string ToHitExtra { get; set; } = "";
        public string DamageDie { get; set; } = "";
        public string DamageExtra { get; set; } = "";
        public string SaveAttribute { get; set; } = "";
        public string CustomSaveDC { get; set; } = "";
        public CharacterAttackSchema()
        {

        }

        public CharacterAttackSchema(CharacterAttack model) : base(model)
        {
            Name = model.Name;
            Category = model.Category;
            IsProficient = model.IsProficient;
            ToHitExtra = model.ToHitExtra;
            DamageDie = model.DamageDie;
            DamageExtra = model.DamageExtra;
            CustomSaveDC = model.CustomSaveDC;
            SaveAttribute = model.SaveAttribute;
        }

        public CharacterAttack ToModel(CharacterAttack? model = null)
        {
            model ??= new();
            model.Name = Name;
            model.Category = Category;
            model.IsProficient = IsProficient;
            model.ToHitExtra = ToHitExtra;
            model.DamageDie = DamageDie;
            model.DamageExtra = DamageExtra;
            model.CustomSaveDC = CustomSaveDC;
            model.SaveAttribute = SaveAttribute;
            return model;
        }
    }
}