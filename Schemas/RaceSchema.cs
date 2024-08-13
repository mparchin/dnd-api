using api.Models;

namespace api.Schemas
{
    public class RaceSchema(Race model) : BaseSchema<Race>(model)
    {
        public string Name { get; set; } = model.Name;
        public string Description { get; set; } = model.Description;
        public string Info { get; set; } = model.Info;
        public string ImageUrl { get; set; } = model.ImageUrl;
    }
}