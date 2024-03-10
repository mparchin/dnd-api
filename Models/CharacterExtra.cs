
namespace api.Models
{
    public class CharacterExtra : IModel
    {
        public int Id { get; set; }
        public Character Character { get; set; } = new();
        public string Name { get; set; } = "";
        public string MaximumFormula { get; set; } = "";
        public int Used { get; set; }
        public bool RefreshOnShortRest { get; set; } = false;
        public bool RefreshOnLongRest { get; set; } = false;
        public string CustomRefreshFormula { get; set; } = "";

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime? UpdatedOn { get; set; }
    }
}