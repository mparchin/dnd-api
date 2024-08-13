using api.Models;

namespace api.Controllers
{
    public class RacesController(Db db, ILogger<RacesController> logger) : BaseODataController<Race>(db, db.Races, logger, (item, updatedItem) =>
    {
        item.Name = updatedItem.Name;
        item.Description = updatedItem.Description;
        item.Info = updatedItem.Info;
        item.ImageUrl = updatedItem.ImageUrl;
    }, db.Races)
    {

    }
}