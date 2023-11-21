using api.Models;

namespace api.Schemas
{
    public class RuleSchema : BaseSchema<Rule>
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Category { get; set; } = "";
        public int? Order { get; set; }

        public RuleSchema(Rule rule) : base(rule)
        {
            Name = rule.Name;
            Description = rule.Description;
            Category = rule.Category;
            Order = rule.Order;
        }

    }
}