using System;

namespace API.DTOs.Subject
{
    public class GetSubjectDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SubjectClass { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        //public long CreateBy { get; set; }
        public DateTime CreatedAt { get; set; }
        //public long ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

    }
}
