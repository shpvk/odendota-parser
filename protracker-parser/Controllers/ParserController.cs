using Microsoft.AspNetCore.Mvc;
using protracker_parser.Models;
using protracker_parser.Services;

namespace protracker_parser.Controllers
{
    [Route("api/[controller]")]
    public class ParserController : ControllerBase
    {

        private readonly ParserService _parserService;

        public ParserController(ParserService parserService)
        {
            _parserService = parserService;
        }

        [HttpPost]
        public async Task<IActionResult> Process([FromBody] UserRequest userRequest)
        {
            try
            {
                var result = await _parserService.Process(userRequest.InputText);
                return Ok(result);
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
