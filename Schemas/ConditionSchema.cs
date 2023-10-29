using api.Models;

namespace api.Schemas
{
    public class ConditionSchema
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public ConditionSchema(Condition condition)
        {
            Name = condition.Name;
            Description = condition.Description;
        }
    }
}