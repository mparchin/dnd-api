using api.Models;

namespace api.Schemas
{
    public class CharacterSchema : BaseSchema<Character>
    {
        public string Name { get; set; } = "";
        public string Race { get; set; } = "";
        public string Background { get; set; } = "";
        public string? Image { get; set; }
        public ClassSchema Class { get; set; }
        public string SubClassName { get; set; } = "";
        public int Level { get; set; } = 1;
        public CharacterAttributesSchema Attributes { get; set; }
        public int Speed { get; set; } = 30;
        public CharacterExpertSchema Inititive { get; set; }
        public string ArmorClassExtra { get; set; } = "10";
        public CharacterHitpointSchema Hp { get; set; }
        public CharacterSpellCastingSchema SpellCasting { get; set; }

        public CharacterExpertSchema StrengthSave { get; set; }
        public CharacterExpertSchema DextritySave { get; set; }
        public CharacterExpertSchema ConstitutionSave { get; set; }
        public CharacterExpertSchema IntelligenceSave { get; set; }
        public CharacterExpertSchema WisdomSave { get; set; }
        public CharacterExpertSchema CharismaSave { get; set; }

        public CharacterExpertSchema Athletics { get; set; }
        public CharacterExpertSchema Acrobatics { get; set; }
        public CharacterExpertSchema SleightOfHands { get; set; }
        public CharacterExpertSchema Stealth { get; set; }
        public CharacterExpertSchema Arcana { get; set; }
        public CharacterExpertSchema History { get; set; }
        public CharacterExpertSchema Investigation { get; set; }
        public CharacterExpertSchema Nature { get; set; }
        public CharacterExpertSchema Religion { get; set; }
        public CharacterExpertSchema AnimalHandling { get; set; }
        public CharacterExpertSchema Insight { get; set; }
        public CharacterExpertSchema Medicine { get; set; }
        public CharacterExpertSchema Perception { get; set; }
        public CharacterExpertSchema Survival { get; set; }
        public CharacterExpertSchema Deception { get; set; }
        public CharacterExpertSchema Intimidation { get; set; }
        public CharacterExpertSchema Performance { get; set; }
        public CharacterExpertSchema Persuasion { get; set; }

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

            Time = new List<long> {
                Time, Class.Time, Attributes.Time,
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
    }
}