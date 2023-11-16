namespace Scryfall.Domain.Response;

public class CatalogObject<TObject> : ScryfallObject
{
    public string? Uri { get; set; }
    public string? TotalValues { get; set; }
    public IEnumerable<TObject>? Data { get; set; }
}