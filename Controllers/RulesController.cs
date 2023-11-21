using api.Models;

namespace api.Controllers
{
    public class RulesController : BaseODataController<Rule>
    {
        public RulesController(Db db, ILogger<RulesController> logger) :
            base(db, db.Rules, logger, (rule, updatedRule) =>
        {
            rule.Name = updatedRule.Name;
            rule.Category = updatedRule.Category;
            rule.Description = updatedRule.Description;
            rule.Order = updatedRule.Order;
        }, db.Rules)
        {
        }
    }
}