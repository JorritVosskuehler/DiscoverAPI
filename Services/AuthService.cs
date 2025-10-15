using System.Text;

namespace Services
{
    public class AuthService
    {
        private readonly string _username;
        private readonly string _password;

        public AuthService(IConfiguration config)
        {
            _username = config["Auth:Username"]!;
            _password = config["Auth:Password"]!;
        }

        public bool IsAuthorized(string? authHeader)
        {
            if (string.IsNullOrWhiteSpace(authHeader))
            {
                return false;
            }

            var encodedCredentials = authHeader.Substring("Basic ".Length).Trim();
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials)).Split(':');

            if (credentials.Length != 2)
            {
                return false;
            }

            var username = credentials[0];
            var password = credentials[1];

            return username == _username && password == _password;
        }
    }
}