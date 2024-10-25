using Microsoft.AspNetCore.Mvc;
using SchedHoliday.Services;
using Microsoft.AspNetCore.Authorization;
using NuGet.Protocol;
using SchedHoliday.ViewModels;

namespace SchedHoliday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {

        private IHolidayService _holidayServices;
        private IMessageService _messageServices;


        public HolidayController(IHolidayService holidayService, IMessageService messageService)
        {
            _holidayServices = holidayService;
            _messageServices = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await _holidayServices.Get();
                return Ok(res.ToJson());

            } catch (Exception ex)
            {
                return BadRequest(new { Message = "An error occured"});
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var res = await _holidayServices.GetBy(id);
                return Ok(res.ToJson());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] HolidayPost holiday)
        {
            try
            {
                var holidayId = await _holidayServices.Post(holiday);
                await _messageServices.StartChat(holidayId);
                return Ok();

            } catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] HolidayPut holiday)
        {

            try
            {
                await _holidayServices.Put(holiday);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "An error occured" });
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete([FromBody] HolidayDelete holiday)
        {
            try
            {
                await _holidayServices.Delete(holiday);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "An error occured" });
            }
        }
    }
}
