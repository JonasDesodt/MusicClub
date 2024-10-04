namespace MusicClub.Api.Controllers
{
    public class LineupController(ILineupService dbService) : ApiControllerBase<LineupRequest, LineupResult, LineupFilterRequest, LineupFilterResult>(dbService) { }
}
