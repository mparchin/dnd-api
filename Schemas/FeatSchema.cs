using api.Models;

namespace api.Schemas
{
    public class FeatSchema(Feat feat) : BaseSchema<Feat>(feat)
    {
        public string Name { get; set; } = feat.Name;
        public string Description { get; set; } = feat.Description;
        public int Level { get; set; } = feat.Level;
        public string? Prerequisite { get; set; } = feat.Prerequisite;
        public string? Repeatable { get; set; } = feat.Repeatable;
        public string? Book { get; set; } = feat.Book;
    }
}