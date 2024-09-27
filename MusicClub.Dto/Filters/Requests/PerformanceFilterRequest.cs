namespace MusicClub.Dto.Filters.Requests
{
    public class PerformanceFilterRequest : Sort
    {
        public string? Instrument { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }

        public int? ImageId { get; set; }

        public int? ArtistId { get; set; }

        public int? ActId { get; set; }

        public int? BandnameId { get; set; }
    }
}
