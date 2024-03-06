using api.Models;

namespace api.Schemas
{
    public class CharacterExpertSchema : BaseSchema<CharacterExpert>
    {
        public bool HasAdvantage { get; set; }
        public bool IsProficient { get; set; }
        public bool IsExpert { get; set; }
        public string AttributeName { get; set; } = "";
        public string ExtraText { get; set; } = "";

        public CharacterExpertSchema()
        {

        }

        public CharacterExpertSchema(CharacterExpert model) : base(model)
        {
            HasAdvantage = model.HasAdvantage;
            IsProficient = model.IsProficient;
            IsExpert = model.IsExpert;
            AttributeName = model.AttributeName;
            ExtraText = model.ExtraText;
        }

        public CharacterExpert ToModel(CharacterExpert? model = null)
        {
            model ??= new();
            model.HasAdvantage = HasAdvantage;
            model.IsProficient = IsProficient;
            model.IsExpert = IsExpert;
            model.AttributeName = AttributeName;
            model.ExtraText = ExtraText;
            return model;
        }
    }
}