using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("UserType", Schema = "dbo")]
    public class UserType : Entity
    {
        public string Type { get; set; }
    }
}
