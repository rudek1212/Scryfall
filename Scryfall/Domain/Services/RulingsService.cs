using Scryfall.Domain.Response;
using Scryfall.Infrastructure;

namespace Scryfall.Domain.Services;

public class RulingsService : ScryfallService, IRulingsService
{
    public RulingsService(IScryfallClient scryfallClient) : base(scryfallClient)
    {
    }

    public async Task<IEnumerable<RulingObject?>> GetRulingByMultiverseIdAsync(int multiverseId)
    {
        var url = $"cards/multiverse/{multiverseId}/rulings";

        var result = await GetScryfallFullListResponseAsync<RulingObject>(url);

        return result;
    }

    public async Task<IEnumerable<RulingObject?>> GetRulingByMtgoIdAsync(int mtgoId)
    {
        var url = $"cards/mtgo/{mtgoId}/rulings";

        var result = await GetScryfallFullListResponseAsync<RulingObject>(url);

        return result;
    }

    public async Task<IEnumerable<RulingObject?>> GetRulingByArenaIdAsync(int arenaId)
    {
        var url = $"cards/arena/{arenaId}/rulings";

        var result = await GetScryfallFullListResponseAsync<RulingObject>(url);

        return result;
    }

    public async Task<IEnumerable<RulingObject?>> GetRulingBySetAndCollectorNumberAsync(string setCode,
        string collectorNumber)
    {
        var url = $"cards/{setCode}/{collectorNumber}/rulings";

        var result = await GetScryfallFullListResponseAsync<RulingObject>(url);

        return result;
    }

    public async Task<IEnumerable<RulingObject?>> GetRulingByScryfallIdAsync(Guid scryfallId)
    {
        var url = $"cards/{scryfallId:D}/rulings";

        var result = await GetScryfallFullListResponseAsync<RulingObject>(url);

        return result;
    }
}