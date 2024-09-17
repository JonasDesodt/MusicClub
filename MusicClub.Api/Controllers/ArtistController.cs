using Microsoft.AspNetCore.Mvc;
using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Attributes;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Transfer;

namespace MusicClub.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController(IArtistService artistDbService) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArtistRequest artistRequest)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await artistDbService.Create(artistRequest));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationRequest paginationRequest, [FromQuery] ArtistFilter filter)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await artistDbService.GetAll(paginationRequest, filter));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([Min(1), FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await artistDbService.Get(id));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([Min(1), FromRoute] int id, [FromBody] ArtistRequest personRequest)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await artistDbService.Update(id, personRequest));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([Min(1), FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await artistDbService.Delete(id));
        }
    }
}