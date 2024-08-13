namespace api.Models
{
    public class Race : IModel
    {
        public int Id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime? UpdatedOn { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Info { get; set; } = "";
        public string ImageUrl { get; set; } = "";
    }
}