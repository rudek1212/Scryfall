using Newtonsoft.Json;

namespace Scryfall.Domain.Response;

public class RulingObject : ScryfallObject
{
    /// <summary>
    /// The Oracle ID of the card this ruling is associated with.
    /// </summary>
    [JsonProperty("oracle_id")]
    public Guid OracleId { get; set; }

    /// <summary>
    /// A computer-readable string indicating which company produced this ruling, either wotc or scryfall.
    /// </summary>
    [JsonProperty("source")]
    public string? Source { get; set; }

    /// <summary>
    /// The date when the ruling or note was published.
    /// </summary>
    [JsonProperty("published_at")]
    public DateOnly PublishedAt { get; set; }

    /// <summary>
    /// The text of the ruling.
    /// </summary>
    [JsonProperty("comment")]
    public string? Comment { get; set; }
}