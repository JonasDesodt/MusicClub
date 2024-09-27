using MusicClub.Dto.Results;

namespace MusicClub.DbServices.Extensions.Band
{
    public static class BandExtensions
    {
        public static BandResult ToResult(this DbCore.Models.Band band)
        {
            return new BandResult
            {
                BandnamesCount = band.Bandnames.Count,
                Created = band.Created,
                Id = band.Id,
                Updated = band.Updated  
            };
        }
    }
}
