using api.Models;

namespace api.Schemas
{
    public class BackgroundSchema(Background model) : BaseSchema<Background>(model)
    {
        public string Name { get; set; } = model.Name;
        public string Description { get; set; } = model.Description;
        public string Info { get; set; } = model.Info;
        public string Skills { get; set; } = model.Skills;
    }
}