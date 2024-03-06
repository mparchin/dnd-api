using api.Models;

namespace api.Schemas
{
    public class CharacterHitpointSchema : BaseSchema<CharacterHitpoint>
    {
        public int? CustomMaximum { get; set; }
        public string AverageMaximumExtra { get; set; } = "";
        public int MaximumModifire { get; set; }
        public int Temp { get; set; }
        public int DamageTakenAfterTemp { get; set; }

        public CharacterHitpointSchema()
        {

        }

        public CharacterHitpointSchema(CharacterHitpoint model) : base(model)
        {
            CustomMaximum = model.CustomMaximum;
            AverageMaximumExtra = model.AverageMaximumExtra;
            MaximumModifire = model.MaximumModifire;
            Temp = model.Temp;
            DamageTakenAfterTemp = model.DamageTakenAfterTemp;
        }


        public CharacterHitpoint ToModel(CharacterHitpoint? model = null)
        {
            model ??= new();
            model.CustomMaximum = CustomMaximum;
            model.AverageMaximumExtra = AverageMaximumExtra;
            model.MaximumModifire = MaximumModifire;
            model.Temp = Temp;
            model.DamageTakenAfterTemp = DamageTakenAfterTemp;
            return model;
        }
    }
}