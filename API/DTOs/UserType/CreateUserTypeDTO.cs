using System;

namespace API.DTOs.UserType
{
    public class CreateUserTypeDTO
    {
        public string  Type { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
