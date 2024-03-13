using api.Models;

namespace api.Controllers
{
    public class ItemsController(Db db, ILogger<ItemsController> logger) : BaseODataController<Item>(db, db.Items, logger, (item, updatedItem) =>
    {
        item.Name = updatedItem.Name;
        item.Cost = updatedItem.Cost;
        item.Description = updatedItem.Description;
        item.Weight = updatedItem.Weight;
        item.Restrictions = updatedItem.Restrictions;
        item.Type = updatedItem.Type;
        item.Rarity = updatedItem.Rarity;
        item.NeedsAttunment = updatedItem.NeedsAttunment;
        item.Properties = updatedItem.Properties;
    }, db.Items)
    {

    }
}