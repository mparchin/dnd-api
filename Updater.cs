using System.Text.Json;
using System.Text.Json.Serialization;
using api.Models.FiveE;

namespace api
{
    public class Updater(ILogger<Updater> logger, string spellPath)
    {
        private async Task<List<Spell>> FetchSpells()
        {
            logger.LogInformation($"Fetching spells from {spellPath}");

            var txt = await File.ReadAllTextAsync(spellPath);
            logger.LogInformation($"Read {txt.Length} chars from {spellPath}");
            var spellList = JsonSerializer.Deserialize<SpellList>(txt);

            if (spellList is null)
            {
                logger.LogCritical("Zero spells found");
                throw new Exception("Zero spells found");
            }
            logger.LogInformation($"Fetched {spellList.Spell.Count} spells from {spellPath}");

            return spellList.Spell;
        }

        public async Task RunAsync()
        {
            var spells = await FetchSpells();

        }
    }
}