namespace Scryfall.Infrastructure;

internal interface IScryfallClient
{
    Task<TResponse?> GetScryfallResponseAsync<TResponse>(string url, bool isPost = false, object? data = null, params KeyValuePair<string, string>[] query);
}