using Scryfall.Domain.Response;

namespace Scryfall.Infrastructure;

public interface IRulingsService
{
    /// <summary>
    /// Returns a List of rulings for a card with the given Multiverse ID.
    /// If the card has multiple multiverse IDs, this method can find either of them.
    /// </summary>
    /// <param name="multiverseId"></param>
    /// <returns></returns>
    Task<IEnumerable<RulingObject?>> GetRulingByMultiverseIdAsync(int multiverseId);

    /// <summary>
    /// Returns rulings for a card with the given MTGO ID (also known as the Catalog ID).
    /// The ID can either be the card’s mtgo_id or its mtgo_foil_id.
    /// </summary>
    /// <param name="mtgoId"></param>
    /// <returns></returns>
    Task<IEnumerable<RulingObject?>> GetRulingByMtgoIdAsync(int mtgoId);

    /// <summary>
    /// Returns rulings for a card with the given Magic: The Gathering Arena ID.
    /// </summary>
    /// <param name="arenaId"></param>
    /// <returns></returns>
    Task<IEnumerable<RulingObject?>> GetRulingByArenaIdAsync(int arenaId);

    /// <summary>
    /// Returns a List of rulings for the card with the given set code and collector number.
    /// </summary>
    /// <param name="setCode"></param>
    /// <param name="collectorNumber"></param>
    /// <returns></returns>
    Task<IEnumerable<RulingObject?>> GetRulingBySetAndCollectorNumberAsync(string setCode, string collectorNumber);

    /// <summary>
    /// Returns a List of rulings for a card with the given Scryfall ID.
    /// </summary>
    /// <param name="scryfallId"></param>
    /// <returns></returns>
    Task<IEnumerable<RulingObject?>> GetRulingByScryfallIdAsync(Guid scryfallId);

}