using api.Models;

namespace api.Schemas
{
    public class CharacterExpertSchema(CharacterExpert model) : BaseSchema<CharacterExpert>(model)
    {
        public bool HasAdvantage { get; set; } = model.HasAdvantage;
        public bool IsProficient { get; set; } = model.IsProficient;
        public bool IsExpert { get; set; } = model.IsExpert;
        public string AttributeName { get; set; } = model.AttributeName;
        public string ExtraText { get; set; } = model.ExtraText;

        public CharacterExpert ToModel() => new()
        {
            HasAdvantage = HasAdvantage,
            IsProficient = IsProficient,
            IsExpert = IsExpert,
            AttributeName = AttributeName,
            ExtraText = ExtraText,
        };
    }
}