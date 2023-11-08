
namespace api.Models
{
    public class Feature : IModel
    {
        public int Id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime? UpdatedOn { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int Level { get; set; }
        public int? Order { get; set; }
        public string? Subclass { get; set; }
        public int? ClassId { get; set; }
        public Class? Class { get; set; }
    }
}