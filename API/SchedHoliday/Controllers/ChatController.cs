using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SchedHoliday.Services;
using SchedHoliday.ViewModels;

namespace SchedHoliday.Controllers
{
    [ApiController, Route("/api/[controller]")]
    public class ChatController : ControllerBase
    {

        private IMessageService _messageService;


        public ChatController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("{holidayId}"), Authorize]
        public async Task<IActionResult> Get(string holidayId)
        {
            try
            {
                var msgs = await _messageService.GetBy(holidayId); 
                return Ok(msgs.ToJson());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromBody] MessagePost msg)
        {
            try { 
                await _messageService.Post(msg);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}