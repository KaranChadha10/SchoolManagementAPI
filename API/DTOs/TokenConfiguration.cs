using System;

namespace API.DTOs
{
    public class TokenConfiguration
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }

        public static implicit operator string(TokenConfiguration v)
        {
            throw new NotImplementedException();
        }
    }
}
