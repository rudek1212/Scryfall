using Microsoft.Extensions.Options;
using Scryfall.Configuration;
using Scryfall.Infrastructure;
using Newtonsoft.Json;

namespace Scryfall.Domain;

public class ScryfallClient : IScryfallClient
{
    private readonly HttpClient _httpClient;
    private readonly ScryfallClientConfiguration _clientConfiguration;

    public ScryfallClient(
        IHttpClientFactory clientFactory,
        IOptionsSnapshot<ScryfallClientConfiguration> config)
    {
        _httpClient = clientFactory.CreateClient();
        _clientConfiguration = config.Value;

        Configure(_clientConfiguration);
    }

    private void Configure(ScryfallClientConfiguration configuration)
    {
        if(string.IsNullOrEmpty(configuration.BaseUrl))
            throw new ArgumentNullException(configuration.BaseUrl);

        _httpClient.BaseAddress = new Uri(configuration.BaseUrl);
    }

    public async Task<TResponse?> GetScryfallResponseAsync<TResponse>(string url, bool isPost = false, object? data = null, params KeyValuePair<string, string>[] query)
    {
        var queryString = query.Any() ? 
            "?" + string.Join("&", query.Select(p => $"{Uri.EscapeDataString(p.Key)}={Uri.EscapeDataString(p.Value)}")) :
            string.Empty;

        var uri = new Uri(_clientConfiguration.BaseUrl + url + queryString);

        HttpResponseMessage response;
        if (isPost)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            response = await _httpClient.PostAsync(uri, content);
        }
        else
        {
            response = await _httpClient.GetAsync(uri);
        }

        if (!response.IsSuccessStatusCode)
            return default;

        var responseMessage = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<TResponse>(responseMessage);
    }
}