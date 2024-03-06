using api.Models;

namespace api.Schemas
{
    public class CharacterSchema : BaseSchema<Character>
    {
        public string Name { get; set; } = "";
        public string Race { get; set; } = "";
        public string Background { get; set; } = "";
        public string? Image { get; set; }
        public ClassSchema Class { get; set; } = new();
        public string SubClassName { get; set; } = "";
        public int Level { get; set; } = 1;
        public CharacterAttributesSchema Attributes { get; set; } = new();
        public int Speed { get; set; } = 30;
        public CharacterExpertSchema Inititive { get; set; } = new();
        public string ArmorClassExtra { get; set; } = "10";
        public CharacterHitpointSchema Hp { get; set; } = new();
        public CharacterSpellCastingSchema SpellCasting { get; set; } = new();

        public CharacterExpertSchema StrengthSave { get; set; } = new();
        public CharacterExpertSchema DextritySave { get; set; } = new();
        public CharacterExpertSchema ConstitutionSave { get; set; } = new();
        public CharacterExpertSchema IntelligenceSave { get; set; } = new();
        public CharacterExpertSchema WisdomSave { get; set; } = new();
        public CharacterExpertSchema CharismaSave { get; set; } = new();

        public CharacterExpertSchema Athletics { get; set; } = new();
        public CharacterExpertSchema Acrobatics { get; set; } = new();
        public CharacterExpertSchema SleightOfHands { get; set; } = new();
        public CharacterExpertSchema Stealth { get; set; } = new();
        public CharacterExpertSchema Arcana { get; set; } = new();
        public CharacterExpertSchema History { get; set; } = new();
        public CharacterExpertSchema Investigation { get; set; } = new();
        public CharacterExpertSchema Nature { get; set; } = new();
        public CharacterExpertSchema Religion { get; set; } = new();
        public CharacterExpertSchema AnimalHandling { get; set; } = new();
        public CharacterExpertSchema Insight { get; set; } = new();
        public CharacterExpertSchema Medicine { get; set; } = new();
        public CharacterExpertSchema Perception { get; set; } = new();
        public CharacterExpertSchema Survival { get; set; } = new();
        public CharacterExpertSchema Deception { get; set; } = new();
        public CharacterExpertSchema Intimidation { get; set; } = new();
        public CharacterExpertSchema Performance { get; set; } = new();
        public CharacterExpertSchema Persuasion { get; set; } = new();

        public CharacterSchema()
        {

        }

        public CharacterSchema(Character model) : base(model)
        {
            Name = model.Name;
            Race = model.Race;
            Background = model.Background;
            Image = model.Image;
            Class = new(model.Class);
            SubClassName = model.SubClassName;
            Level = model.Level;
            Attributes = new(model.Attributes);
            Speed = model.Speed;
            Inititive = new(model.Inititive);
            ArmorClassExtra = model.ArmorClassExtra;
            Hp = new(model.Hp);
            SpellCasting = new(model.SpellCasting);

            StrengthSave = new(model.StrengthSave);
            DextritySave = new(model.DextritySave);
            ConstitutionSave = new(model.ConstitutionSave);
            IntelligenceSave = new(model.IntelligenceSave);
            WisdomSave = new(model.WisdomSave);
            CharismaSave = new(model.CharismaSave);

            Athletics = new(model.Athletics);
            Acrobatics = new(model.Acrobatics);
            SleightOfHands = new(model.SleightOfHands);
            Stealth = new(model.Stealth);
            Arcana = new(model.Arcana);
            History = new(model.History);
            Investigation = new(model.Investigation);
            Nature = new(model.Nature);
            Religion = new(model.Religion);
            AnimalHandling = new(model.AnimalHandling);
            Insight = new(model.Insight);
            Medicine = new(model.Medicine);
            Perception = new(model.Perception);
            Survival = new(model.Survival);
            Deception = new(model.Deception);
            Intimidation = new(model.Intimidation);
            Performance = new(model.Performance);
            Persuasion = new(model.Persuasion);

            Time = new List<long>
            {
                Convert.ToInt64(((model?.UpdatedOn ?? new DateTime(2020, 1, 1))
                    .ToUniversalTime() - new DateTime(1970, 1, 1)).TotalMilliseconds),
                Class.Time, Attributes.Time,
                Inititive.Time, SpellCasting.Time,
                Hp.Time, StrengthSave.Time, DextritySave.Time,
                ConstitutionSave.Time, IntelligenceSave.Time,
                WisdomSave.Time, CharismaSave.Time,
                Athletics.Time,
                Acrobatics.Time,SleightOfHands.Time, Stealth.Time,
                Arcana.Time,History.Time,Investigation.Time,Nature.Time,Religion.Time,
                AnimalHandling.Time,Insight.Time,Medicine.Time,Perception.Time,Survival.Time,
                Deception.Time,Intimidation.Time,Performance.Time,Persuasion.Time }.Max();
        }

