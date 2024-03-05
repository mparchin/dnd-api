namespace api.Models
{
    public class CharacterHitpoint : IModel
    {
        public int? CustomMaximum { get; set; }
        public string AverageMaximumExtra { get; set; } = "";
        public int MaximumModifire { get; set; } = 0;
        public int Temp { get; set; } = 0;
        public int DamageTakenAfterTemp { get; set; } = 0;
        public int Id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime? UpdatedOn { get; set; }
        public List<Character> Characters { get; } = new();
    }
}