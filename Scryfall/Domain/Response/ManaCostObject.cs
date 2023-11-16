namespace Scryfall.Domain.Response;

public class ManaCostObject : ScryfallObject
{
    public string? Cost { get; set; }
    public decimal Cmc { get; set; }
    public string[]? Colors { get; set; }
    public bool Colorless { get; set; }
    public bool Monocolored { get; set; }
    public bool Multicolored { get; set; }

}