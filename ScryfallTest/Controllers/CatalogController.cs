using Microsoft.AspNetCore.Mvc;
using Scryfall.Infrastructure;

namespace ScryfallTest.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogController : ControllerBase
{
    private readonly ICatalogService _catalogService;

    public CatalogController(ICatalogService catalogService)
    {
        _catalogService = catalogService;
    }

    [HttpGet("GetCardNames")]
    public async Task<IActionResult> GetCardNames() => Ok(await _catalogService.GetCardNamesAsync());

    [HttpGet("GetArtistNames")]
    public async Task<IActionResult> GetArtistNames() => Ok(await _catalogService.GetArtistNamesAsync());

    [HttpGet("GetWordBankAsync")]
    public async Task<IActionResult> GetWordBankAsync() => Ok(await _catalogService.GetWordBankAsync());

    [HttpGet("GetCreatureTypesAsync")]
    public async Task<IActionResult> GetCreatureTypesAsync() => Ok(await _catalogService.GetCreatureTypesAsync());

    [HttpGet("GetPlaneswalkerTypesAsync")]
    public async Task<IActionResult> GetPlaneswalkerTypesAsync() => Ok(await _catalogService.GetPlaneswalkerTypesAsync());

    [HttpGet("GetArtifactTypesAsync")]
    public async Task<IActionResult> GetArtifactTypesAsync() => Ok(await _catalogService.GetArtifactTypesAsync());

    [HttpGet("GetEnchantmentTypesAsync")]
    public async Task<IActionResult> GetEnchantmentTypesAsync() => Ok(await _catalogService.GetEnchantmentTypesAsync());

    [HttpGet("GetSpellTypesAsync")]
    public async Task<IActionResult> GetSpellTypesAsync() => Ok(await _catalogService.GetSpellTypesAsync());

    [HttpGet("GetPowersAsync")]
    public async Task<IActionResult> GetPowersAsync() => Ok(await _catalogService.GetPowersAsync());

    [HttpGet("GetToughnesesAsync")]
    public async Task<IActionResult> GetToughnesesAsync() => Ok(await _catalogService.GetToughnesesAsync());

    [HttpGet("GetLoyalitiesAsync")]
    public async Task<IActionResult> GetLoyalitiesAsync() => Ok(await _catalogService.GetLoyalitiesAsync());

    [HttpGet("GetWatermarksAsync")]
    public async Task<IActionResult> GetWatermarksAsync() => Ok(await _catalogService.GetWatermarksAsync());

    [HttpGet("GetKeywordAbilitiesAsync")]
    public async Task<IActionResult> GetKeywordAbilitiesAsync() => Ok(await _catalogService.GetKeywordAbilitiesAsync());

    [HttpGet("GetKeywordActionsAsync")]
    public async Task<IActionResult> GetKeywordActionsAsync() => Ok(await _catalogService.GetKeywordActionsAsync());

    [HttpGet("GetAbilityWordsAsync")]
    public async Task<IActionResult> GetAbilityWordsAsync() => Ok(await _catalogService.GetAbilityWordsAsync());

    [HttpGet("GetSupertypesAsync")]
    public async Task<IActionResult> GetSupertypesAsync() => Ok(await _catalogService.GetSupertypesAsync());
}
