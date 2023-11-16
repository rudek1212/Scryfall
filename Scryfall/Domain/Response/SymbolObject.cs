﻿using Newtonsoft.Json;

namespace Scryfall.Domain.Response;

public class SymbolObject : ScryfallObject
{
    /// <summary>
    /// The plaintext symbol. Often surrounded with curly braces {}.
    /// Note that not all symbols are ASCII text (for example, {∞}).
    /// </summary>
    [JsonProperty("symbol")]
    public string? Symbol { get; set; }

    /// <summary>
    /// An alternate version of this symbol, if it is possible to write it without curly braces.
    /// </summary>
    [JsonProperty("loose_variant")]
    public string? LooseVariant { get; set; }

    /// <summary>
    /// An English snippet that describes this symbol.
    /// Appropriate for use in alt text or other accessible communication formats.
    /// </summary>
    [JsonProperty("english")]
    public string? English { get; set; }

    /// <summary>
    /// True if it is possible to write this symbol “backwards”.
    /// For example, the official symbol {U/P} is sometimes written as {P/U} or {P\U} in informal settings.
    /// Note that the Scryfall API never writes symbols backwards in other responses.
    /// This field is provided for informational purposes.
    /// </summary>
    [JsonProperty("transposable")]
    public bool Transposable { get; set; }

    /// <summary>
    /// True if this is a mana symbol.
    /// </summary>
    [JsonProperty("represents_mana")]
    public bool RepresentsMana { get; set; }

    /// <summary>
    /// A decimal number representing this symbol’s mana value (also knowns as the converted mana cost).
    /// Note that mana symbols from funny sets can have fractional mana values.
    /// </summary>
    [JsonProperty("mana_value")]
    public decimal? ManaValue { get; set; }

    /// <summary>
    /// True if this symbol appears in a mana cost on any Magic card.
    /// For example {20} has this field set to false because {20} only appears in Oracle text, not mana costs.
    /// </summary>
    [JsonProperty("appears_in_mana_costs")]
    public bool ApearsInManaCosts { get; set; }

    /// <summary>
    /// True if this symbol is only used on funny cards or Un-cards.
    /// </summary>
    [JsonProperty("funny")]
    public bool Funny { get; set; }

    /// <summary>
    /// An array of colors that this symbol represents.
    /// </summary>
    [JsonProperty("colors")]
    public string[]? Colors { get; set; }

    /// <summary>
    /// An array of plaintext versions of this symbol that Gatherer uses on old cards to describe original printed text.
    /// For example: {W} has ["oW", "ooW"] as alternates.
    /// </summary>
    [JsonProperty("gatherer_alternates")]
    public string[]? GathererAlternates { get; set; }

    /// <summary>
    /// A URI to an SVG image of this symbol on Scryfall’s CDNs.
    /// </summary>
    [JsonProperty("svg_uri")]
    public string? SvgUri { get; set; }
}