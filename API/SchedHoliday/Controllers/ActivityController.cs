using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SchedHoliday.Services;
using SchedHoliday.ViewModels;


namespace SchedHoliday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await _activityService.Get();
                return Ok(res.ToJson());
            } catch (Exception ex)
            {
                return BadRequest(new { message = "An error occured while retreving data" });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var res = await _activityService.GetBy(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An error occured while retrieving data" });
            }
        }

        [HttpGet("holiday/{id}")]
        [Authorize]
        public async Task<IActionResult> GetByHoliday(string id)
        {

            try
            {
                var res = await _activityService.GetByHoliday(id);
                return Ok(res.ToJson());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An error occured while retrieving data" });
            }
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] ActivityPost activity)
        {
            try
            {
                var success = await _activityService.Post(activity);
                if (!success)
                {
                    return BadRequest("Something went wrong");
                }

            } catch (Exception ex)
            {
                return BadRequest(new { message = "An error occured while posting data" });
            }

            return Ok();
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] ActivityPut activity)
        {
            try { 
                var success = await _activityService.Put(activity);
                if (!success)
                {
                    return BadRequest("Something went wrong");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An error occured while posting data" });
            }

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete([FromBody] ActivityDelete activity)
        {
            try
            {
                _activityService.Delete(activity);
                
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An error occured while deleting data" });
            }


            return Ok();
        }
    }
}
