using System.Text.Json;
using System.Text.Json.Serialization;
using api.Models.FiveE;

namespace api
{
    public class Updater(ILogger<Updater> logger, string spellPath)
    {
        private async Task<Spell[]> FetchSpells()
        {
            logger.LogInformation($"Fetching spells from {spellPath}");

            var spells = JsonSerializer.Deserialize<Spell[]>(await File.ReadAllTextAsync(spellPath));

            if (spells is null)
            {
                logger.LogCritical("Zero spells found");
                throw new Exception("Zero spells found");
            }
            logger.LogInformation($"Fetched {spells.Length} spells from {spellPath}");

            return spells;
        }

        public async Task RunAsync()
        {
            var spells = await FetchSpells();

        }
    }
}