using API.DTOs.UserType;
using System;

namespace API.DTOs.User
{
    public class GetUserDTO
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public long UserTypeId { get; set; }

        public GetUserTypeDTO UserType { get; set; }
        public bool IsVerified { get; set; }
        public string FullName { get; set; }
        public DateTime? Created_At { get; set; }
        public long Created_By { get; set; }
        public DateTime? Modified_At { get; set; }
        public long Modified_By { get; set; }

    }
}
