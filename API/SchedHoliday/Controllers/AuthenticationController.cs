using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SchedHoliday.Services;
using SchedHoliday.ViewModels;

namespace SchedHoliday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService userService)
        {
            _authService = userService;
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequest viewModel)
        {
            try
            {
                var response = await _authService.Authenticate(viewModel);
                return Ok(response.ToJson());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost, AllowAnonymous, Route("oauth")]
        public async Task<IActionResult> AuthenticateByOAuth([FromBody] OAuthRequest viewModel)
        {
            try
            {
                var response = await _authService.AuthenticateByOAuth(viewModel);
                return Ok(response.ToJson());

            } catch (Exception ex)
            {
                return BadRequest(new { message = "An error occured" });
            }
        }
    }
}
