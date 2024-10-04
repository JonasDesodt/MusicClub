namespace MusicClub.Api.Controllers
{
    public class ActController(IActService dbService) : ApiControllerBase<ActRequest, ActResult, ActFilterRequest, ActFilterResult>(dbService) { }
}