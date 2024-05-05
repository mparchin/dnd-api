namespace api.Models
{
    public class ItemEffect : IModel
    {
        public int Id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime? UpdatedOn { get; set; }
        public CharacterItem Item { get; set; } = new();
        public Effect Effect { get; set; }
        public string Extra { get; set; } = "";
    }
}