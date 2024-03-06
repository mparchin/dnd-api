using api.Models;

namespace api.Schemas
{
    public class CharacterAttributesSchema : BaseSchema<CharacterAttributes>
    {
        public int Strength { get; set; } = 10;
        public int Dextrity { get; set; } = 10;
        public int Constitution { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public int Wisdom { get; set; } = 10;
        public int Charisma { get; set; } = 10;

        public CharacterAttributesSchema()
        {

        }

        public CharacterAttributesSchema(CharacterAttributes model) : base(model)
        {
            Strength = model.Strength;
            Dextrity = model.Dextrity;
            Constitution = model.Constitution;
            Intelligence = model.Intelligence;
            Wisdom = model.Wisdom;
            Charisma = model.Charisma;
        }

        public CharacterAttributes ToModel(CharacterAttributes? model = null)
        {
            model ??= new();
            model.Strength = Strength;
            model.Dextrity = Dextrity;
            model.Constitution = Constitution;
            model.Intelligence = Intelligence;
            model.Wisdom = Wisdom;
            model.Charisma = Charisma;
            return model;
        }
    }
}