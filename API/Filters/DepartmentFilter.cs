namespace API.Filters
{
    public class DepartmentFilter : PaginationFilter
    {
        public string Name { get; set; }
        public string  StudentsCount { get; set; }
    }
}
