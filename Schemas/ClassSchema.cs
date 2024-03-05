using api.Models;

namespace api.Schemas
{
    public class ClassSchema(Class @class) : BaseSchema<Class>(@class)
    {
        public string Name { get; set; } = @class.Name;
        public int HitDie { get; set; } = @class.HitDie;
        public string ProficiencyBonous { get; set; } = @class.ProficiencyBonous;
        public string ManaPerLevel { get; set; } = @class.ManaPerLevel;
        public string CasterSubClassName { get; set; } = @class.CasterSubClassName;
    }
}