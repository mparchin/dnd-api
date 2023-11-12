using api.Models;

namespace api.Schemas
{
    public class ConditionSchema : BaseSchema<Condition>
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public ConditionSchema(Condition condition) : base(condition)
        {
            Name = condition.Name;
            Description = condition.Description;
        }
    }
}