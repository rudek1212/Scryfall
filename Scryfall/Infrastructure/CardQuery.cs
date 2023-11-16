using System.Text.Json.Serialization;

namespace Scryfall.Infrastructure;

public class CardQuery
{
    public List<string> Name { get; set; } = new();
    public List<string> NameExcl { get; set; } = new();

    public List<string> Text { get; set; } = new();
    public List<string> TextExcl { get; set; } = new();

    public List<string> Type { get; set; } = new();
    public List<string> TypeExcl { get; set; } = new();
    public bool TypeAllowPartial { get; set; }

    public List<string> Colors { get; set; } = new();
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CardQueryColorType ColorType { get; set; }

    public List<string> ColorIdent { get; set; } = new();

    public List<string> ManaCost { get; set; } = new();

    //TODO Stats

    public bool IsPaper { get; set; }
    public bool IsArena { get; set; }
    public bool IsMagicOnline { get; set; }

    public List<string> Legal { get; set; } = new();
    public List<string> Restricted { get; set; } = new();
    public List<string> Banned { get; set; } = new();

    public List<string> Set { get; set; } = new();
    public List<string> Block { get; set; } = new();
    public List<string> Rarity { get; set; } = new();

    //TODO Criteria

    //TODO Prices

    public List<string> Artist { get; set; } = new();

    public List<string> Flavor { get; set; } = new();

    public List<string> Lore { get; set; } = new();

    public string? Language { get; set; }

    public enum CardQueryColorType
    {
        Exact,
        Include,
        AtMost
    }
}