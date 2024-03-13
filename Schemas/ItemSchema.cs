using api.Models;

namespace api.Schemas
{
    public class ItemSchema(Item model) : BaseSchema<Item>(model)
    {
        public string Name { get; set; } = model.Name;
        public string Description { get; set; } = model.Description;
        public string Type { get; set; } = model.Type;
        public double? Weight { get; set; } = model.Weight;
        public double? Cost { get; set; } = model.Cost;
        public string Rarity { get; set; } = model.Rarity;
        public bool NeedsAttunment { get; set; } = model.NeedsAttunment;
        public string? Restrictions { get; set; } = model.Restrictions;
        public string? Properties { get; set; } = model.Properties;
    }
}