namespace MusicClub.Api.Controllers
{
    public class PersonController(IPersonService dbService) : ApiControllerBase<PersonRequest, PersonResult, PersonFilterRequest, PersonFilterResult>(dbService) { }
}