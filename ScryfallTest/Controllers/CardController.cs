using Microsoft.AspNetCore.Mvc;
using Scryfall.Infrastructure;

namespace ScryfallTest.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }

    [HttpGet("GetCardsAsync")]
    public async Task<IActionResult> GetCardsAsync([FromQuery]CardQuery query) => Ok(await _cardService.GetCardsAsync(query));

    [HttpGet("GetCardByNameAsync")]
    public async Task<IActionResult> GetCardByNameAsync([FromQuery] string name, [FromQuery] Naming naming) => Ok(await _cardService.GetCardByNameAsync(name, naming));

    [HttpGet("GetAutocompleteAsync")]
    public async Task<IActionResult> GetAutocompleteAsync([FromQuery] string name, [FromQuery] bool extras = false) => Ok(await _cardService.GetAutocompleteAsync(name, extras));

    [HttpGet("GetRandomCardAsync")]
    public async Task<IActionResult> GetRandomCardAsync([FromQuery] CardQuery query) => Ok(await _cardService.GetRandomCardAsync(query));

    [HttpGet("GetCollectionAsync")]
    public async Task<IActionResult> GetCollectionAsync([FromBody] Dictionary<string, string>[] identifiers) => Ok(await _cardService.GetCollectionAsync(identifiers));

    [HttpGet("GetCardBySetAndCollectorNumberAsync")]
    public async Task<IActionResult> GetCardBySetAndCollectorNumberAsync([FromQuery] string setCode,[FromQuery] string collectorNumber,[FromQuery] string? language = null) => Ok(await _cardService.GetCardBySetAndCollectorNumberAsync(setCode, collectorNumber, language));

    [HttpGet("GetCardByMultiverseId/{multiverseId}")]
    public async Task<IActionResult> GetCardByMultiverseId([FromRoute] int multiverseId) => Ok(await _cardService.GetCardByMultiverseId(multiverseId));

    [HttpGet("GetCardByMtgoIdAsync/{mtgoId}")]
    public async Task<IActionResult> GetCardByMtgoIdAsync([FromRoute] int mtgoId) => Ok(await _cardService.GetCardByMtgoIdAsync(mtgoId));

    [HttpGet("GetCardByArenaIdAsync/{arenaId}")]
    public async Task<IActionResult> GetCardByArenaIdAsync([FromRoute] int arenaId) => Ok(await _cardService.GetCardByArenaIdAsync(arenaId));

    [HttpGet("GetCardByTcgPlayerIdAsync/{tcgPlayerId}")]
    public async Task<IActionResult> GetCardByTcgPlayerIdAsync([FromRoute] int tcgPlayerId) => Ok(await _cardService.GetCardByTcgPlayerIdAsync(tcgPlayerId));

    [HttpGet("GetCardByCardmarketIdAsync/{cardmarketId}")]
    public async Task<IActionResult> GetCardByCardmarketIdAsync([FromRoute] int cardmarketId) => Ok(await _cardService.GetCardByCardmarketIdAsync(cardmarketId));

    [HttpGet("GetCardByScryfallIdAsync/{scryfallId}")]
    public async Task<IActionResult> GetCardByScryfallIdAsync([FromRoute] Guid scryfallId) => Ok(await _cardService.GetCardByScryfallIdAsync(scryfallId));
}