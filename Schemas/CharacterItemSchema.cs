using api.Models;

namespace api.Schemas
{
    public class CharacterItemSchema : BaseSchema<CharacterItem>
    {
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public string Description { get; set; } = "";
        public bool NeedsAttunment { get; set; } = false;
        public bool IsAttuned { get; set; } = false;
        public bool IsEquipped { get; set; } = false;
        public double? Weight { get; set; }
        public double? Cost { get; set; }
        public int Quantity { get; set; } = 1;
        public List<ItemEffectSchema> Effects { get; set; } = [];

        public CharacterItemSchema()
        {

        }

        public CharacterItemSchema(CharacterItem model) : base(model)
        {
            Name = model.Name;
            Category = model.Category;
            Description = model.Description;
            NeedsAttunment = model.NeedsAttunment;
            IsAttuned = model.IsAttuned;
            IsEquipped = model.IsEquipped;
            Weight = model.Weight;
            Cost = model.Cost;
            Quantity = model.Quantity;
            Effects = model.Effects.Select(e => new ItemEffectSchema(e)).ToList();
        }

        public CharacterItem ToModel(CharacterItem? model = null)
        {
            model ??= new();
            model.Name = Name;
            model.Category = Category;
            model.Description = Description;
            model.NeedsAttunment = NeedsAttunment;
            model.IsAttuned = IsAttuned;
            model.IsEquipped = IsEquipped;
            model.Weight = Weight;
            model.Cost = Cost;
            model.Quantity = Quantity;
            return model;
        }
    }
}