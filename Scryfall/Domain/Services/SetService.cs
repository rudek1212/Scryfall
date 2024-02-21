using Scryfall.Domain.Response;
using Scryfall.Infrastructure;

namespace Scryfall.Domain.Services;

public class SetService : ScryfallService, ISetService
{
    internal SetService(IScryfallClient scryfallClient) : base(scryfallClient)
    {
    }

    public async Task<IEnumerable<SetObject?>> GetAllSetsAsync()
    {
        var url = "sets";

        var result = await GetScryfallFullListResponseAsync<SetObject>(url);

        return result;
    }

    public async Task<SetObject?> GetSetByCodeAsync(string code)
    {
        var url = $"sets/{code}";

        var result = await ScryfallClient.GetScryfallResponseAsync<SetObject>(url);

        return result;
    }

    public async Task<SetObject?> GetSetByTcgPlayerIdAsync(int id)
    {
        var url = $"sets/tcgplayer/{id}";

        var result = await ScryfallClient.GetScryfallResponseAsync<SetObject>(url);

        return result;
    }

    public async Task<SetObject?> GetSetByScryfallIdAsync(Guid id)
    {
        var url = $"sets/{id:D}";

        var result = await ScryfallClient.GetScryfallResponseAsync<SetObject>(url);

        return result;
    }
}