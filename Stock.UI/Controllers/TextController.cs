using Microsoft.AspNetCore.Mvc;
using Stock.Application.Contracts;
using Stock.Application.Service.Interfaces;

namespace Stock.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public TextController(IServiceManager service)
        {
            serviceManager = service;
        }

        [HttpPost(Name = "CreateNewText")]
        public async Task<IActionResult> CreateText([FromBody] TextForCreationDto newTextDto)
        {
            try
            {
                var textDto = await serviceManager.TextService.CreateText(newTextDto);

                return Ok(textDto);
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }

        }

        [HttpGet(Name = "GetTextById")]
        public async Task<IActionResult> GetTextById(Guid textId, CancellationToken ct = default)
        {
            try
            {
                var textDto = await serviceManager.TextService.GetById(textId, ct);

                return Ok(textDto);
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }
        }
    }
}