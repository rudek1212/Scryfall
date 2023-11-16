using Newtonsoft.Json;

namespace Scryfall.Domain.Response;

public class CardObject : ScryfallObject
{
    #region Core Card Fields

    /// <summary>
    /// This card’s Arena ID, if any. A large percentage of cards are not available on Arena and do not have this ID.
    /// </summary>
    [JsonProperty("arena_id")]
    public int? ArenaId { get; set; }

    /// <summary>
    /// A unique ID for this card in Scryfall’s database.
    /// </summary>
    [JsonProperty("id")]
    public Guid Id { get; set; }

    /// <summary>
    /// A language code for this printing.
    /// </summary>
    [JsonProperty("lang")]
    public string? Lang { get; set; }

    /// <summary>
    /// This card’s Magic Online ID (also known as the Catalog ID), if any.
    /// A large percentage of cards are not available on Magic Online and do not have this ID.
    /// </summary>
    [JsonProperty("mtgo_id")]
    public int? MtgoId { get; set; }

    /// <summary>
    /// This card’s foil Magic Online ID (also known as the Catalog ID), if any. A large percentage of cards are not available on Magic Online and do not have this ID.
    /// </summary>
    [JsonProperty("mtgo_foil_id")]
    public int? MtgoFoilId { get; set; }

    /// <summary>
    /// This card’s multiverse IDs on Gatherer, if any, as an array of integers.
    /// Note that Scryfall includes many promo cards, tokens, and other esoteric objects that do not have these identifiers.
    /// </summary>
    [JsonProperty("multiverse_ids")]
    public List<int>? MultiverseIds { get; set; }

    /// <summary>
    /// This card’s ID on TCGplayer’s API, also known as the productId.
    /// </summary>
    [JsonProperty("tcgplayer_id")]
    public int? TcgplayerId { get; set; }

    /// <summary>
    /// This card’s ID on TCGplayer’s API, for its etched version if that version is a separate product.
    /// </summary>
    [JsonProperty("tcgplayer_etched_id")]
    public int? TcgplayerEtchedId { get; set; }

    /// <summary>
    /// This card’s ID on Cardmarket’s API, also known as the idProduct.
    /// </summary>
    [JsonProperty("cardmarket_id")]
    public int? CardmarketId { get; set; }

    /// <summary>
    /// A code for this card’s layout.
    /// </summary>
    [JsonProperty("layout")]
    public string? Layout { get; set; }

    /// <summary>
    /// A unique ID for this card’s oracle identity.
    /// This value is consistent across reprinted card editions, and unique among different cards with the same name (tokens, Unstable variants, etc).
    /// Always present except for the reversible_card layout where it will be absent; oracle_id will be found on each face instead.
    /// </summary>
    [JsonProperty("oracle_id")]
    public Guid? OracleId { get; set; }

    /// <summary>
    /// A link to where you can begin paginating all re/prints for this card on Scryfall’s API.
    /// </summary>
    [JsonProperty("prints_search_uri")]
    public string? PrintsSearchUri { get; set; }

    /// <summary>
    /// A link to this card’s rulings list on Scryfall’s API.
    /// </summary>
    [JsonProperty("rulings_uri")]
    public string? RulingsUri { get; set; }

    /// <summary>
    /// A link to this card’s permapage on Scryfall’s website.
    /// </summary>
    [JsonProperty("scryfall_uri")]
    public string? ScryfallUri { get; set; }

    /// <summary>
    /// A link to this card object on Scryfall’s API.
    /// </summary>
    [JsonProperty("uri")]
    public string? Uri { get; set; }

    #endregion

    #region Gameplay Fields

    /// <summary>
    /// If this card is closely related to other cards, this property will be an array with Related Card Objects.
    /// </summary>
    [JsonProperty("all_parts")]
    public List<RelatedCardObject>? AllParts { get; set; }

    /// <summary>
    /// An array of Card Face objects, if this card is multifaced.
    /// </summary>
    [JsonProperty("card_faces")]
    public List<CardFaceObject>? CardFaces { get; set; }

    /// <summary>
    /// The card’s mana value. Note that some funny cards have fractional mana costs.
    /// </summary>
    [JsonProperty("cmc")]
    public decimal? Cmc { get; set; }

    /// <summary>
    /// This card’s color identity.
    /// </summary>
    [JsonProperty("color_identity")]
    public List<string>? ColorIdentity { get; set; }

    /// <summary>
    /// The colors in this card’s color indicator, if any. A null value for this field indicates the card does not have one.
    /// </summary>
    [JsonProperty("color_indicator")]
    public List<string>? ColorIndicator { get; set; }

