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
    public class ActController(IActService actDbService) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ActRequest actRequest)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await actDbService.Create(actRequest));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationRequest paginationRequest, [FromQuery] ActFilter filter)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await actDbService.GetAll(paginationRequest, filter));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([Min(1), FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await actDbService.Get(id));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([Min(1), FromRoute] int id, [FromBody] ActRequest personRequest)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await actDbService.Update(id, personRequest));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([Min(1), FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await actDbService.Delete(id));
        }
    }
}