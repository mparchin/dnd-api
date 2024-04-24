using api.Models;

namespace api.Schemas
{
    public class ItemEffectSchema : BaseSchema<ItemEffect>
    {
        public string Name { get; set; } = "";
        public string Extra { get; set; } = "";
        public ItemEffectSchema()
        {

        }

        public ItemEffectSchema(ItemEffect model) : base(model)
        {
            Name = model.Name;
            Extra = model.Extra;
        }

        public ItemEffect ToModel(ItemEffect? model = null)
        {
            model ??= new();
            model.Name = Name;
            model.Extra = Extra;
            return model;
        }
    }
}