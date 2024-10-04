namespace MusicClub.Api.Controllers
{
    public class ArtistController(IArtistService dbService) : ApiControllerBase<ArtistRequest, ArtistResult, ArtistFilterRequest, ArtistFilterResult>(dbService) { }
}