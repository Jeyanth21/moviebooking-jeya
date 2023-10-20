using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicketBooking.Business.Service;
using MovieTicketBooking.Data.Models.Dto;
using System.Security.Claims;

namespace MovieTicketBooking.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "UserOnly")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public TicketController(ITicketService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{theatreId}/Book")]
        public async Task<IActionResult> TicketBook([FromBody] TicketDto model, [FromRoute] string theatreId)
        {
            var userId = User.FindFirstValue("Id");
            var response = await _service.TicketBook(model, userId, theatreId);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
