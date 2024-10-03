using Microsoft.EntityFrameworkCore;
using MusicClub.DbCore.Models;
using MusicClub.DbServices.Extensions;
using MusicClub.DbServices.Extensions.Image;
using MusicClub.DbServices.Extensions.Lineup;
using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;

namespace MusicClub.DbServices.Extensions.Lineup
{
    internal static class LineupExtensions
    {
        public static LineupResult ToResult(this DbCore.Models.Lineup lineup)
        {
            return new LineupResult
            {
                ActsCount = lineup.Acts.Count,
                Created = lineup.Created,
                Doors = lineup.Doors,
                Id = lineup.Id,
                ServicesCount = lineup.Services.Count,
                Updated = lineup.Updated,
                Title = lineup.Title,
                ImageResult = lineup.Image?.ToResult()
            };
        }

        public static IQueryable<DbCore.Models.Lineup> IncludeAll(this IQueryable<DbCore.Models.Lineup> query)
        {
            return query.Include(a => a.Image)
                        .Include(a => a.Services)
                        .Include(a => a.Acts);
        }

        public static IQueryable<LineupResult> ToResults(this IQueryable<DbCore.Models.Lineup> query)
        {
            return query.Select(a => new LineupResult
            {
                ActsCount = a.Acts.Count,
                Created = a.Created,
                Doors = a.Doors,
                Id = a.Id,
                ServicesCount = a.Services.Count,
                Updated = a.Updated,
                Title = a.Title,
                ImageResult = a.Image != null ? a.Image.ToResult() : null
            });
        }

        public static IQueryable<DbCore.Models.Lineup> Filter(this IQueryable<DbCore.Models.Lineup> lineups, LineupFilterRequest filter)
        {


            if (!string.IsNullOrWhiteSpace(filter.Title))
            {
                lineups = lineups.Where(a => a.Title != null && a.Title.ToLower().Contains(filter.Title.ToLower()));
            }

            if (filter.ImageId > 0)
            {
                lineups = lineups.Where(a => a.ImageId != null && a.ImageId == filter.ImageId);
            }

            if (filter.Doors is { } doors)
            {
                lineups = lineups.Where(a => a.Doors.ToShortDateString().Equals(doors.ToShortDateString()));
            }

            if (!string.IsNullOrWhiteSpace(filter.SortProperty))
            {
                if (filter.SortDirection is SortDirection.Descending)
                {
                    lineups = filter.SortProperty switch
                    {
                        nameof(DbCore.Models.Lineup.Title) => lineups.OrderByDescending(l => l.Title),
                        nameof(DbCore.Models.Lineup.Image) => lineups.OrderByDescending(l => l.Image != null ? l.Image.Alt : null),
                        nameof(DbCore.Models.Lineup.Doors) => lineups.OrderByDescending(l => l.Doors),
                        nameof(DbCore.Models.Lineup.Created) => lineups.OrderByDescending(l => l.Created),
                        nameof(DbCore.Models.Lineup.Updated) => lineups.OrderByDescending(l => l.Updated),
                        nameof(DbCore.Models.Lineup.Services) => lineups.OrderByDescending(l => l.Services.Count),
                        nameof(DbCore.Models.Lineup.Acts) => lineups.OrderByDescending(l => l.Acts.Count),
                        _ => lineups.OrderByDescending(l => l.Id),
                    };
                }
                else
                {
                    lineups = filter.SortProperty switch
                    {
                        nameof(DbCore.Models.Lineup.Title) => lineups.OrderBy(l => l.Title),
                        nameof(DbCore.Models.Lineup.Image) => lineups.OrderBy(l => l.Image != null ? l.Image.Alt : null),
                        nameof(DbCore.Models.Lineup.Doors) => lineups.OrderBy(l => l.Doors),
                        nameof(DbCore.Models.Lineup.Created) => lineups.OrderBy(l => l.Created),
                        nameof(DbCore.Models.Lineup.Updated) => lineups.OrderBy(l => l.Updated),
                        nameof(DbCore.Models.Lineup.Services) => lineups.OrderBy(l => l.Services.Count),
                        nameof(DbCore.Models.Lineup.Acts) => lineups.OrderBy(l => l.Acts.Count),
                        _ => lineups.OrderBy(l => l.Id),
                    };
                }
            }

            return lineups;
        }

        public static DbCore.Models.Lineup Update(this DbCore.Models.Lineup lineup, LineupRequest request)
        {
            lineup.ImageId = request.ImageId;
            lineup.Updated = DateTime.UtcNow;
            lineup.Title = request.Title;
            lineup.Doors = request.Doors;

            return lineup;
        }
    }
}
