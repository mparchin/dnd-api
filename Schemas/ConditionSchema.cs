using api.Models;

namespace api.Schemas
{
    public class ConditionSchema
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public long Time { get; set; }

        public ConditionSchema(Condition condition)
        {
            Name = condition.Name;
            Description = condition.Description;
            Time = Convert.ToInt64(((condition.UpdatedOn ?? new DateTime(2020, 1, 1)).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalMilliseconds);
        }
    }
}