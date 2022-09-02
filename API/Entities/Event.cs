using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Event", Schema = "dbo")]
    public class Event : Entity
    {
        public string  Name { get; set; }
        public DateTime EventDate{ get; set; }
    }
}