    /// <summary>
    /// This card’s colors, if the overall card has colors defined by the rules. Otherwise the colors will be on the card_faces objects, see below.
    /// </summary>
    [JsonProperty("colors")]
    public List<string>? Colors { get; set; }

    /// <summary>
    /// This face’s defense, if any.
    /// </summary>
    [JsonProperty("defense")]
    public string? Defense { get; set; }

    /// <summary>
    /// This card’s overall rank/popularity on EDHREC. Not all cards are ranked.
    /// </summary>
    [JsonProperty("edhrec_rank")]
    public int? EdhrecRank { get; set; }

    /// <summary>
    /// This card’s hand modifier, if it is Vanguard card. This value will contain a delta, such as -1.
    /// </summary>
    [JsonProperty("hand_modifier")]
    public string? HandModifier { get; set; }

    /// <summary>
    /// An array of keywords that this card uses, such as 'Flying' and 'Cumulative upkeep'.
    /// </summary>
    [JsonProperty("keywords")]
    public List<string>? Keywords { get; set; }

    /// <summary>
    /// An object describing the legality of this card across play formats. Possible legalities are legal, not_legal, restricted, and banned.
    /// </summary>
    [JsonProperty("legalities")]
    public Dictionary<string, string>? Legalities { get; set; }

    /// <summary>
    /// This card’s life modifier, if it is Vanguard card. This value will contain a delta, such as +2.
    /// </summary>
    [JsonProperty("life_modifier")]
    public string? LifeModifier { get; set; }

    /// <summary>
    /// This loyalty if any. Note that some cards have loyalties that are not numeric, such as X.
    /// </summary>
    [JsonProperty("loyalty")]
    public string? Loyalty { get; set; }

    /// <summary>
    /// The mana cost for this card. This value will be any empty string "" if the cost is absent.
    /// Remember that per the game rules, a missing mana cost and a mana cost of {0} are different values.
    /// Multi-faced cards will report this value in card faces.
    /// </summary>
    [JsonProperty("mana_cost")]
    public string? ManaCost { get; set; }

    /// <summary>
    /// The name of this card.
    /// If this card has multiple faces, this field will contain both names separated by ␣//␣.
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The Oracle text for this card, if any.
    /// </summary>
    [JsonProperty("oracle_text")]
    public string? OracleText { get; set; }

    /// <summary>
    /// This card’s rank/popularity on Penny Dreadful.
    /// Not all cards are ranked.
    /// </summary>
    [JsonProperty("penny_rank")]
    public int? PennyRank { get; set; }

    /// <summary>
    /// This card’s power, if any.
    /// Note that some cards have powers that are not numeric, such as *.
    /// </summary>
    [JsonProperty("power")]
    public string? Power { get; set; }

    /// <summary>
    /// Colors of mana that this card could produce.
    /// </summary>
    [JsonProperty("produced_mana")]
    public List<string>? ProducedMana { get; set; }

    /// <summary>
    /// True if this card is on the Reserved List.
    /// </summary>
    [JsonProperty("reserved")]
    public bool Reserved { get; set; }

    /// <summary>
    /// This card’s toughness, if any.
    /// Note that some cards have toughnesses that are not numeric, such as *.
    /// </summary>
    [JsonProperty("toughness")]
    public string? Toughness { get; set; }

    /// <summary>
    /// The type line of this card.
    /// </summary>
    [JsonProperty("type_line")]
    public string? TypeLine { get; set; }

    #endregion

    #region Print Fields

    /// <summary>
    /// The name of the illustrator of this card.
    /// Newly spoiled cards may not have this field yet.
    /// </summary>
    [JsonProperty("artist")]
    public string? Artist { get; set; }

    /// <summary>
    /// The IDs of the artists that illustrated this card.
    /// Newly spoiled cards may not have this field yet.
    /// </summary>
    [JsonProperty("artist_ids")]
    public List<Guid>? ArtistIds { get; set; }

    /// <summary>
    /// The lit Unfinity attractions lights on this card, if any.
    /// </summary>
    [JsonProperty("attraction_lights")]
    public List<string>? AttractionLights { get; set; }

    /// <summary>
    /// Whether this card is found in boosters.
    /// </summary>
    [JsonProperty("booster")]
    public bool Booster { get; set; }

    /// <summary>
    /// This card’s border color: black, white, borderless, silver, or gold.
    /// </summary>
    [JsonProperty("border_color")]
    public string? BorderColor { get; set; }

    /// <summary>
    /// The Scryfall ID for the card back design present on this card.
    /// </summary>
    [JsonProperty("card_back_id")]
    public Guid CardBackId { get; set; }

