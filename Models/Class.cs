
namespace api.Models
{
    public class Class : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<Spell> RestrictedSpells { get; } = new();
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime? UpdatedOn { get; set; } = DateTime.Now;
    }
}