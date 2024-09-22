namespace api.Models.FiveE
{
    public class Spell
    {
        public string Name { get; set; } = "";
        public string Source { get; set; } = "";
        public int Level { get; set; }
        public List<string> Entries { get; set; } = [];
        public List<EntriesHigherLevel> EntriesHigherLevel { get; set; } = [];
    }
}