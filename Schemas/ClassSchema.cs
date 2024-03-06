using api.Models;

namespace api.Schemas
{
    public class ClassSchema : BaseSchema<Class>
    {
        public ClassSchema()
        {

        }
        public ClassSchema(Class? model = null) : base(model)
        {
            if (model is null)
                return;
            Name = model.Name;
            HitDie = model.HitDie;
            ProficiencyBonous = model.ProficiencyBonous;
            ManaPerLevel = model.ManaPerLevel;
            CasterSubClassName = model.CasterSubClassName;
        }

        public string Name { get; set; } = "";
        public int HitDie { get; set; } = 0;
        public string ProficiencyBonous { get; set; } = "";
        public string ManaPerLevel { get; set; } = "";
        public string CasterSubClassName { get; set; } = "";
    }
}