using Microsoft.AspNetCore.Mvc;
using Scryfall.Infrastructure;

namespace ScryfallTest.Controllers;

[ApiController]
[Route("[controller]")]
public class SymbologyController : ControllerBase
{
    private readonly ISymbologyService _symbologyService;

    public SymbologyController(ISymbologyService symbologyService)
    {
        _symbologyService = symbologyService;
    }

    [HttpGet("GetSymbolsAsync")]
    public async Task<IActionResult> GetSymbolsAsync() => Ok(await _symbologyService.GetSymbolsAsync());

    [HttpGet("GetSymbolsAsync/{manaCost}")]
    public async Task<IActionResult> GetSymbolsAsync(string manaCost) => Ok(await _symbologyService.ParseManaCostAsync(manaCost));

}