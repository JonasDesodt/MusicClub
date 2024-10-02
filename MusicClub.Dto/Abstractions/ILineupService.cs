using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Filters.Results;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;

namespace MusicClub.Dto.Abstractions
{
    public interface ILineupService : IService<LineupRequest, LineupResult, LineupFilterRequest, LineupFilterResult> { }
}
