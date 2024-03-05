
namespace api.Models
{
    public class Class : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int HitDie { get; set; } = 0;
        public string ProficiencyBonous { get; set; } = "{1=2,2=2}";
        public string ManaPerLevel { get; set; } = "";
        public string CasterSubClassName { get; set; } = "";
        public List<Spell> RestrictedSpells { get; } = new();
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime? UpdatedOn { get; set; } = DateTime.Now;
        public List<Feature> Features { get; } = new();
        public List<Character> Characters { get; } = new();

    }
}