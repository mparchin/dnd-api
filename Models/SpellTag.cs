namespace api.Models
{
    public class SpellTag : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<Spell> Spells { get; } = new();
    }
}