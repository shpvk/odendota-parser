using Microsoft.AspNetCore.Mvc;
using protracker_parser.Models;
using protracker_parser.Services;

namespace protracker_parser.Controllers
{
    [Route("api/[controller]")]
    public class ParserController : ControllerBase
    {

        private readonly ParserService _parserService;
        public ParserController()
        {
            _parserService = new ParserService();
        }

        [HttpPost]
        public IActionResult Process([FromBody] UserRequest userRequest)
        {
            var result = _parserService.Process(userRequest.InputText);
            return Ok(result);
        }
    }
}
