using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ti9.Models;
using Microsoft.Extensions.Primitives;

namespace Ti9.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _service;

        public ClientController(ClientService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var response = await _service.List();

            switch (response.State)
            {
                case ResponseState.Exception:
                    return StatusCode(500, response.Exception.Message);
                case ResponseState.Error:
                    return BadRequest(response.MessageText);
                default:
                    return Ok(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Client model)
        {
            var response = await _service.Create(model);

            switch (response.State)
            {
                case ResponseState.Exception:
                    return StatusCode(500, response.Exception.Message);
                case ResponseState.Error:
                    return BadRequest(response.MessageText);
                default:
                    return Ok(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Client model)
        {
            var response = await _service.Update(model);

            switch (response.State)
            {
                case ResponseState.Exception:
                    return StatusCode(500, response.Exception.Message);
                case ResponseState.Error:
                    return BadRequest(response.MessageText);
                default:
                    return Ok(response);
            }
        }

        private string GetUserAgent()
        {
            StringValues headers = Request.Headers["User-Agent"];
            if (StringValues.IsNullOrEmpty(headers))
                return null;
            return headers[0];
        }
    }
}
