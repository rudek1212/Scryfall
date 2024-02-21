using System.Text;
using System.Web;
using Scryfall.Domain.Response;
using Scryfall.Infrastructure;

namespace Scryfall.Domain.Services;

public class CardService : ScryfallService, ICardService
{
    public CardService(IScryfallClient scryfallClient) : base(scryfallClient)
    {
    }

    public async Task<PagedResult<CardObject>> GetCardsAsync(CardQuery query, Unqiue unique = Unqiue.Cards, Order order = Order.Name,
        Direction direction = Direction.Auto, bool extras = false, bool multiLingual = false, bool variations = false,
        int page = 1)
    {
        const string endpoint = "cards/search";
        var queryString = BuildQueryString(query);

        var queryParams = new List<KeyValuePair<string, string>>
        {
            new ("q", queryString),
            new ("unique", unique.ToString("G")),
            new ("order", order.ToString("G")),
            new ("direction", direction.ToString("G")),
            new ("include_extras", extras.ToString()),
            new ("include_multilingual", multiLingual.ToString()),
            new ("include_variations", variations.ToString()),
            new ("page", page.ToString())
        };

        var response = await ScryfallClient.GetScryfallResponseAsync<ListObject<CardObject>>(endpoint, query: queryParams.ToArray());

        return new PagedResult<CardObject>
        {
            Items = response?.Data?.ToList(),
            PageNumber = page,
            PageSize = 175,
            TotalItems = response?.TotalCards
        };
    }

    public async Task<IEnumerable<CardObject?>> GetAllCardsAsync(CardQuery query, Unqiue unique = Unqiue.Cards,
	    Order order = Order.Name,
	    Direction direction = Direction.Auto, bool extras = false, bool multiLingual = false, bool variations = false)
    {
        const string endpoint = "cards/search";
        var queryString = BuildQueryString(query);

        var queryParams = new List<KeyValuePair<string, string>>
        {
            new ("q", queryString),
            new ("unique", unique.ToString("G")),
            new ("order", order.ToString("G")),
            new ("direction", direction.ToString("G")),
            new ("include_extras", extras.ToString()),
            new ("include_multilingual", multiLingual.ToString()),
            new ("include_variations", variations.ToString())
        };

        return await GetScryfallFullListResponseAsync<CardObject>(endpoint, query: queryParams.ToArray());
    }

    public async Task<CardObject?> GetCardByNameAsync(string name, Naming naming, string? set = null, string? format = null, string? face = null)
    {
        const string endpoint = "cards/named";

        var queryParams = new List<KeyValuePair<string, string>> { KeyValuePair.Create(naming.ToString("g"), name) };
        if (!string.IsNullOrEmpty(set))
            queryParams.Add(new KeyValuePair<string, string>("set", set));
        if (!string.IsNullOrEmpty(format))
            queryParams.Add(new KeyValuePair<string, string>("format", format));
        if (!string.IsNullOrEmpty(face))
            queryParams.Add(new KeyValuePair<string, string>("face", face));

        var response = await ScryfallClient.GetScryfallResponseAsync<CardObject>(endpoint, query:queryParams.ToArray());

        return response;
    }

    public async Task<IEnumerable<string>?> GetAutocompleteAsync(string name, bool extras = false)
    {
        const string endpiont = "cards/autocomplete";

        var queryParams = new List<KeyValuePair<string, string>>
        {
            KeyValuePair.Create("q", name),
            KeyValuePair.Create("extras", extras.ToString())
        };

        var response = await ScryfallClient.GetScryfallResponseAsync<CatalogObject<string>>(endpiont, query: queryParams.ToArray());

        return response?.Data;
    }

    public Task<CardObject?> GetRandomCardAsync(CardQuery? query = null)
    {
        const string endpoint = "cards/search";
        var queryString = HttpUtility.UrlEncode(BuildQueryString(query));

        var response = ScryfallClient.GetScryfallResponseAsync<CardObject>(endpoint, query: new KeyValuePair<string, string>("q", queryString));

        return response;
    }

    public async Task<IEnumerable<CardObject>?> GetCollectionAsync(Dictionary<string, string>[] identifiers)
    {
        var endpoint = "cards/collection";

        var identifiersObject = new
        {
            Identifiers = identifiers
        };

        var response = await ScryfallClient.GetScryfallResponseAsync<ListObject<CardObject>>(endpoint, true, identifiersObject);

        return response?.Data;
    }

    public async Task<CardObject?> GetCardBySetAndCollectorNumberAsync(string setCode, string collectorNumber, string? language = null)
    {
        var endpoint = $"cards/{setCode}/{collectorNumber}" + (!string.IsNullOrEmpty(language) ? $"/{language}" : string.Empty);

        var response = await ScryfallClient.GetScryfallResponseAsync<CardObject>(endpoint);
       
        return response;
    }

    public async Task<CardObject?> GetCardByMultiverseId(int multiverseId)
    {
        var endpoint = $"cards/multiverse/{multiverseId}";

        var response = await ScryfallClient.GetScryfallResponseAsync<CardObject>(endpoint);

        return response;
    }

