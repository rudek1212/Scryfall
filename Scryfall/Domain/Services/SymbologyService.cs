using Scryfall.Domain.Response;
using Scryfall.Infrastructure;

namespace Scryfall.Domain.Services;

public class SymbologyService : ScryfallService, ISymbologyService
{
    internal SymbologyService(IScryfallClient scryfallClient) : base(scryfallClient)
    {
    }

    public async Task<IEnumerable<SymbolObject?>> GetSymbolsAsync()
    {
        const string url = "symbology";

        var result = await GetScryfallFullListResponseAsync<SymbolObject>(url);

        return result;
    }

    public async Task<ManaCostObject?> ParseManaCostAsync(string manaCost)
    {
        const string url = "symbology/parse-mana";

        var queryParams = new List<KeyValuePair<string, string>>
        {
            new ("cost", manaCost)
        };

        var response = await ScryfallClient.GetScryfallResponseAsync<ManaCostObject>(url, query: queryParams.ToArray());
        return response;
    }
}