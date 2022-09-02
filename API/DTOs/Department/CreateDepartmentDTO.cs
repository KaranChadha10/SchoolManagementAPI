using System;

namespace API.DTOs.Department
{
    public class CreateDepartmentDTO
    {
        public string Name { get; set; }
        public string HOD { get; set; }
        public int StartYear { get; set; }
        public long StudentsCount { get; set; }
        public bool IsActive { get; set; }
        public bool  IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

    }
}
