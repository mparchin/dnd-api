using api.Models;

namespace api.Controllers
{
    public class BackgroundsController(Db db, ILogger<BackgroundsController> logger) : BaseODataController<Background>(db, db.Backgrounds, logger, (item, updatedItem) =>
    {
        item.Name = updatedItem.Name;
        item.Description = updatedItem.Description;
        item.Info = updatedItem.Info;
        item.Skills = updatedItem.Skills;
    }, db.Backgrounds)
    {

    }
}