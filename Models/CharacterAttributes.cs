
namespace api.Models
{
    public class CharacterAttributes : IModel
    {
        public int Strength { get; set; } = 10;
        public int Dextrity { get; set; } = 10;
        public int Constitution { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public int Wisdom { get; set; } = 10;
        public int Charisma { get; set; } = 10;
        public int Id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime? UpdatedOn { get; set; }
        public List<Character> Characters { get; } = new();
    }
}