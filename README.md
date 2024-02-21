# Scryfall API Client

This project is based on the Scryfall public API. It is a response to the lack of a C# interface for Scryfall, a search engine.

## Getting Started

Proper documentation will be added in the future. For now, refer to `ScryfallTest` for usage (you can test there with Swagger).

---

## .NET Core Instructions

### Add 'ScryfallConfiguration' section to your `appsettings.json`.

```json
"ScryfallConfiguration": {
  "ScryfallClientConfiguration": {
    "BaseUrl": "https://api.scryfall.com/"
  }
}
```

### Install Scryfall services:

```csharp
builder.Services.UseScryfall(builder.Configuration);
```

### From now on, you can inject specific services into your code via dependency injection.

For example:

```csharp
public class CardController : ControllerBase
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }
    
    [HttpGet("GetCardByNameAsync")]
    public async Task<IActionResult> GetCardByNameAsync([FromQuery] string name, [FromQuery] Naming naming) =>
        Ok(await _cardService.GetCardByNameAsync(name, naming));
}
```

### Available services:

- ICardService
- ICatalogService
- IRulingsService
- ISetService
- ISymbologyService
