using Scryfall.Domain.Response;
using System.Reflection.Metadata;

namespace Scryfall.Infrastructure;

public interface ICardService
{
    /// <summary>
    /// Returns a List object containing Cards found using a fulltext search string.
    /// This string supports the same fulltext search system that the main site uses.
    /// This method is paginated, returning 175 cards at a time.
    /// </summary>
    Task<PagedResult<CardObject>> GetCardsAsync(CardQuery query, Unqiue unique = Unqiue.Cards, Order order = Order.Name,
    Direction direction = Direction.Auto, bool extras = false, bool multiLingual = false, bool variations = false,
    int page = 1);

    /// <summary>
    /// Returns a Card based on a name search string.
    /// If you provide the exact parameter, a card with that exact name is returned.
    /// Otherwise, a 404 Error is returned because no card matches.
    /// 
    /// If you provide the fuzzy parameter and a card name matches that string, then that card is returned.
    /// If not, a fuzzy search is executed for your card name.
    /// The server allows misspellings and partial words to be provided.
    /// For example: jac bele will match Jace Beleren.
    /// </summary>
    Task<CardObject?> GetCardByNameAsync(string name, Naming naming, string? set = null, string? format = null, string? face = null);

    /// <summary>
    /// Returns a Catalog object containing up to 20 full English card names that could be autocompletions of the given string parameter.
    /// </summary>
    Task<IEnumerable<string>?> GetAutocompleteAsync(string name, bool extras = false);

    /// <summary>
    /// Returns a single random Card object.
    /// The optional parameter q supports the same fulltext search system that the main site uses.Providing q will filter the pool of cards before returning a random entry.
    /// </summary>
    Task<CardObject?> GetRandomCardAsync(CardQuery? query = null);

    /// <summary>
    /// Accepts an array of card identifiers, and returns a collection of requested cards.
    /// A maximum of 75 card references may be submitted per request.
    /// Accepted identifiers:
    ///     id                      Guid        Finds a card with the specified Scryfall id.
    ///     mtgo_id                 int         Finds a card with the specified mtgo_id or mtgo_foil_id.
    ///     multiverse_id           int         Finds a card with the specified value among its multiverse_ids.
    ///     oracle_id               Guid        Finds the newest edition of cards with the specified oracle_id.
    ///     illustration_id         Guid        Finds the preferred scans of cards with the specified illustration_id.
    ///     name                    string      Finds the newest edition of a card with the specified name.
    ///     name,set                strings     Finds a card matching the specified name and set.
    ///     collector_number,set    strings     Finds a card with the specified collector_number and set. Note that collector numbers are strings.
    /// </summary>
    Task<IEnumerable<CardObject>?> GetCollectionAsync(Dictionary<string, string>[] identifiers);

    /// <summary>
    /// Returns a single card with the given set code and collector number.
    /// You may optionally also append a lang part to the URL to retrieve a non-English version of the card.
    /// </summary>
    Task<CardObject?> GetCardBySetAndCollectorNumberAsync(string setCode, string collectorNumber, string? language = null);

    /// <summary>
    /// Returns a single card with the given Multiverse ID.
    /// If the card has multiple multiverse IDs, this method can find either of them.
    /// </summary>
    Task<CardObject?> GetCardByMultiverseId(int multiverseId);

    /// <summary>
    /// Returns a single card with the given MTGO ID (also known as the Catalog ID).
    /// The ID can either be the card’s mtgo_id or its mtgo_foil_id.
    /// </summary>
    Task<CardObject?> GetCardByMtgoIdAsync(int mtgoId);

    /// <summary>
    /// Returns a single card with the given Magic: The Gathering Arena ID.
    /// </summary>
    Task<CardObject?> GetCardByArenaIdAsync(int arenaId);

    /// <summary>
    /// Returns a single card with the given tcgplayer_id or tcgplayer_etched_id, also known as the productId on TCGplayer’s API.
    /// </summary>
    Task<CardObject?> GetCardByTcgPlayerIdAsync(int tcgPlayerId);

    /// <summary>
    /// Returns a single card with the given cardmarket_id, also known as the idProduct" or the Product ID on Cardmarket’s APIs.
    /// </summary>
    Task<CardObject?> GetCardByCardmarketIdAsync(int cardmarketId);

    /// <summary>
    /// Returns a single card with the given Scryfall ID.
    /// </summary>
    Task<CardObject?> GetCardByScryfallIdAsync(Guid scryfallId);

    /// <summary>
    /// Returns all cards based on query parameters
    /// </summary>
    Task<IEnumerable<CardObject>> GetAllCardsAsync(CardQuery query, Unqiue unique = Unqiue.Cards,
        Order order = Order.Name,
        Direction direction = Direction.Auto, bool extras = false, bool multiLingual = false, bool variations = false);
}
public enum Order
{
    Name,
    Set,
    Released,
    Rarity,
    Color,
    Usd,
    Tix,
    Eur,
    Cmc,
    Power,
    Toughness,
    EdhRec,
    Penny,
    Artist,
    Reviev
}

public enum Unqiue
{
    Cards,
    Art,
    Prints
}

public enum Direction
{
    Auto,
    Asc,
    Desc
}

public enum Naming
{
    Exact,
    Fuzzy
}