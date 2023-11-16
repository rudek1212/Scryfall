using Newtonsoft.Json;

namespace Scryfall.Domain.Response;

public abstract class ScryfallObject
{
    /// <summary>
    /// A content type for this object.
    /// </summary>
    [JsonProperty("object")]
    public string? Object { get; set; }
}