    /// <summary>
    /// This card’s collector number. Note that collector numbers can contain non-numeric characters, such as letters or ★.
    /// </summary>
    [JsonProperty("collector_number")]
    public string? CollectorNumber { get; set; }

    /// <summary>
    /// True if you should consider avoiding use of this print downstream.
    /// </summary>
    [JsonProperty("content_warning")]
    public bool? ContentWarning { get; set; }

    /// <summary>
    /// True if this card was only released in a video game.
    /// </summary>
    [JsonProperty("digital")]
    public bool Digital { get; set; }

    /// <summary>
    /// An array of computer-readable flags that indicate if this card can come in foil, nonfoil, or etched finishes.
    /// </summary>
    [JsonProperty("finishes")]
    public List<string>? Finishes { get; set; }

    /// <summary>
    /// The just-for-fun name printed on the card (such as for Godzilla series cards).
    /// </summary>
    [JsonProperty("flavor_name")]
    public string? FlavorName { get; set; }

    /// <summary>
    /// The flavor text, if any.
    /// </summary>
    [JsonProperty("flavor_text")]
    public string? FlavorText { get; set; }

    /// <summary>
    /// This card’s frame effects, if any.
    /// </summary>
    [JsonProperty("frame_effects")]
    public List<string>? FrameEffects { get; set; }

    /// <summary>
    /// This card’s frame layout.
    /// </summary>
    [JsonProperty("frame")]
    public string? Frame { get; set; }

    /// <summary>
    /// True if this card’s artwork is larger than normal.
    /// </summary>
    [JsonProperty("full_art")]
    public bool FullArt { get; set; }

    /// <summary>
    /// A list of games that this card print is available in, paper, arena, and/or mtgo
    /// </summary>
    [JsonProperty("games")]
    public List<string>? Games { get; set; }

    /// <summary>
    /// True if this card’s imagery is high resolution.
    /// </summary>
    [JsonProperty("highres_image")]
    public bool HighresImage { get; set; }

    /// <summary>
    /// A unique identifier for the card artwork that remains consistent across reprints.
    /// Newly spoiled cards may not have this field yet.
    /// </summary>
    [JsonProperty("illustration_id")]
    public Guid? IllustrationId { get; set; }

    /// <summary>
    /// A computer-readable indicator for the state of this card’s image, one of missing, placeholder, lowres, or highres_scan.
    /// </summary>
    [JsonProperty("image_status")]
    public string? ImageStatus { get; set; }

    /// <summary>
    /// An object listing available imagery for this card. See the Card Imagery article for more information.
    /// </summary>
    [JsonProperty("image_uris")]
    public Dictionary<string, Uri>? ImageUris { get; set; }

    /// <summary>
    /// True if this card is oversized.
    /// </summary>
    [JsonProperty("oversized")]
    public bool Oversized { get; set; }

    /// <summary>
    /// An object containing daily price information for this card.
    /// </summary>
    [JsonProperty("prices")]
    public PriceInfo? Prices { get; set; }

    /// <summary>
    /// The localized name printed on this card, if any.
    /// </summary>
    [JsonProperty("printed_name")]
    public string? PrintedName { get; set; }

    /// <summary>
    /// The localized text printed on this card, if any.
    /// </summary>
    [JsonProperty("printed_text")]
    public string? PrintedText { get; set; }

    /// <summary>
    /// The localized type line printed on this card, if any.
    /// </summary>
    [JsonProperty("printed_type_line")]
    public string? PrintedTypeLine { get; set; }

    /// <summary>
    /// True if this card is a promotional print.
    /// </summary>
    [JsonProperty("promo")]
    public bool Promo { get; set; }

    /// <summary>
    /// An array of strings describing what categories of promo cards this card falls into.
    /// </summary>
    [JsonProperty("promo_types")]
    public List<string>? PromoTypes { get; set; }

    /// <summary>
    /// An object providing URIs to this card’s listing on major marketplaces. Omitted if the card is unpurchaseable.
    /// </summary>
    [JsonProperty("purchase_uris")]
    public Dictionary<string, string>? PurchaseUris { get; set; }

    /// <summary>
    /// This card’s rarity. One of common, uncommon, rare, special, mythic, or bonus.
    /// </summary>
    [JsonProperty("rarity")]
    public string? Rarity { get; set; }

    /// <summary>
    /// An object providing URIs to this card’s listing on other Magic: The Gathering online resources.
    /// </summary>
    [JsonProperty("related_uris")]
    public Dictionary<string, Uri>? RelatedUris { get; set; }

