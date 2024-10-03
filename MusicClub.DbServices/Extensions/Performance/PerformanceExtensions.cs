using Microsoft.EntityFrameworkCore;
using MusicClub.DbServices.Extensions.Image;
using MusicClub.DbServices.Extensions.Artist;
using MusicClub.DbServices.Extensions.Act;
using MusicClub.DbServices.Extensions.Bandname;
using MusicClub.Dto.Results;
using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Requests;

namespace MusicClub.DbServices.Extensions.Performance
{
    internal static class PerformanceExtensions
    {
        public static async Task<bool> HasReferenceToArtist(this DbSet<DbCore.Models.Performance> performances, int id)
        {
            return await performances.AnyAsync(a => a.ArtistId == id);
        }

        public static async Task<bool> HasReferenceToAct(this DbSet<DbCore.Models.Performance> performances, int id)
        {
            return await performances.AnyAsync(a => a.ActId == id);
        }

        public static IQueryable<DbCore.Models.Performance> IncludeAll(this IQueryable<DbCore.Models.Performance> query)
        {
            return query.Include(p => p.Image)
                        .Include(p => p.Artist).ThenInclude(a => a != null ? a.Person: null)
                        .Include(p => p.Bandname)
                        .Include(p => p.Act).ThenInclude(a => a != null ? a.Lineup : null);
        }

        public static IQueryable<PerformanceResult> ToResults(this IQueryable<DbCore.Models.Performance> query)
        {
            return query.Select(p => new PerformanceResult
            {
                Created = p.Created,
                Id = p.Id,
                ImageResult = p.Image != null ? p.Image.ToResult() : null,
                Updated = p.Updated,
                Instrument = p.Instrument,
                BandnameResult = p.Bandname != null ? p.Bandname.ToResult() : null,
                ActResult = p.Act!.ToResult(), //todo: temp hack, deal with null reference    
                ArtistResult = p.Artist!.ToResult()  //todo: temp hack, deal with null reference    
            });
        }

        public static IQueryable<DbCore.Models.Performance> Filter(this IQueryable<DbCore.Models.Performance> query, PerformanceFilterRequest filter)
        {
            if (!string.IsNullOrWhiteSpace(filter.Instrument))
            {
                query = query.Where(a => a.Instrument != null && a.Instrument.ToLower().Contains(filter.Instrument.ToLower()));
            }

            if (filter.ImageId > 0)
            {
                query = query.Where(a => a.ImageId != null && a.ImageId == filter.ImageId);
            }

            if (filter.ArtistId > 0)
            {
                query = query.Where(a => a.ArtistId == filter.ArtistId);
            }

            if (filter.BandnameId > 0)
            {
                query = query.Where(a => a.BandnameId != null && a.BandnameId == filter.BandnameId);
            }

            if (filter.ActId > 0)
            {
                query = query.Where(a => a.ActId == filter.ActId);
            }

            if (!string.IsNullOrWhiteSpace(filter.SortProperty))
            {
                if (filter.SortDirection is SortDirection.Descending)
                {
                    query = filter.SortProperty switch
                    {
                        nameof(DbCore.Models.Performance.Instrument) => query.OrderByDescending(l => l.Instrument),
                        nameof(DbCore.Models.Performance.Image) => query.OrderByDescending(l => l.Image != null ? l.Image.Alt : null),
                        nameof(DbCore.Models.Performance.Created) => query.OrderByDescending(l => l.Created),
                        nameof(DbCore.Models.Performance.Updated) => query.OrderByDescending(l => l.Updated),
                        nameof(DbCore.Models.Performance.Act) => query.OrderByDescending(l => l.ActId),
                        nameof(DbCore.Models.Performance.Artist) => query.OrderByDescending(l => l.Artist),
                        nameof(DbCore.Models.Performance.Bandname) => query.OrderByDescending(l => l.Bandname != null ? l.Bandname.Name : null),
                        _ => query.OrderByDescending(l => l.Id),
                    };
                }
                else
                {
                    query = filter.SortProperty switch
                    {
                        nameof(DbCore.Models.Performance.Instrument) => query.OrderBy(l => l.Instrument),
                        nameof(DbCore.Models.Performance.Image) => query.OrderBy(l => l.Image != null ? l.Image.Alt : null),
                        nameof(DbCore.Models.Performance.Created) => query.OrderBy(l => l.Created),
                        nameof(DbCore.Models.Performance.Updated) => query.OrderBy(l => l.Updated),
                        nameof(DbCore.Models.Performance.Act) => query.OrderBy(l => l.ActId),
                        nameof(DbCore.Models.Performance.Artist) => query.OrderBy(l => l.Artist),
                        nameof(DbCore.Models.Performance.Bandname) => query.OrderBy(l => l.Bandname != null ? l.Bandname.Name : null),
                        _ => query.OrderBy(l => l.Id),
                    };
                }
            }

            return query;
        }

        public static DbCore.Models.Performance Update(this DbCore.Models.Performance performance, PerformanceRequest request)
        {
            performance.ImageId = request.ImageId;
            performance.Updated = DateTime.UtcNow;
            performance.ActId = request.ActId;
            performance.ArtistId = request.ArtistId;
            performance.ActId = request.ActId;
            performance.BandnameId = request.BandnameId;
            performance.Instrument = request.Instrument;

            return performance;
        }

        public static PerformanceResult ToResult(this DbCore.Models.Performance performance)
        {
            return new PerformanceResult
            {
                Created = performance.Created,
                Id = performance.Id,
                ImageResult = performance.Image != null ? performance.Image.ToResult() : null,
                Updated = performance.Updated,
                Instrument = performance.Instrument,
                BandnameResult = performance.Bandname != null ? performance.Bandname.ToResult() : null,
                ActResult = performance.Act!.ToResult(), //todo: temp hack, deal with null reference    
                ArtistResult = performance.Artist!.ToResult()  //todo: temp hack, deal with null reference    
            };
        }
    }
}