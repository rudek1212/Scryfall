using Newtonsoft.Json;

namespace Scryfall.Domain.Response;

public class SetObject : ScryfallObject
{
    /// <summary>
    /// A unique ID for this set on Scryfall that will not change.
    /// </summary>
    [JsonProperty("id")]
    public Guid Id { get; set; }

    /// <summary>
    /// The unique three to five-letter code for this set.
    /// </summary>
    [JsonProperty("code")]
    public string? Code { get; set; }

    /// <summary>
    /// The unique code for this set on MTGO, which may differ from the regular code.
    /// </summary>
    [JsonProperty("mtgo_code")]
    public string? MtgoCode { get; set; }

    /// <summary>
    /// The unique code for this set on Arena, which may differ from the regular code.
    /// </summary>
    [JsonProperty("arena_code")]
    public string? ArenaCode { get; set; }

    /// <summary>
    /// This set’s ID on TCGplayer’s API, also known as the groupId.
    /// </summary>
    [JsonProperty("tcgplayer_id")]
    public int? TcgPlayerId { get; set; }

    /// <summary>
    /// The English name of the set.
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }

    /// <summary>
    /// A computer-readable classification for this set. See below.
    /// </summary>
    [JsonProperty("set_type")]
    public string? SetType { get; set; }

    /// <summary>
    /// The date the set was released or the first card was printed in the set (in GMT-8 Pacific time).
    /// </summary>
    [JsonProperty("released_at")]
    public DateOnly? ReleasedAt { get; set; }

    /// <summary>
    /// The block code for this set, if any.
    /// </summary>
    [JsonProperty("block_code")]
    public string? BlockCode { get; set; }

    /// <summary>
    /// The block or group name code for this set, if any.
    /// </summary>
    [JsonProperty("block")]
    public string? Block { get; set; }

    /// <summary>
    /// The set code for the parent set, if any. promo and token sets often have a parent set.
    /// </summary>
    [JsonProperty("parent_set_code")]
    public string? ParentSetCode { get; set; }

    /// <summary>
    /// The number of cards in this set.
    /// </summary>
    [JsonProperty("card_count")]
    public int CardCount { get; set; }

    /// <summary>
    /// The denominator for the set’s printed collector numbers.
    /// </summary>
    [JsonProperty("printed_size")]
    public int? PrintedSize { get; set; }

    /// <summary>
    /// True if this set was only released in a video game.
    /// </summary>
    [JsonProperty("digital")]
    public bool Digital { get; set; }

    /// <summary>
    /// True if this set contains only foil cards.
    /// </summary>
    [JsonProperty("foil_only")]
    public bool FoilOnly { get; set; }

    /// <summary>
    /// True if this set contains only nonfoil cards.
    /// </summary>
    [JsonProperty("nonfoil_only")]
    public bool NonFoilOnly { get; set; }

    /// <summary>
    /// A link to this set’s permapage on Scryfall’s website.
    /// </summary>
    [JsonProperty("scryfall_uri")]
    public string? ScryfallUri { get; set; }

    /// <summary>
    /// A link to this set object on Scryfall’s API.
    /// </summary>
    [JsonProperty("uri")]
    public string? Uri { get; set; }

    /// <summary>
    /// A URI to an SVG file for this set’s icon on Scryfall’s CDN.
    /// Hotlinking this image isn’t recommended, because it may change slightly over time.
    /// You should download it and use it locally for your particular user interface needs.
    /// </summary>
    [JsonProperty("icon_svg_uri")]
    public string? IconSvgUri { get; set; }

    /// <summary>
    /// A Scryfall API URI that you can request to begin paginating over the cards in this set.
    /// </summary>
    [JsonProperty("search_uri")]
    public string? SearchUri { get; set; }
}