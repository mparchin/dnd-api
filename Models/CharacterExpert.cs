
namespace api.Models
{
    public class CharacterExpert(string attributeName = "") : IModel
    {
        public bool HasAdvantage { get; set; }
        public bool IsProficient { get; set; }
        public bool IsExpert { get; set; }
        public string AttributeName { get; set; } = attributeName;
        public string ExtraText { get; set; } = "";
        public int Id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime? UpdatedOn { get; set; }
    }
}