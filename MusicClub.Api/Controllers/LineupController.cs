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
    public class LineupController(ILineupService lineupDbService) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LineupRequest lineupRequest)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await lineupDbService.Create(lineupRequest));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationRequest paginationRequest, [FromQuery] LineupFilter filter)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await lineupDbService.GetAll(paginationRequest, filter));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([Min(1), FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await lineupDbService.Get(id));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([Min(1), FromRoute] int id, [FromBody] LineupRequest request)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await lineupDbService.Update(id, request));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([Min(1), FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await lineupDbService.Delete(id));
        }
    }
}
