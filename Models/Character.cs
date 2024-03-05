namespace api.Models
{
    public class Character : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Race { get; set; } = "";
        public string Background { get; set; } = "";
        public string? Image { get; set; }
        public Class Class { get; set; } = new();
        public string SubClassName { get; set; } = "";
        public int Level { get; set; } = 1;
        public CharacterAttributes Attributes { get; set; } = new();
        public int Speed { get; set; } = 30;
        public CharacterExpert Inititive { get; set; } = new("dex");
        public string ArmorClassExtra { get; set; } = "10";
        public CharacterHitpoint Hp { get; set; } = new();
        public CharacterSpellCasting SpellCasting { get; set; } = new();

        public CharacterExpert StrengthSave { get; set; } = new("str");
        public CharacterExpert DextritySave { get; set; } = new("dex");
        public CharacterExpert ConstitutionSave { get; set; } = new("con");
        public CharacterExpert IntelligenceSave { get; set; } = new("int");
        public CharacterExpert WisdomSave { get; set; } = new("wis");
        public CharacterExpert CharismaSave { get; set; } = new("cha");

        public CharacterExpert Athletics { get; set; } = new("str");
        public CharacterExpert Acrobatics { get; set; } = new("dex");
        public CharacterExpert SleightOfHands { get; set; } = new("dex");
        public CharacterExpert Stealth { get; set; } = new("dex");
        public CharacterExpert Arcana { get; set; } = new("int");
        public CharacterExpert History { get; set; } = new("int");
        public CharacterExpert Investigation { get; set; } = new("int");
        public CharacterExpert Nature { get; set; } = new("int");
        public CharacterExpert Religion { get; set; } = new("int");
        public CharacterExpert AnimalHandling { get; set; } = new("wis");
        public CharacterExpert Insight { get; set; } = new("wis");
        public CharacterExpert Medicine { get; set; } = new("wis");
        public CharacterExpert Perception { get; set; } = new("wis");
        public CharacterExpert Survival { get; set; } = new("wis");
        public CharacterExpert Deception { get; set; } = new("cha");
        public CharacterExpert Intimidation { get; set; } = new("cha");
        public CharacterExpert Performance { get; set; } = new("cha");
        public CharacterExpert Persuasion { get; set; } = new("cha");


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public Guid UserId { get; set; } = Guid.NewGuid();


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime? UpdatedOn { get; set; }
    }
}