    /// <summary>
    /// The date this card was first released.
    /// </summary>
    [JsonProperty("released_at")]
    public DateOnly ReleasedAt { get; set; }

    /// <summary>
    /// True if this card is a reprint.
    /// </summary>
    [JsonProperty("reprint")]
    public bool Reprint { get; set; }

    /// <summary>
    /// A link to this card’s set on Scryfall’s website.
    /// </summary>
    [JsonProperty("scryfall_set_uri")]
    public string? ScryfallSetUri { get; set; }

    /// <summary>
    /// This card’s full set name.
    /// </summary>
    [JsonProperty("set_name")]
    public string? SetName { get; set; }

    /// <summary>
    /// A link to where you can begin paginating this card’s set on the Scryfall API.
    /// </summary>
    [JsonProperty("set_search_uri")]
    public string? SetSearchUri { get; set; }

    /// <summary>
    /// The type of set this printing is in.
    /// </summary>
    [JsonProperty("set_type")]
    public string? SetType { get; set; }

    /// <summary>
    /// A link to this card’s set object on Scryfall’s API.
    /// </summary>
    [JsonProperty("set_uri")]
    public string? SetUri { get; set; }

    /// <summary>
    /// This card’s set code.
    /// </summary>
    [JsonProperty("set")]
    public string? Set { get; set; }

    /// <summary>
    /// This card’s Set object UUID.
    /// </summary>
    [JsonProperty("set_id")]
    public Guid SetId { get; set; }

    /// <summary>
    /// True if this card is a Story Spotlight.
    /// </summary>
    [JsonProperty("story_spotlight")]
    public bool StorySpotlight { get; set; }

    /// <summary>
    /// True if the card is printed without text.
    /// </summary>
    [JsonProperty("textless")]
    public bool Textless { get; set; }

    /// <summary>
    /// Whether this card is a variation of another printing.
    /// </summary>
    [JsonProperty("variation")]
    public bool Variation { get; set; }

    /// <summary>
    /// The printing ID of the printing this card is a variation of.
    /// </summary>
    [JsonProperty("variation_of")]
    public Guid? VariationOf { get; set; }

    /// <summary>
    /// The security stamp on this card, if any.
    /// One of oval, triangle, acorn, circle, arena, or heart.
    /// </summary>
    [JsonProperty("security_stamp")]
    public string? SecurityStamp { get; set; }

    /// <summary>
    /// This card’s watermark, if any.
    /// </summary>
    [JsonProperty("watermark")]
    public string? Watermark { get; set; }

    /// <summary>
    /// Preview data of a card.
    /// </summary>
    [JsonProperty("preview")]
    public PreviewInfo? Preview { get; set; }

    #endregion
}

public class CardFaceObject : ScryfallObject
{
    /// <summary>
    /// The name of the illustrator of this card face. Newly spoiled cards may not have this field yet.
    /// </summary>
    [JsonProperty("artist")]
    public string? Artist { get; set; }

    /// <summary>
    /// The ID of the illustrator of this card face. Newly spoiled cards may not have this field yet.
    /// </summary>
    [JsonProperty("artist_id")]
    public Guid? ArtistId { get; set; }

    /// <summary>
    /// The mana value of this particular face, if the card is reversible.
    /// </summary>
    [JsonProperty("cmc")]
    public decimal? Cmc { get; set; }

    /// <summary>
    /// The colors in this face’s color indicator, if any.
    /// </summary>
    [JsonProperty("color_indicator")]
    public List<string>? ColorIndicator { get; set; }

    /// <summary>
    /// This face’s colors, if the game defines colors for the individual face of this card.
    /// </summary>
    [JsonProperty("colors")]
    public List<string>? Colors { get; set; }

    /// <summary>
    /// This face’s defense, if the game defines colors for the individual face of this card.
    /// </summary>
    [JsonProperty("defense")]
    public string? Defense { get; set; }

    /// <summary>
    /// The flavor text printed on this face, if any.
    /// </summary>
    [JsonProperty("flavor_text")]
    public string? FlavorText { get; set; }

    /// <summary>
    /// A unique identifier for the card face artwork that remains consistent across reprints.
    /// Newly spoiled cards may not have this field yet.
    /// </summary>
    [JsonProperty("illustration_id")]
    public Guid? IllustrationId { get; set; }

    /// <summary>
    /// An object providing URIs to imagery for this face, if this is a double-sided card.
    /// If this card is not double-sided, then the image_uris property will be part of the parent object instead.
    /// </summary>
    [JsonProperty("image_uris")]
    public Dictionary<string, Uri>? ImageUris { get; set; }

