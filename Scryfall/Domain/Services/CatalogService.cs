using Scryfall.Domain.Response;
using Scryfall.Infrastructure;

namespace Scryfall.Domain.Services;

public class CatalogService : ScryfallService, ICatalogService
{
    public CatalogService(IScryfallClient scryfallClient) : base(scryfallClient)
    {
    }

    public async Task<IEnumerable<string>?> GetCardNamesAsync()
    {
        var url = "catalog/card-names";

        var response = await ScryfallClient.GetScryfallResponseAsync<CatalogObject<string>>(url);
        return response?.Data;
    }

    public async Task<IEnumerable<string>?> GetArtistNamesAsync()
    {
        var url = "catalog/artist-names";

        var response = await ScryfallClient.GetScryfallResponseAsync<CatalogObject<string>>(url);
        return response?.Data;
    }

    public async Task<IEnumerable<string>?> GetWordBankAsync()
    {
        var url = "catalog/word-bank";

        var response = await ScryfallClient.GetScryfallResponseAsync<CatalogObject<string>>(url);
        return response?.Data;
    }

    public async Task<IEnumerable<string>?> GetCreatureTypesAsync()
    {
        var url = "catalog/creature-types";

        var response = await ScryfallClient.GetScryfallResponseAsync<CatalogObject<string>>(url);
        return response?.Data;
    }

    public async Task<IEnumerable<string>?> GetPlaneswalkerTypesAsync()
    {
        var url = "catalog/planeswalker-types";

        var response = await ScryfallClient.GetScryfallResponseAsync<CatalogObject<string>>(url);
        return response?.Data;
    }

    public async Task<IEnumerable<string>?> GetLandTypesAsync()
    {
        var url = "catalog/land-types";

        var response = await ScryfallClient.GetScryfallResponseAsync<CatalogObject<string>>(url);
        return response?.Data;
    }

    public async Task<IEnumerable<string>?> GetArtifactTypesAsync()
    {
        var url = "catalog/artifact-types";

        var response = await ScryfallClient.GetScryfallResponseAsync<CatalogObject<string>>(url);
        return response?.Data;
    }

    public async Task<IEnumerable<string>?> GetEnchantmentTypesAsync()
    {
        var url = "catalog/enchantment-types";

        var response = await ScryfallClient.GetScryfallResponseAsync<CatalogObject<string>>(url);
        return response?.Data;
    }

    public async Task<IEnumerable<string>?> GetSpellTypesAsync()
    {
        var url = "catalog/spell-types";

        var response = await ScryfallClient.GetScryfallResponseAsync<CatalogObject<string>>(url);
        return response?.Data;
    }

    public async Task<IEnumerable<string>?> GetPowersAsync()
    {
        var url = "catalog/powers";

        var response = await ScryfallClient.GetScryfallResponseAsync<CatalogObject<string>>(url);
        return response?.Data;
    }

    public async Task<IEnumerable<string>?> GetToughnesesAsync()
    {
        var url = "catalog/toughnesses";

        var response = await ScryfallClient.GetScryfallResponseAsync<CatalogObject<string>>(url);
        return response?.Data;
    }

    public async Task<IEnumerable<string>?> GetLoyalitiesAsync()
    {
        var url = "catalog/loyalties";

        var response = await ScryfallClient.GetScryfallResponseAsync<CatalogObject<string>>(url);
        return response?.Data;
    }

    public async Task<IEnumerable<string>?> GetWatermarksAsync()
    {
        var url = "catalog/watermarks";

        var response = await ScryfallClient.GetScryfallResponseAsync<CatalogObject<string>>(url);
        return response?.Data;
    }

    public async Task<IEnumerable<string>?> GetKeywordAbilitiesAsync()
    {
        var url = "catalog/keyword-abilities";

        var response = await ScryfallClient.GetScryfallResponseAsync<CatalogObject<string>>(url);
        return response?.Data;
    }

    public async Task<IEnumerable<string>?> GetKeywordActionsAsync()
    {
        var url = "catalog/keyword-actions";

        var response = await ScryfallClient.GetScryfallResponseAsync<CatalogObject<string>>(url);
        return response?.Data;
    }

    public async Task<IEnumerable<string>?> GetAbilityWordsAsync()
    {
        var url = "catalog/ability-words";

        var response = await ScryfallClient.GetScryfallResponseAsync<CatalogObject<string>>(url);
        return response?.Data;
    }

    public async Task<IEnumerable<string>?> GetSupertypesAsync()
    {
        var url = "catalog/supertypes";

        var response = await ScryfallClient.GetScryfallResponseAsync<CatalogObject<string>>(url);
        return response?.Data;
    }
}