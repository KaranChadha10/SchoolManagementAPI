using System;

namespace API.DTOs.Event
{
    public class CreateEventDTO
    {
        public string Name { get; set; }
        public DateTime EventDate{ get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
