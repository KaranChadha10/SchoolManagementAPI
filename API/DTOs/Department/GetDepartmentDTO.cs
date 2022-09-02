namespace API.DTOs.Department
{
    public class GetDepartmentDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string HOD { get; set; }
        public int StartYear { get; set; }
        public long StudentsCount { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
