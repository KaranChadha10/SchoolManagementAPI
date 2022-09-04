namespace API.Filters
{
    public class UserFilter : PaginationFilter
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string  FullName { get; set; }
        public long UserTypeId { get; set; }
    }
}
