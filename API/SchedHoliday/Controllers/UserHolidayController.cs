using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SchedHoliday.Services;
using SchedHoliday.ViewModels;

namespace SchedHoliday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHolidayController : ControllerBase
    {

        private IUserHolidayService _userHolidayServices;
        private IUserService _userService;
        private IUserHolidayService _userHolidayService;


        public UserHolidayController(IUserHolidayService userHolidayService, IUserService userService)
        {
            _userHolidayServices = userHolidayService;
            _userService = userService;
        }

        [HttpGet("holiday/{id}")]
        [Authorize]
        public async Task<IActionResult> GetUsersByHoliday(string id)
        {
            try
            {
                var res = await _userHolidayServices.GetUsersByHoliday(id);
                return Ok(res.ToJson());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("user/{id}")]
        [Authorize]
        public async Task<IActionResult> GetHolidaysByUser(string id)
        {
            try
            {
                var res = await _userHolidayServices.GetHolidaysByUser(id);
                return Ok(res.ToJson());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] UserHolidayPost userHoliday)
        {
            try
            {
                await _userHolidayServices.Post(userHoliday);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("period/{epochStart}&{epochEnd}")]
        public async Task<IActionResult> GetHolidaysByEpoch(long epochStart, long epochEnd)
        {
            try
            {
                var res = await _userHolidayServices.GetHolidaysByEpoch(
                    DateTimeOffset.FromUnixTimeSeconds(epochStart).DateTime.AddHours(1), 
                    DateTimeOffset.FromUnixTimeSeconds(epochEnd).DateTime.AddHours(1));
                return Ok(res.ToJson());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
