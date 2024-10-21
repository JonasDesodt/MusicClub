using MusicClub.Dto.Requests;

namespace MusicClub.Dto.Abstractions
{
    public interface IGoogleCalendarService : IService<GoogleCalendarRequest, GoogleCalendarResult, GoogleCalendarFilterRequest, GoogleCalendarFilterResult> { }
}
