using System;
using System.Collections.Generic;
using System.Text;

namespace Lathorva.Common.Authentication.Jwt
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ScewMinutes { get; set; }
    }
}
