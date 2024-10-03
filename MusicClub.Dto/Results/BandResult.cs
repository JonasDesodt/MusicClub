namespace MusicClub.Dto.Results
{
    public partial class BandResult
    {
        public required int Id { get; set; }


        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }


        public required int BandnamesCount { get; set; }
    }
}