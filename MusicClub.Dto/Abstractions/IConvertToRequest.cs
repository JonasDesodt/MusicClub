namespace MusicClub.Dto.Abstractions
{
    public interface IConvertToRequest<TFilterRequest>
    {
        TFilterRequest ToRequest();
    }
}
