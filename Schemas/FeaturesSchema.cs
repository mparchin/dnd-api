using api.Models;

namespace api.Schemas
{
    public class FeaturesSchema : BaseSchema<Feature>
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int Level { get; set; }
        public int? Order { get; set; }
        public string? Subclass { get; set; }
        public string? ClassName { get; set; }

        public FeaturesSchema(Feature feature) : base(feature)
        {
            Name = feature.Name;
            Description = feature.Description;
            Level = feature.Level;
            Order = feature.Order;
            Subclass = feature.Subclass;
            ClassName = feature.Class?.Name;
        }

    }
}