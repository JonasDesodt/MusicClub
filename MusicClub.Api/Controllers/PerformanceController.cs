namespace MusicClub.Api.Controllers
{
    public class PerformanceController(IPerformanceService dbService) : ApiControllerBase<PerformanceRequest, PerformanceResult, PerformanceFilterRequest, PerformanceFilterResult>(dbService) { }
}
