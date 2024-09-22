using System.Text.Json;
using System.Text.Json.Serialization;
using api.Models.FiveE;

namespace api
{
    public class Updater(ILogger<Updater> logger, string spellPath)
    {
        private async Task<SpellList> FetchSpells()
        {
            logger.LogInformation($"Fetching spells from {spellPath}");

            var spells = JsonSerializer.Deserialize<SpellList>(await File.ReadAllTextAsync(spellPath));

            if (spells is null || spells.Spell.Count == 0)
            {
                logger.LogCritical("Zero spells found");
                throw new Exception("Zero spells found");
            }
            logger.LogInformation($"Fetched {spells.Spell.Count} spells from {spellPath}");

            return spells;
        }

        public async Task RunAsync()
        {
            var spells = await FetchSpells();

        }
    }
}