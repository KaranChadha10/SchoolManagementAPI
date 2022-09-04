using System.ComponentModel.DataAnnotations;

namespace API.DTOs.User
{
    public class CreateUserDTO
    { 
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }
    public string Password { get; set; }


    [Required(AllowEmptyStrings = false, ErrorMessage = "UserType_Id is required.")]
    public long UserTypeId { get; set; }
    public bool IsVerified { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
    public string FullName { get; set; }
    public bool IsActive { get; set; }
    public long Created_By { get; set; }
    public long Modified_By { get; set; }

}
}
