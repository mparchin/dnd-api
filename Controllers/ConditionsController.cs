using api.Models;

namespace api.Controllers
{
    public class ConditionsController : BaseODataController<Condition>
    {
        public ConditionsController(Db db, ILogger<ConditionsController> logger) :
            base(db, db.Conditions, logger, (condition, updatedCondition) =>
        {
            condition.Name = updatedCondition.Name;
            condition.Description = updatedCondition.Description;
        })
        {
        }
    }
}