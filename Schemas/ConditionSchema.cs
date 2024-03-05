using api.Models;

namespace api.Schemas
{
    public class ConditionSchema(Condition condition) : BaseSchema<Condition>(condition)
    {
        public string Name { get; set; } = condition.Name;
        public string Description { get; set; } = condition.Description;
    }
}