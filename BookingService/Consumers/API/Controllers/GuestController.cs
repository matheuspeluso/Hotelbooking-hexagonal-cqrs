using Application;
using Application.Guest.Dtos;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly ILogger<GuestController> _logger;
        private readonly IGuestManager _guestManager;

        public GuestController(ILogger<GuestController> logger, IGuestManager guestManager)
        {
            _logger = logger;
            _guestManager = guestManager;
        }

        [HttpPost("create-guest")]
        public async Task<IActionResult> Post(GuestDTO guest)
        {
            var request = new CreateGuestRequest { Data = guest };
            var res = await _guestManager.CreateGuest(request);

            if(res.Success) return Ok(res.Data);

            if(res.ErrorCoders == ErrorCoders.NOT_FOUND)
            {
                return BadRequest(res);
            }
            else if(res.ErrorCoders == ErrorCoders.INVALID_PERSON_ID)
            {
                return BadRequest(res);
            }
            else if(res.ErrorCoders == ErrorCoders.COULD_NOT_STORE_DATA)
            {
                return BadRequest(res);
            }
            else if(res.ErrorCoders == ErrorCoders.MISSING_REQUIRED_INFORMATION)
            {
                return BadRequest(res);
            }
            else if(res.ErrorCoders == ErrorCoders.INVALID_EMAIL)
            {
                return BadRequest(res);
            }

            _logger.LogError("Response with unknow ErrorCode Returned", res);
            return StatusCode(500, new
            {
                message = "internal server error, unknown error code returned"
            });

        }
    }
}
