using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    public class FeaturesController : BaseODataController<Feature>
    {
        public FeaturesController(Db db, ILogger<FeaturesController> logger) :
            base(db, db.Features, logger, (feature, updatedFeature) =>
        {
            feature.Name = updatedFeature.Name;
            feature.Description = updatedFeature.Description;
            feature.Level = updatedFeature.Level;
            feature.Order = updatedFeature.Order;
            feature.Subclass = updatedFeature.Subclass;
            feature.ClassId = updatedFeature.ClassId;
            feature.IsDetails = updatedFeature.IsDetails;
        }, db.Features.Include(feature => feature.Class))
        {
        }
    }
}