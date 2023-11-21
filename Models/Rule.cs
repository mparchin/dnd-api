namespace api.Models
{
    public class Rule : IModel
    {
        public int Id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime? UpdatedOn { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Category { get; set; } = "";
        public int? Order { get; set; }
    }
}