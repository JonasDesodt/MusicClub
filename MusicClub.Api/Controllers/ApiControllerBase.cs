using Microsoft.AspNetCore.Mvc;
using MusicClub.Dto.Attributes;
using MusicClub.Dto.Transfer;

namespace MusicClub.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiControllerBase<TDataRequest, TDataResult, TFilterRequest, TFilterResult>(IService<TDataRequest, TDataResult, TFilterRequest, TFilterResult> dbService) : Controller
    {
        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] TDataRequest actRequest)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await dbService.Create(actRequest));
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll([FromQuery] PaginationRequest paginationRequest, [FromQuery] TFilterRequest filter)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await dbService.GetAll(paginationRequest, filter));
        }

        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> Get([Min(1), FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await dbService.Get(id));
        }

        [HttpPut("{id:int}")]
        public virtual async Task<IActionResult> Update([Min(1), FromRoute] int id, [FromBody] TDataRequest personRequest)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await dbService.Update(id, personRequest));
        }

        [HttpDelete("{id:int}")]
        public virtual async Task<IActionResult> Delete([Min(1), FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await dbService.Delete(id));
        }
    }
}
