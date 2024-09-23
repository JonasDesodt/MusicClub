using Microsoft.AspNetCore.Mvc;
using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Attributes;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;
using MusicClub.Dto.Transfer;
using MusicClub.DbCore.Models;
using MusicClub.DbCore;
using MusicClub.Dto.Filters;

namespace MusicClub.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController(IImageDbService imageDbService, MusicClubDbContext dbContext) : Controller
    {
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([Min(1), FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await imageDbService.Get(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationRequest paginationRequest, [FromQuery] ImageFilter filter)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await imageDbService.GetAll(paginationRequest, filter));
        }

        [HttpGet("Exists/{id:int}")]
        public IActionResult Exists([Min(1)] int id)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(imageDbService.Exists(id));
        }

        [HttpGet("Download/{id:int}")]
        public async Task<IActionResult> Download(int id)
        {
            var image = await dbContext.Images.FindAsync(id);
            if (image is null)
            {
                return NotFound(); // return serviceResult
            }

            var memoryStream = new MemoryStream(image.Content);

            return File(memoryStream, image.ContentType);
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile file, [FromForm] string alt)
        {
            //todo: test
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    return Ok(await imageDbService.Create(new ImageDbRequest
                    {
                        Alt = alt,
                        Content = memoryStream.ToArray(),
                        ContentType = file.ContentType
                    }));
                }
            }

            //todo: add message file to big
            return ValidationProblem(ModelState);
        }



        [HttpPost("Upload")]
        public async Task<IActionResult> Upload(IFormFile file, [FromForm] ImageApiRequest properties)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded."); //return serviceresult?
            }

            var now = DateTime.UtcNow;

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    var image = new Image
                    {
                        Alt = properties.Alt,
                        Created = now,
                        Updated = now,
                        Content = memoryStream.ToArray(),
                        ContentType = file.ContentType
                    };

                    dbContext.Images.Add(image);

                    await dbContext.SaveChangesAsync();

                    return Ok(new ServiceResult<ImageResult>
                    {
                        Data = new ImageResult
                        {
                            Alt = image.Alt,
                            Created = image.Created,
                            Updated = image.Updated,
                            Id = image.Id,
                            ContentType = image.ContentType,

                            //TODO
                            ActsCount = 0,
                            ArtistsCount = 0,
                            LineupsCount = 0,
                            PeopleCount = 0,
                            PerformancesCount = 0
                        }
                    });
                }
                else
                {
                    return BadRequest("The file is too large.");  //return serviceresult?
                }
            }
        }
    }
}