namespace api.Models
{
    public class CharacterAttack : IModel
    {
        public int Id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime? UpdatedOn { get; set; }
        public Character Character { get; set; } = new();
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public bool IsProficient { get; set; } = false;
        public string ToHitExtra { get; set; } = "";
        public string DamageDie { get; set; } = "";
        public string DamageExtra { get; set; } = "";
        public string SaveAttribute { get; set; } = "";
        public string CustomSaveDC { get; set; } = "";
        public string DamageType { get; set; } = "";
    }
}