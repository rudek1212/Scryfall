using Scryfall.Domain.Response;
using Scryfall.Infrastructure;

namespace Scryfall.Domain;

public abstract class ScryfallService
{
    protected readonly IScryfallClient ScryfallClient;

    protected ScryfallService(IScryfallClient scryfallClient)
    {
        ScryfallClient = scryfallClient;
    }

    protected async Task<IEnumerable<TResponse?>> GetScryfallFullListResponseAsync<TResponse>(string url, params KeyValuePair<string, string>[] query)
    {
        var queryString = query.Any() ?
            "?" + string.Join("&", query.Select(p => $"{Uri.EscapeDataString(p.Key)}={Uri.EscapeDataString(p.Value)}")) :
            string.Empty;

        var allData = new List<TResponse>();
        var nextEndpoint = url + queryString;

        while (!string.IsNullOrEmpty(nextEndpoint))
        {
            var response = await ScryfallClient.GetScryfallResponseAsync<ListObject<TResponse>>(nextEndpoint);
            if (response?.Data != null)
                allData.AddRange(response.Data);

            nextEndpoint = response is {HasMore: true} ? response.NextPage : null;
        }

        return allData;
    }
}