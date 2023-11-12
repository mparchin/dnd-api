using api.Models;

namespace api.Schemas
{
    public class FeatSchema : BaseSchema<Feat>
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int Level { get; set; }
        public string? Prerequisite { get; set; }

        public FeatSchema(Feat feat) : base(feat)
        {
            Name = feat.Name;
            Description = feat.Description;
            Level = feat.Level;
            Prerequisite = feat.Prerequisite;
        }

    }
}