    /// <summary>
    /// The layout of this card face, if the card is reversible.
    /// </summary>
    [JsonProperty("layout")]
    public string? Layout { get; set; }

    /// <summary>
    /// This face’s loyalty, if any.
    /// </summary>
    [JsonProperty("loyalty")]
    public string? Loyalty { get; set; }

    /// <summary>
    /// The mana cost for this face. This value will be any empty string "" if the cost is absent.
    /// Remember that per the game rules, a missing mana cost and a mana cost of {0} are different values.
    /// </summary>
    [JsonProperty("mana_cost")]
    public string? ManaCost { get; set; }

    /// <summary>
    /// The name of this particular face.
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The Oracle ID of this particular face, if the card is reversible.
    /// </summary>
    [JsonProperty("oracle_id")]
    public Guid? OracleId { get; set; }

    /// <summary>
    /// The Oracle text for this face, if any.
    /// </summary>
    [JsonProperty("oracle_text")]
    public string? OracleText { get; set; }

    /// <summary>
    /// This face’s power, if any.
    /// Note that some cards have powers that are not numeric, such as *.
    /// </summary>
    [JsonProperty("power")]
    public string? Power { get; set; }

    /// <summary>
    /// The localized name printed on this face, if any.
    /// </summary>
    [JsonProperty("printed_name")]
    public string? PrintedName { get; set; }

    /// <summary>
    /// The localized text printed on this face, if any.
    /// </summary>
    [JsonProperty("printed_text")]
    public string? PrintedText { get; set; }

    /// <summary>
    /// The localized type line printed on this face, if any.
    /// </summary>
    [JsonProperty("printed_type_line")]
    public string? PrintedTypeLine { get; set; }

    /// <summary>
    /// This face’s toughness, if any.
    /// </summary>
    [JsonProperty("toughness")]
    public string? Toughness { get; set; }

    /// <summary>
    /// The type line of this particular face, if the card is reversible.
    /// </summary>
    [JsonProperty("type_line")]
    public string? TypeLine { get; set; }

    /// <summary>
    /// The watermark on this particulary card face, if any.
    /// </summary>
    [JsonProperty("watermark")]
    public string? Watermark { get; set; }
}

public class RelatedCardObject : ScryfallObject
{
    /// <summary>
    /// An unique ID for this card in Scryfall’s database.
    /// </summary>
    [JsonProperty("id")]
    public Guid Id { get; set; }

    /// <summary>
    /// A field explaining what role this card plays in this relationship, one of token, meld_part, meld_result, or combo_piece.
    /// </summary>
    [JsonProperty("component")]
    public string? Component { get; set; }

    /// <summary>
    /// The name of this particular related card.
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The type line of this card.
    /// </summary>
    [JsonProperty("type_line")]
    public string? TypeLine { get; set; }

    /// <summary>
    /// A URI where you can retrieve a full object describing this card on Scryfall’s API.
    /// </summary>
    [JsonProperty("uri")]
    public string? Uri { get; set; }
}

public class PriceInfo
{
    /// <summary>
    /// USD price for regular
    /// </summary>
    [JsonProperty("usd")]
    public string? Usd { get; set; }

    /// <summary>
    /// USD price for foil version
    /// </summary>
    [JsonProperty("usd_foil")]
    public string? UsdFoil { get; set; }

    /// <summary>
    /// USD price for etched version
    /// </summary>
    [JsonProperty("usd_etched")]
    public string? UsdEtched { get; set; }

    /// <summary>
    /// EUR price for regular version
    /// </summary>
    [JsonProperty("eur")]
    public string? Eur { get; set; }

    /// <summary>
    /// EUR price for foil version
    /// </summary>
    [JsonProperty("eur_foil")]
    public string? EurFoil { get; set; }

    /// <summary>
    /// EUR price for etched version
    /// </summary>
    [JsonProperty("eur_etched")]
    public string? EurEtched { get; set; }

    /// <summary>
    /// Tix price
    /// </summary>
    [JsonProperty("tix")]
    public string? Tix { get; set; }
}

public class PreviewInfo
{
    /// <summary>
    /// The date this card was previewed.
    /// </summary>
    [JsonProperty("previewed_at")]
    public DateOnly? PreviewedAt { get; set; }

    /// <summary>
    /// A link to the preview for this card.
    /// </summary>
    [JsonProperty("source_uri")]
    public string? SourceUri { get; set; }

    /// <summary>
    /// The name of the source that previewed this card.
    /// </summary>
    [JsonProperty("source")]
    public string? Source { get; set; }
}