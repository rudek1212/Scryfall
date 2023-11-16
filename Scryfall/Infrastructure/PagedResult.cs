namespace Scryfall.Infrastructure;

public class PagedResult<T>
{
    public List<T>? Items { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int? TotalItems { get; set; }
    public int? TotalPages
    {
        get
        {
            if (TotalItems != null)
                return (int) Math.Ceiling((double) TotalItems / PageSize);
            return null;
        }
    }
}