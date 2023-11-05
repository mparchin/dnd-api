
namespace api.Models
{
    public class Class : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<Spell> RestrictedSpells { get; } = new();
        public DateTime? UpdatedOn { get; set; } = DateTime.Now;
    }
}