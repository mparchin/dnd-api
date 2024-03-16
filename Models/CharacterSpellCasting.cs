namespace api.Models
{
    public class CharacterSpellCasting : IModel
    {
        public int UsedMana { get; set; } = 0;
        public string CastingAbility { get; set; } = "";
        public string AttackExtra { get; set; } = "";
        public string DcExtra { get; set; } = "";
        public bool Used6thLevel { get; set; }
        public bool Used7thLevel { get; set; }
        public bool Used8thLevel { get; set; }
        public bool Used9thLevel { get; set; }
        public int Id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime? UpdatedOn { get; set; }
        public List<Character> Characters { get; } = [];
    }
}