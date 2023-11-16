﻿using Newtonsoft.Json;

namespace Scryfall.Domain.Response;

public class ListObject<TObject> : ScryfallObject
{
    /// <summary>
    /// An array of the requested objects, in a specific order.
    /// </summary>
    [JsonProperty("data")]
    public IEnumerable<TObject>? Data { get; set; }

    /// <summary>
    /// True if this List is paginated and there is a page beyond the current page.
    /// </summary>
    [JsonProperty("has_more")]
    public bool HasMore { get; set; }

    /// <summary>
    /// If there is a page beyond the current page, this field will contain a full API URI to that page.
    /// You may submit a HTTP GET request to that URI to continue paginating forward on this List.
    /// </summary>
    [JsonProperty("next_page")]
    public string? NextPage { get; set; }

    /// <summary>
    /// If this is a list of Card objects, this field will contain the total number of cards found across all pages.
    /// </summary>
    [JsonProperty("total_cards")]
    public int? TotalCards { get; set; }

    /// <summary>
    /// An array of human-readable warnings issued when generating this list, as strings.
    /// Warnings are non-fatal issues that the API discovered with your input.
    /// In general, they indicate that the List will not contain the all of the information you requested.
    /// You should fix the warnings and re-submit your request.
    /// </summary>
    [JsonProperty("warnings")]
    public IEnumerable<string>? Warnings { get; set; }
}