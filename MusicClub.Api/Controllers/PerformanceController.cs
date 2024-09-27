using Microsoft.AspNetCore.Mvc;
using MusicClub.Dto.Attributes;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Transfer;
using MusicClub.Dto.Abstractions;

namespace MusicClub.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerformanceController(IPerformanceService performanceDbService) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PerformanceRequest performanceRequest)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await performanceDbService.Create(performanceRequest));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationRequest paginationRequest, [FromQuery] PerformanceFilterRequest filter)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await performanceDbService.GetAll(paginationRequest, filter));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([Min(1), FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await performanceDbService.Get(id));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([Min(1), FromRoute] int id, [FromBody] PerformanceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await performanceDbService.Update(id, request));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([Min(1), FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await performanceDbService.Delete(id));
        }
    }
}
