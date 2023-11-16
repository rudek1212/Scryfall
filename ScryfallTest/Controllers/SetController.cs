using Microsoft.AspNetCore.Mvc;
using Scryfall.Domain.Services;
using Scryfall.Infrastructure;

namespace ScryfallTest.Controllers;

[ApiController]
[Route("[controller]")]
public class SetController : ControllerBase
{
    private readonly ISetService _setService;

    public SetController(ISetService setService)
    {
        _setService = setService;
    }

    [HttpGet("GetAllSetsAsync")]
    public async Task<IActionResult> GetAllSetsAsync() => Ok(await _setService.GetAllSetsAsync());

    [HttpGet("GetSetByCodeAsync/{code}")]
    public async Task<IActionResult> GetSetByCodeAsync(string code) => Ok(await _setService.GetSetByCodeAsync(code));

    [HttpGet("GetSetByTcgPlayerIdAsync/{id}")]
    public async Task<IActionResult> GetSetByTcgPlayerIdAsync(int id) => Ok(await _setService.GetSetByTcgPlayerIdAsync(id));

    [HttpGet("GetSetByScryfallIdAsync/{id}")]
    public async Task<IActionResult> GetSetByScryfallIdAsync(Guid id) => Ok(await _setService.GetSetByScryfallIdAsync(id));
}