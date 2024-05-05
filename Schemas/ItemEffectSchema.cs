using api.Models;

namespace api.Schemas
{
    public class ItemEffectSchema : BaseSchema<ItemEffect>
    {
        public Effect Effect { get; set; }
        public string Extra { get; set; } = "";
        public ItemEffectSchema()
        {

        }

        public ItemEffectSchema(ItemEffect model) : base(model)
        {
            Effect = model.Effect;
            Extra = model.Extra;
        }

        public ItemEffect ToModel(ItemEffect? model = null)
        {
            model ??= new();
            model.Effect = Effect;
            model.Extra = Extra;
            return model;
        }
    }
}