using api.Models;

namespace api.Controllers
{
    public class FeatsController : BaseODataController<Feat>
    {
        public FeatsController(Db db, ILogger<FeatsController> logger) :
            base(db, db.Feats, logger, (feat, updatedFeat) =>
        {
            feat.Name = updatedFeat.Name;
            feat.Description = updatedFeat.Description;
            feat.Level = updatedFeat.Level;
            feat.Prerequisite = updatedFeat.Prerequisite;
        })
        {
        }
    }
}