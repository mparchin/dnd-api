
namespace api.Models
{
    public class Feat : IModel
    {
        public int Id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime? UpdatedOn { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int Level { get; set; }
        public string? Prerequisite { get; set; }
        public string? Repeatable { get; set; }
        public string? Book { get; set; }
    }
}