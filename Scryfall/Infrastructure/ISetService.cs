using Scryfall.Domain.Response;

namespace Scryfall.Infrastructure;

public interface ISetService
{
    /// <summary>
    /// Returns a list of all Sets on Scryfall.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<SetObject?>> GetAllSetsAsync();

    /// <summary>
    /// Returns a Set with the given set code. The code can be either the code or the mtgo_code for the set.
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    Task<SetObject?> GetSetByCodeAsync(string code);

    /// <summary>
    /// Returns a Set with the given tcgplayer_id, also known as the groupId on TCGplayer’s API.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<SetObject?> GetSetByTcgPlayerIdAsync(int id);

    /// <summary>
    /// Returns a Set with the given Scryfall id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<SetObject?> GetSetByScryfallIdAsync(Guid id);
}