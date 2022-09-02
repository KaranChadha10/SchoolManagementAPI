using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Subject", Schema = "dbo")]
    public class Subject : Entity
    {
        public string Name { get; set; }
        public string SubjectClass { get; set; }
    }
}
