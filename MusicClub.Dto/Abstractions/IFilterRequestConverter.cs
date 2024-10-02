namespace MusicClub.Dto.Abstractions
{
    public interface IFilterRequestConverter<TFilterResult>
    {
        TFilterResult ToResult();

        string ToQueryString();
    }
}
