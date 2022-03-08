using Microsoft.AspNetCore.Mvc;
using Stock.Application.Contracts;
using Stock.Application.Service.Interfaces;

namespace Stock.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotoController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public PhotoController(IServiceManager service)
        {
            serviceManager = service;
        }

        [HttpGet("GetAllPhotos")]
        public async Task<IActionResult> GetPhotos(CancellationToken cancellationToken)
        {
            var photosDto = await serviceManager.PhotoService.GetAllAsync(cancellationToken);
            return Ok(photosDto);
        }

        [HttpGet("GetPhotoById")]
        public async Task<IActionResult> GetPhotoById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var photoDto = await serviceManager.PhotoService.GetById(id, cancellationToken);
                return Ok(photoDto);
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }

        }

        [HttpPut("UpdatePhoto")]
        public async Task<IActionResult> UpdatePhoto(Guid id, [FromBody] PhotoDtoForUpdating photoDtoUpdated, CancellationToken cancellationToken)
        {
            try
            {
                await serviceManager.PhotoService.UpdateAsync(id, photoDtoUpdated, cancellationToken);
                return NoContent();
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }

        }
    }
}
