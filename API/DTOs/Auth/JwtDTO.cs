using System;

namespace API.DTOs.Auth
{
    public class JwtDTO
    {
        public string Token { get; set; }
        public DateTime ExpDate { get; set; }
        public string UserName { get; set; }
        public long UserId { get; set; }
        public string UserRole { get; set; }
        public bool IsAuthenticated { get; set; }
        public int FailedLoginAttemptCount { get; set; }

    }
}