        public Character ToModel(Class @class, out CharacterAttributes attributes, out CharacterExpert inititive,
            out CharacterHitpoint hp, out CharacterSpellCasting spellCasting, out CharacterExpert strengthSave,
            out CharacterExpert dextritySave, out CharacterExpert constitutionSave, out CharacterExpert intelligenceSave,
            out CharacterExpert wisdomSave, out CharacterExpert charismaSave,
            out CharacterExpert athletics,
            out CharacterExpert acrobatics, out CharacterExpert sleightOfHands, out CharacterExpert stealth,
            out CharacterExpert arcana, out CharacterExpert history, out CharacterExpert investigation, out CharacterExpert nature, out CharacterExpert religion,
            out CharacterExpert animalHandling, out CharacterExpert insight, out CharacterExpert medicine, out CharacterExpert perception, out CharacterExpert survival,
            out CharacterExpert deception, out CharacterExpert intimidation, out CharacterExpert performance, out CharacterExpert persuasion)
        {
            attributes = Attributes.ToModel();
            inititive = Inititive.ToModel();
            hp = Hp.ToModel();
            spellCasting = SpellCasting.ToModel();

            strengthSave = StrengthSave.ToModel();
            dextritySave = DextritySave.ToModel();
            constitutionSave = ConstitutionSave.ToModel();
            intelligenceSave = IntelligenceSave.ToModel();
            charismaSave = CharismaSave.ToModel();
            wisdomSave = WisdomSave.ToModel();

            athletics = Athletics.ToModel();
            acrobatics = Acrobatics.ToModel();
            sleightOfHands = SleightOfHands.ToModel();
            stealth = Stealth.ToModel();
            arcana = Arcana.ToModel();
            history = History.ToModel();
            investigation = Investigation.ToModel();
            nature = Nature.ToModel();
            religion = Religion.ToModel();
            animalHandling = AnimalHandling.ToModel();
            insight = Insight.ToModel();
            medicine = Medicine.ToModel();
            perception = Perception.ToModel();
            survival = Survival.ToModel();
            deception = Deception.ToModel();
            intimidation = Intimidation.ToModel();
            performance = Performance.ToModel();
            persuasion = Persuasion.ToModel();

            return new()
            {
                Name = Name,
                Race = Race,
                Background = Background,
                Image = Image,
                Class = @class,
                SubClassName = SubClassName,
                Level = Level,
                Attributes = attributes,
                Speed = Speed,
                Inititive = inititive,
                ArmorClassExtra = ArmorClassExtra,
                Hp = hp,
                SpellCasting = spellCasting,

                StrengthSave = strengthSave,
                DextritySave = dextritySave,
                ConstitutionSave = constitutionSave,
                IntelligenceSave = intelligenceSave,
                WisdomSave = wisdomSave,
                CharismaSave = charismaSave,

                Athletics = athletics,
                Acrobatics = acrobatics,
                SleightOfHands = sleightOfHands,
                Stealth = stealth,
                Arcana = arcana,
                History = history,
                Investigation = investigation,
                Nature = nature,
                Religion = religion,
                AnimalHandling = animalHandling,
                Insight = insight,
                Medicine = medicine,
                Perception = perception,
                Survival = survival,
                Deception = deception,
                Intimidation = intimidation,
                Performance = performance,
                Persuasion = persuasion,
            };
        }

        public void EditModel(Character model, CharacterAttributes attributes, CharacterExpert inititive,
            CharacterHitpoint hp, CharacterSpellCasting spellCasting, CharacterExpert strengthSave,
            CharacterExpert dextritySave, CharacterExpert constitutionSave, CharacterExpert intelligenceSave,
            CharacterExpert wisdomSave, CharacterExpert charismaSave,
            CharacterExpert athletics,
            CharacterExpert acrobatics, CharacterExpert sleightOfHands, CharacterExpert stealth,
            CharacterExpert arcana, CharacterExpert history, CharacterExpert investigation, CharacterExpert nature, CharacterExpert religion,
            CharacterExpert animalHandling, CharacterExpert insight, CharacterExpert medicine, CharacterExpert perception, CharacterExpert survival,
            CharacterExpert deception, CharacterExpert intimidation, CharacterExpert performance, CharacterExpert persuasion)
        {
            model.Name = Name;
            model.Race = Race;
            model.Background = Background;
            model.Image = Image;
            model.SubClassName = SubClassName;
            model.Level = Level;
            model.Speed = Speed;
            model.ArmorClassExtra = ArmorClassExtra;

            Attributes.ToModel(attributes);
            Inititive.ToModel(inititive);
            Hp.ToModel(hp);
            SpellCasting.ToModel(spellCasting);

            StrengthSave.ToModel(strengthSave);
            DextritySave.ToModel(dextritySave);
            ConstitutionSave.ToModel(constitutionSave);
            IntelligenceSave.ToModel(intelligenceSave);
            CharismaSave.ToModel(charismaSave);
            WisdomSave.ToModel(wisdomSave);

            Athletics.ToModel(athletics);
            Acrobatics.ToModel(acrobatics);
            SleightOfHands.ToModel(sleightOfHands);
            Stealth.ToModel(stealth);
            Arcana.ToModel(arcana);
            History.ToModel(history);
            Investigation.ToModel(investigation);
            Nature.ToModel(nature);
            Religion.ToModel(religion);
            AnimalHandling.ToModel(animalHandling);
            Insight.ToModel(insight);
            Medicine.ToModel(medicine);
            Perception.ToModel(perception);
            Survival.ToModel(survival);
            Deception.ToModel(deception);
            Intimidation.ToModel(intimidation);
            Performance.ToModel(performance);
            Persuasion.ToModel(persuasion);
        }
    }
}