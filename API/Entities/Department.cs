using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Department", Schema = "dbo")]
    public class Department : Entity
    {
        public string Name { get; set; }
        public string HOD { get; set; }
        public int StartYear { get; set; }
        public long StudentsCount { get; set; }
    }
}
