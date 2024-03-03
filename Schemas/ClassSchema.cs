using api.Models;

namespace api.Schemas
{
    public class ClassSchema : BaseSchema<Class>
    {
        public string Name { get; set; }
        public int HitDie { get; set; }
        public string ProficiencyBonous { get; set; }
        public string ManaPerLevel { get; set; }
        public string CasterSubClassName { get; set; }


        public ClassSchema(Class @class) : base(@class)
        {
            Name = @class.Name;
            HitDie = @class.HitDie;
            ProficiencyBonous = @class.ProficiencyBonous;
            ManaPerLevel = @class.ManaPerLevel;
            CasterSubClassName = @class.CasterSubClassName;
        }
    }
}