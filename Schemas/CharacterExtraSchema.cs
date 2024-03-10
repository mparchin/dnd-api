using api.Models;

namespace api.Schemas
{
    public class CharacterExtraSchema : BaseSchema<CharacterExtra>
    {
        public string Name { get; set; } = "";
        public string MaximumFormula { get; set; } = "";
        public int Used { get; set; }
        public bool RefreshOnShortRest { get; set; } = false;
        public bool RefreshOnLongRest { get; set; } = false;
        public string CustomRefreshFormula { get; set; } = "";

        public CharacterExtraSchema()
        {

        }

        public CharacterExtraSchema(CharacterExtra model) : base(model)
        {
            Name = model.Name;
            MaximumFormula = model.MaximumFormula;
            Used = model.Used;
            RefreshOnShortRest = model.RefreshOnShortRest;
            RefreshOnLongRest = model.RefreshOnLongRest;
            CustomRefreshFormula = model.CustomRefreshFormula;
        }

        public CharacterExtra ToModel(CharacterExtra? model = null)
        {
            model ??= new();
            model.Name = Name;
            model.MaximumFormula = MaximumFormula;
            model.Used = Used;
            model.RefreshOnLongRest = RefreshOnLongRest;
            model.RefreshOnShortRest = RefreshOnShortRest;
            model.CustomRefreshFormula = CustomRefreshFormula;
            return model;
        }
    }
}