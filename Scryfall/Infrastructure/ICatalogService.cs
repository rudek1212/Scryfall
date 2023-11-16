namespace Scryfall.Infrastructure;

public interface ICatalogService
{
    /// <summary>
    /// Returns a list of all non-token English card names in Scryfall’s database.
    /// Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<string>?> GetCardNamesAsync();

    /// <summary>
    /// Returns a list of all canonical artist names in Scryfall’s database.
    /// This catalog won’t include duplicate, misspelled, or funny names for artists.
    /// Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<string>?> GetArtistNamesAsync();

    /// <summary>
    /// Returns a Catalog of all English words, of length 2 or more, that could appear in a card name.
    /// Values are drawn from cards currently in Scryfall’s database.
    /// Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<string>?> GetWordBankAsync();

    /// <summary>
    /// Returns a Catalog of all creature types in Scryfall’s database.
    /// Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<string>?> GetCreatureTypesAsync();

    /// <summary>
    /// Returns a Catalog of all Planeswalker types in Scryfall’s database.
    /// Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<string>?> GetPlaneswalkerTypesAsync();

    /// <summary>
    /// Returns a Catalog of all Land types in Scryfall’s database.
    /// Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<string>?> GetLandTypesAsync();

    /// <summary>
    /// Returns a Catalog of all artifact types in Scryfall’s database.
    /// Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<string>?> GetArtifactTypesAsync();

    /// <summary>
    /// Returns a Catalog of all enchantment types in Scryfall’s database.
    /// Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<string>?> GetEnchantmentTypesAsync();

    /// <summary>
    /// Returns a Catalog of all spell types in Scryfall’s database.
    /// Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<string>?> GetSpellTypesAsync();

    /// <summary>
    /// Returns a Catalog of all possible values for a creature or vehicle’s power in Scryfall’s database.
    /// Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<string>?> GetPowersAsync();

    /// <summary>
    /// Returns a Catalog of all possible values for a creature or vehicle’s toughness in Scryfall’s database.
    /// Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<string>?> GetToughnesesAsync();

    /// <summary>
    /// Returns a Catalog of all possible values for a Planeswalker’s loyalty in Scryfall’s database.
    /// Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<string>?> GetLoyalitiesAsync();

    /// <summary>
    /// Returns a Catalog of all card watermarks in Scryfall’s database.
    /// Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<string>?> GetWatermarksAsync();

    /// <summary>
    /// Returns a Catalog of all keyword abilities in Scryfall’s database.
    /// Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<string>?> GetKeywordAbilitiesAsync();

    /// <summary>
    /// Returns a Catalog of all keyword actions in Scryfall’s database.
    /// Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<string>?> GetKeywordActionsAsync();

    /// <summary>
    /// Returns a Catalog of all ability words in Scryfall’s database.
    /// Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<string>?> GetAbilityWordsAsync();

    /// <summary>
    /// Returns a Catalog of all Magic card supertypes.
    /// Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<string>?> GetSupertypesAsync();
}