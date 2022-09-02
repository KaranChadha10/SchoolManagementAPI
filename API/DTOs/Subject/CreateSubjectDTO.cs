using System;

namespace API.DTOs.Subject
{
    public class CreateSubjectDTO
    {
        public string Name { get; set; }
        public string SubjectClass { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt{ get; set; }
    }
}
