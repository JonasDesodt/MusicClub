using MusicClub.Dto.Attributes;

namespace MusicClub.Dto.Filters.Requests
{
    [GenerateFilterResult]
    public class ArtistFilterRequest : Sort//, IFilterRequestConverter<ArtistFilterResult>
    {
        public string? Alias { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        [Min(1)]
        public int? ImageId { get; set; }

        //public string ToQueryString()
        //{
        //    return ArtistFilterRequestExtensions.ToQueryString(this);
        //}

        //public ArtistFilterResult ToResult()
        //{
        //    return ArtistFilterRequestExtensions.ToResult(this);
        //}
    }
}
