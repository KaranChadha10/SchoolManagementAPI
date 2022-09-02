namespace API.Filters
{
    public class PaginationFilter
    {
        public virtual int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        
    }
}
