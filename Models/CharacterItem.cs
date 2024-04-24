namespace api.Models
{
    public class CharacterItem : IModel
    {
        public int Id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime? UpdatedOn { get; set; }
        public Character Character { get; set; } = new();
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public string Description { get; set; } = "";
        public bool NeedsAttunment { get; set; } = false;
        public bool IsAttuned { get; set; } = false;
        public double? Weight { get; set; }
        public double? Cost { get; set; }
        public int Quantity { get; set; } = 1;
        public List<ItemEffect> Effects { get; set; } = [];
    }
}