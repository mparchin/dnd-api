namespace api.Models
{
    public class SpellTag : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<Spell> Spells { get; } = new();
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime? UpdatedOn { get; set; } = DateTime.Now;
    }
}