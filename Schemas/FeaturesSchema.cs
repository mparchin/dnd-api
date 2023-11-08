using api.Models;

namespace api.Schemas
{
    public class FeaturesSchema
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int Level { get; set; }
        public int? Order { get; set; }
        public string? Subclass { get; set; }
        public string? ClassName { get; set; }
        public long Time { get; set; }

        public FeaturesSchema(Feature feature)
        {
            Id = feature.Id;
            Name = feature.Name;
            Description = feature.Description;
            Level = feature.Level;
            Order = feature.Order;
            Subclass = feature.Subclass;
            ClassName = feature.Class?.Name;
            Time = Convert.ToInt64(((feature.UpdatedOn ?? new DateTime(2020, 1, 1)).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalMilliseconds);
        }

    }
}