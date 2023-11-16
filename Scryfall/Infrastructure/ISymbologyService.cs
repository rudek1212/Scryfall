using Scryfall.Domain.Response;

namespace Scryfall.Infrastructure;

public interface ISymbologyService
{
    /// <summary>
    /// Retrieve all Card Symbols.
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<SymbolObject?>> GetSymbolsAsync();

    /// <summary>
    /// Parses the given mana cost parameter and returns Scryfall’s interpretation.
    /// The server understands most community shorthand for mana costs (such as 2WW for {2}{W}{W}).
    /// Symbols can also be out of order, lowercase, or have multiple colorless costs (such as 2{g}2 for {4}{G}).
    /// If part of the string could not be understood, the server will return an Error object describing the problem.
    /// </summary>
    /// <param name="manaCost"></param>
    /// <returns></returns>
    public Task<ManaCostObject?> ParseManaCostAsync(string manaCost);
}