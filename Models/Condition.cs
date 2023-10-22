namespace api.Models
{
    public class Condition : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<Spell> RelatedSpells { get; } = new();
    }
}