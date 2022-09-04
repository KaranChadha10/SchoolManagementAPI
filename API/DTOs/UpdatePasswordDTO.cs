using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class UpdatePasswordDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required.")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int UserId { get; set; }
    }
}
