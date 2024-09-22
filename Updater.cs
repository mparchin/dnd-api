using api.Models.FiveE;

namespace api
{
    public class Updater(ILogger<Updater> logger, string spellUrl, string lookupUrl) : IDisposable
    {
        private readonly HttpClient _httpClient = new();

        public void Dispose()
        {
            _httpClient.Dispose();
            GC.SuppressFinalize(this);
        }

        private async Task<Spell[]> FetchSpells()
        {
            logger.LogInformation($"Fetching spells from {spellUrl}");
            var spells = await _httpClient.GetFromJsonAsync<Spell[]>(spellUrl);
            if (spells is null)
            {
                logger.LogCritical("Zero spells found");
                throw new Exception("Zero spells found");
            }
            logger.LogInformation($"Fetched {spells.Length} spells from {spellUrl}");

            return spells;
        }

        // private async Task<Spell[]> FetchLookups()
        // {
        //     logger.LogInformation($"Fetching lookup from {spellUrl}");
        //     var spells = await _httpClient.GetFromJsonAsync<Spell[]>(spellUrl);
        //     if (spells is null)
        //     {
        //         logger.LogCritical("Zero spells found");
        //         throw new Exception("Zero spells found");
        //     }
        //     logger.LogInformation($"Fetched {spells.Length} spells from {spellUrl}");

        //     return spells;
        //     // logger.LogInformation($"Fetching lookup at {lookupUrl}");
        // }

        public async Task RunAsync()
        {
            var spells = await FetchSpells();

        }
    }
}