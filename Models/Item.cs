namespace api.Models
{
    public class Item : IModel
    {
        public int Id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime? UpdatedOn { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Type { get; set; } = "";
        public double? Weight { get; set; } = 0;
        public double? Cost { get; set; } = 0;
        public string Rarity { get; set; } = "";
        public bool NeedsAttunment { get; set; } = false;
        public string? Restrictions { get; set; }
        public string? Properties { get; set; }
    }
}