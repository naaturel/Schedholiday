using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SchedHoliday.Services;
using SchedHoliday.ViewModels;

namespace SchedHoliday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IMailService _mailService;

        public UserController(IUserService userService, IMailService mailService)
        {
            _userService = userService;
            _mailService = mailService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await _userService.Get(); 
                return Ok(res.ToJson());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "An error occured" });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {

                var res = await _userService.GetBy(id);
                return Ok(res.ToJson());
            } catch (Exception ex)
            {
                return BadRequest(new { Message = "An error occured" });
            }   
        }

        [HttpGet("/email/{email}")]
        public async Task<IActionResult> GetBy(string email)
        {
            try
            {

                var res = await _userService.GetByEmail(email);
                return Ok(res.ToJson());
            } catch (Exception ex)
            {
                return BadRequest(new { Message = "An error occured" });
            }   
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserPost user)
        {
            try
            {
                await _userService.Post(user);
                _mailService.SendConfirmation(user.Email);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] UserPut user)
        {
            try
            {
                await _userService.Put(user);
                return Ok();
            } catch (Exception ex)
            {
                return BadRequest("An error occured while registering the user");
            }

            
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete([FromBody] UserDelete user)
        {
            try
            {
                await _userService.Delete(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occured while registering the user");
            }
        }
    }
}
