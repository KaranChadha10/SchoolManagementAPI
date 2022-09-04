using API.DTOs.UserType;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("User", Schema = "dbo")]
    public class User : Entity
    {
        [Required]
        public string  Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        
        [ForeignKey("UserType")]
        public long UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }
        public bool IsVerified { get; set; }
        public string FullName { get; set; }

    }
}
