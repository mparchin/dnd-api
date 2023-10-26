using api.Models;

namespace api.Controllers
{
    public class SpellTagsController : BaseODataController<SpellTag>
    {
        public SpellTagsController(Db db, ILogger<SpellTagsController> logger) :
            base(db, db.SpellTags, logger, (spellTag, updatedSpellTag) =>
        {
            spellTag.Name = updatedSpellTag.Name;
        })
        {
        }
    }
}