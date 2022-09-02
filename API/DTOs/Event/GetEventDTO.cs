using System;

namespace API.DTOs.Event
{
    public class GetEventDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime EventDate{ get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        //public long CreateBy { get; set; }
        public DateTime CreatedAt { get; set; }
        //public long ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
