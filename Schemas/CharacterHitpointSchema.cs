using api.Models;

namespace api.Schemas
{
    public class CharacterHitpointSchema(CharacterHitpoint model) : BaseSchema<CharacterHitpoint>(model)
    {
        public int? CustomMaximum { get; set; } = model.CustomMaximum;
        public string AverageMaximumExtra { get; set; } = model.AverageMaximumExtra;
        public int MaximumModifire { get; set; } = model.MaximumModifire;
        public int Temp { get; set; } = model.Temp;
        public int DamageTakenAfterTemp { get; set; } = model.DamageTakenAfterTemp;
    }
}