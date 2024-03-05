using api.Models;

namespace api.Schemas
{
    public class FeaturesSchema(Feature feature) : BaseSchema<Feature>(feature)
    {
        public string Name { get; set; } = feature.Name;
        public string Description { get; set; } = feature.Description;
        public int Level { get; set; } = feature.Level;
        public int? Order { get; set; } = feature.Order;
        public string? Subclass { get; set; } = feature.Subclass;
        public string? ClassName { get; set; } = feature.Class?.Name;
        public bool IsDetails { get; set; } = feature.IsDetails;
    }
}