namespace api.Schemas
{
    public class SpellSchema
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Level { get; set; }
        public string? Book { get; set; }
        public string? SchoolName { get; set; } = "";
        public string SpellListName { get; set; } = "";
        public bool HasVerbalComponent { get; set; }
        public bool HasSomaticComponent { get; set; }
        public bool HasMaterialComponent =>
            !string.IsNullOrEmpty(Materials) || !string.IsNullOrWhiteSpace(Materials);
        public string? Materials { get; set; }
        public string[] SpellTags { get; set; } = Array.Empty<string>();
        public string? SavingThrow { get; set; }
        public string? DamageTypes { get; set; }
        public string Action { get; set; } = "";
        public string? LongerAction { get; set; }
        public string Range { get; set; } = "";
        public string Duration { get; set; } = "";
        public bool IsConcentration { get; set; }
        public bool IsRitual { get; set; }
        public string[] RestrictedClasses { get; set; } = Array.Empty<string>();
        public string Description { get; set; } = "";
        public string? HigherLevelDescription { get; set; }
        public string? DamageFormula { get; set; }
        public ConditionSchema[] RelatedConditions { get; set; } = Array.Empty<ConditionSchema>();

        public SpellSchema() { }

        public SpellSchema(Models.Spell model)
        {
            Id = model.Id;
            Name = model.Name;
            Level = model.Level;
            Book = model.Book;
            SchoolName = model.School?.Name;
            SpellListName = string.Join(",", model.SpellLists.Select(s => s.ToString()));
            HasVerbalComponent = model.HasVerbalComponent;
            HasSomaticComponent = model.HasSomaticComponent;
            Materials = model.Materials;
            SpellTags = model.SpellTags?.Select(tags => tags.Name).ToArray() ?? Array.Empty<string>();
            SavingThrow = model.SavingThrow.ToString();
            DamageTypes = model.DamageTypes.Any() ? string.Join(",", model.DamageTypes.Select(s => s.ToString())) : null;
            Action = model.Action.ToString();
            LongerAction = model.LongerAction;
            Range = model.Range;
            Duration = model.Duration;
            IsConcentration = model.IsConcentration;
            IsRitual = model.IsRitual;
            RestrictedClasses = model.RestrictedClasses?.Select(@class => @class.Name).ToArray() ?? Array.Empty<string>();
            Description = model.Description;
            HigherLevelDescription = model.HigherLevelDescription;
            DamageFormula = model.DamageFormula;
            RelatedConditions = model.RelatedConditions?.Select(condition => new ConditionSchema(condition)).ToArray()
                 ?? Array.Empty<ConditionSchema>();
        }
    }
}