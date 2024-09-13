using MusicClub.Dto.Filters;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;

namespace MusicClub.Dto.Abstractions
{
    public interface IArtistService : IService<ArtistRequest, ArtistResult, ArtistFilter> { }
}