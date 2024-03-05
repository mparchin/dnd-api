using api.Models;

namespace api.Schemas
{
    public class RuleSchema(Rule rule) : BaseSchema<Rule>(rule)
    {
        public string Name { get; set; } = rule.Name;
        public string Description { get; set; } = rule.Description;
        public string Category { get; set; } = rule.Category;
        public int? Order { get; set; } = rule.Order;
    }
}