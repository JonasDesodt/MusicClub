using MusicClub.Dto.Results;
using MusicClub.DbServices.Extensions.Band;
using Microsoft.EntityFrameworkCore;
using MusicClub.DbServices.Extensions.Image;

namespace MusicClub.DbServices.Extensions.Bandname
{
    public static class BandnameExtensions
    {
        public static BandnameResult ToResult(this DbCore.Models.Bandname bandname)
        {
            return new BandnameResult
            {
                BandResult = bandname.Band!.ToResult(), // todo: deal w/ null reference, temp hack
                Created = bandname.Created,
                Id = bandname.Id,
                Name = bandname.Name,
                PerformancesCount = bandname.Performances.Count,
                Updated = bandname.Updated
            };
        }

        public static IQueryable<DbCore.Models.Bandname> IncludeAll(this IQueryable<DbCore.Models.Bandname> query)
        {
            return query.Include(q => q.Band)
                        .Include(q => q.Image)
                        .Include(q => q.Performances);
        }

        public static IQueryable<BandnameResult> ToResults(this IQueryable<DbCore.Models.Bandname> query)
        {
            return query.Select(a => new BandnameResult
            {
                BandResult = a.Band!.ToResult(),// todo: deal with null reference
                Created = a.Created,
                Id = a.Id,
                ImageResult = a.Image != null ? a.Image.ToResult() : null,
                Name = a.Name,
                PerformancesCount = a.Performances.Count,
                Updated = a.Updated              
            });
        }
    }
}
