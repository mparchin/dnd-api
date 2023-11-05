using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace api.Models
{
    public class Spell : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Level { get; set; }
        public string? Book { get; set; }
        public int? SchoolId { get; set; }
        public School? School { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public string SpellListsString { get; set; } = "[]";
        [NotMapped]
        public SpellLists[] SpellLists
        {
            get => JsonConvert.DeserializeObject<SpellLists[]>(SpellListsString) ?? Array.Empty<SpellLists>();
            set => SpellListsString = JsonConvert.SerializeObject(value);
        }
        public bool HasVerbalComponent { get; set; }
        public bool HasSomaticComponent { get; set; }
        public bool HasMaterialComponent =>
            !string.IsNullOrEmpty(Materials) || !string.IsNullOrWhiteSpace(Materials);
        public string? Materials { get; set; }
        public List<SpellTag> SpellTags { get; } = new();
        [NotMapped]
        [System.Text.Json.Serialization.JsonIgnore]
        private int[]? _spellTagIds;
        [NotMapped]
        public int[] SpellTagIds
        {
            get => _spellTagIds ?? SpellTags.Select(st => st.Id).ToArray();
            set => _spellTagIds = value;
        }
        public SavingThrows? SavingThrow { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public string DamageTypesString { get; set; } = "[]";
        [NotMapped]
        public DamageTypes[] DamageTypes
        {
            get => JsonConvert.DeserializeObject<DamageTypes[]>(DamageTypesString)
                ?? Array.Empty<DamageTypes>();
            set => DamageTypesString = JsonConvert.SerializeObject(value);
        }
        public Actions Action { get; set; }
        public string? LongerAction { get; set; }
        public string Range { get; set; } = "";
        public string Duration { get; set; } = "";
        public bool IsConcentration { get; set; }
        public bool IsRitual { get; set; }
        public List<Class> RestrictedClasses { get; } = new();
        [NotMapped]
        [System.Text.Json.Serialization.JsonIgnore]
        private int[]? _restrictedClasses;
        [NotMapped]
        public int[] RestrictedClassIds
        {
            get => _restrictedClasses ?? RestrictedClasses.Select(rc => rc.Id).ToArray();
            set => _restrictedClasses = value;
        }
        public string Description { get; set; } = "";
        public string? HigherLevelDescription { get; set; }
        public string? DamageFormula { get; set; }
        public List<Condition> RelatedConditions { get; } = new();
        [NotMapped]
        [System.Text.Json.Serialization.JsonIgnore]
        private int[]? _relatedConditionIds;
        [NotMapped]
        public int[] RelatedConditionIds
        {
            get => _relatedConditionIds ?? RelatedConditions.Select(rc => rc.Id).ToArray();
            set => _relatedConditionIds = value;
        }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}