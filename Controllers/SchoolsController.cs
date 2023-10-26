using api.Models;

namespace api.Controllers
{
    public class SchoolsController : BaseODataController<School>
    {
        public SchoolsController(Db db, ILogger<SchoolsController> logger) :
            base(db, db.Schools, logger, (school, updatedSchool) =>
        {
            school.Name = updatedSchool.Name;
        })
        {
        }
    }
}