namespace api.Models
{
    public class CharacterSpell : IModel
    {
        public bool IsPrepared { get; set; }
        public bool IsAlwaysPrepared { get; set; }
        public int Id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime? UpdatedOn { get; set; }
        public Character Character { get; set; } = new();
        public Spell? Spell { get; set; } = new();
    }
}