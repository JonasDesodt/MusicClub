using MusicClub.Dto.Requests;

namespace MusicClub.Dto.Abstractions
{
    public interface IGoogleEventService : IService<GoogleEventRequest, GoogleEventResult, GoogleEventFilterRequest, GoogleEventFilterResult> { }
}