    public async Task<CardObject?> GetCardByMtgoIdAsync(int mtgoId)
    {
        var endpoint = $"cards/mtgo/{mtgoId}";

        var response = await ScryfallClient.GetScryfallResponseAsync<CardObject>(endpoint);

        return response;
    }

    public async Task<CardObject?> GetCardByArenaIdAsync(int arenaId)
    {
        var endpoint = $"cards/arena/{arenaId}";

        var response = await ScryfallClient.GetScryfallResponseAsync<CardObject>(endpoint);

        return response;
    }

    public async Task<CardObject?> GetCardByTcgPlayerIdAsync(int tcgPlayerId)
    {
        var endpoint = $"cards/tcgplayer/{tcgPlayerId}";

        var response = await ScryfallClient.GetScryfallResponseAsync<CardObject>(endpoint);

        return response;
    }

    public async Task<CardObject?> GetCardByCardmarketIdAsync(int cardmarketId)
    {
        var endpoint = $"cards/cardmarket/{cardmarketId}";

        var response = await ScryfallClient.GetScryfallResponseAsync<CardObject>(endpoint);

        return response;
    }

    public async Task<CardObject?> GetCardByScryfallIdAsync(Guid scryfallId)
    {
        var endpoint = $"cards/{scryfallId}";

        var response = await ScryfallClient.GetScryfallResponseAsync<CardObject>(endpoint);

        return response;
    }

    private string BuildQueryString(CardQuery? query)
    {
        if (query == null)
            return string.Empty;

        var stringBuilder = new StringBuilder();

        var nameQuery = query.Name.Concat(query.NameExcl.Select(x => $"-{x}"));
        stringBuilder.Append(string.Join(" ", nameQuery));

        if(query.Text.Any())
            stringBuilder.Append($" ({string.Join(" ", query.Text.Select(x => $"oracle:{x}"))})");
        if (query.TextExcl.Any())
            stringBuilder.Append($" ({string.Join(" ", query.TextExcl.Select(x => $"-oracle:{x}"))})");

        if (query.TypeAllowPartial)
        {
            if (query.Type.Any())
                stringBuilder.Append($" ({string.Join(" OR ", query.Type.Select(x => $"type:{x}"))})");
            if (query.TypeExcl.Any())
                stringBuilder.Append($" ({string.Join(" OR ", query.TypeExcl.Select(x => $"-type:{x}"))})");
        }
        else
        {
            if (query.Type.Any())
                stringBuilder.Append($" ({string.Join(" ", query.Type.Select(x => $"type:{x}"))})");
            if (query.TypeExcl.Any())
                stringBuilder.Append($" ({string.Join(" ", query.TypeExcl.Select(x => $"-type:{x}"))})");
        }

        if (query.Colors.Any())
        {
            switch (query.ColorType)
            {
                case CardQuery.CardQueryColorType.AtMost:
                    stringBuilder.Append($" color<={string.Join("", query.Colors)}");
                    break;
                case CardQuery.CardQueryColorType.Exact:
                    stringBuilder.Append($" color={string.Join("", query.Colors)}");
                    break;
                case CardQuery.CardQueryColorType.Include:
                    stringBuilder.Append($" color>={string.Join("", query.Colors)}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        if (query.ColorIdent.Any())
            stringBuilder.Append($" commander:{string.Join("", query.ColorIdent)}");

        if (query.ManaCost.Any())
            stringBuilder.Append($" mana:{string.Join("", query.ManaCost)}");

        var gameList = new List<string>();
        if(query.IsPaper) gameList.Add("game:paper");
        if(query.IsArena) gameList.Add("game:arena");
        if(query.IsMagicOnline) gameList.Add("game:mtgo");
        if (gameList.Any())
            stringBuilder.Append($" ({string.Join(" or ", gameList)})");

        foreach (var format in query.Legal)
            stringBuilder.Append($" legal:{format}");
        foreach (var format in query.Restricted)
            stringBuilder.Append($" restricted:{format}");
        foreach (var format in query.Banned)
            stringBuilder.Append($" banned:{format}");

        if (query.Set.Any())
            stringBuilder.Append($" ({string.Join(" OR ", query.Set.Select(set => $"set:{set}"))})");
        if (query.Block.Any())
            stringBuilder.Append($" ({string.Join(" OR ", query.Block.Select(block => $"block:{block}"))})");
        if (query.Rarity.Any())
            stringBuilder.Append($" ({string.Join(" OR ", query.Rarity.Select(rarity => $"rarity:{rarity}"))})");
        if (query.Artist.Any())
            stringBuilder.Append($" ({string.Join(" OR ", query.Artist.Select(set => $"artist:{set}"))})");
        if (query.Flavor.Any())
            stringBuilder.Append($" ({string.Join(" OR ", query.Flavor.Select(set => $"flavor:{set}"))})");
        if (query.Lore.Any())
            stringBuilder.Append($" ({string.Join(" OR ", query.Flavor.Select(set => $"flavor:{set}"))})");

        if (!string.IsNullOrEmpty(query.Language))
            stringBuilder.Append($" lang:{query.Language}");

        return stringBuilder.ToString();
    }
}