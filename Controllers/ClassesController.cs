using api.Models;

namespace api.Controllers
{
    public class ClassesController : BaseODataController<Class>
    {
        public ClassesController(Db db, ILogger<ClassesController> logger) :
            base(db, db.Classes, logger, (@class, updatedClass) =>
        {
            @class.Name = updatedClass.Name;
            @class.HitDie = updatedClass.HitDie;
            @class.ProficiencyBonous = updatedClass.ProficiencyBonous;
        })
        {
        }
    }
}