using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class DiscoverAPIController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AuthService _authService;

        public DiscoverAPIController(IConfiguration config, AuthService authService)
        {
            _config = config;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var authHeader = Request.Headers["Authorization"].FirstOrDefault();

            if (!_authService.IsAuthorized(authHeader))
            {
                return Unauthorized();
            }

            var backendUrl = _config["UrlsConfig:BackendUrl"] ?? "";
            var identityUrl = _config["UrlsConfig:IdentityUrl"] ?? "";

            var response = new DiscoverAPIResponse
            {
                BackendUrl = backendUrl,
                IdentityUrl = identityUrl
            };

            return Ok(response);
        }
    }
}