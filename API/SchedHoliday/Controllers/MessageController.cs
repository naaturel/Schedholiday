using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NuGet.Protocol;
using SchedHoliday.Models;
using SchedHoliday.Services;
using SchedHoliday.ViewModels;

namespace SchedHoliday.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class MessageController : ControllerBase
    {

        private IMessageService _messageService;


        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var msgs = await _messageService.Get();
                return Ok(msgs.ToJson());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task Post([FromBody] MessagePost data)
        {
           await _messageService.Post(data);
        }
    }
}
