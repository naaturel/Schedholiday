using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchedHoliday.Services;

namespace SchedHoliday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeteoController : ControllerBase
    {
        private IMeteoService _meteoService;

        public MeteoController(IMeteoService meteoService)
        {
            _meteoService = meteoService;
        }

        [HttpGet("{lat}&{lng}")]
        [Authorize]
        public async Task<IActionResult> Get(double lat, double lng)
        {
            try
            {
                var res = await _meteoService.Get(lat, lng);
                return Ok(res);
            }
            catch (Exception ex) {
                return BadRequest(new { Message = "An error occured" });
            }
        }

    }
}
