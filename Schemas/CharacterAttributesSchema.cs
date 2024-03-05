using api.Models;

namespace api.Schemas
{
    public class CharacterAttributesSchema(CharacterAttributes model) : BaseSchema<CharacterAttributes>(model)
    {
        public int Strength { get; set; } = model.Strength;
        public int Dextrity { get; set; } = model.Dextrity;
        public int Constitution { get; set; } = model.Constitution;
        public int Intelligence { get; set; } = model.Intelligence;
        public int Wisdom { get; set; } = model.Wisdom;
        public int Charisma { get; set; } = model.Charisma;

        public CharacterAttributes ToModel() => new()
        {
            Strength = Strength,
            Dextrity = Dextrity,
            Constitution = Constitution,
            Intelligence = Intelligence,
            Wisdom = Wisdom,
            Charisma = Charisma,
        };
    }
}