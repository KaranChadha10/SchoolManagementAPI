using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Entity
    {
        [Key]
        public long Id { get; set; }
        public bool? IsActive { get; set; }
        public bool  IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
