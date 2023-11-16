using Microsoft.AspNetCore.Mvc;
using Scryfall.Domain.Services;
using Scryfall.Infrastructure;

namespace ScryfallTest.Controllers;

[ApiController]
[Route("[controller]")]
public class RulingController : ControllerBase
{
    private readonly IRulingsService _rulingService;

    public RulingController(IRulingsService rulingService)
    {
        _rulingService = rulingService;
    }

    [HttpGet("GetRulingByMultiverseIdAsync/{id}")]
    public async Task<IActionResult> GetRulingByMultiverseIdAsync(int id) => Ok(await _rulingService.GetRulingByMultiverseIdAsync(id));

    [HttpGet("GetRulingByMtgoIdAsync/{id}")]
    public async Task<IActionResult> GetRulingByMtgoIdAsync(int id) => Ok(await _rulingService.GetRulingByMtgoIdAsync(id));

    [HttpGet("GetRulingByArenaIdAsync/{id}")]
    public async Task<IActionResult> GetRulingByArenaIdAsync(int id) => Ok(await _rulingService.GetRulingByArenaIdAsync(id));

    [HttpGet("GetRulingBySetAndCollectorNumberAsync/{setCode}/{collectorNumber}")]
    public async Task<IActionResult> GetRulingBySetAndCollectorNumberAsync(string setCode, string collectorNumber) => Ok(await _rulingService.GetRulingBySetAndCollectorNumberAsync(setCode, collectorNumber));

    [HttpGet("GetRulingByScryfallIdAsync/{id}")]
    public async Task<IActionResult> GetRulingByScryfallIdAsync(Guid id) => Ok(await _rulingService.GetRulingByScryfallIdAsync(id));
}