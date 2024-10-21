using Google.Apis.Calendar.v3.Data;
using Microsoft.EntityFrameworkCore;
using MusicClub.DbCore.Models;
using MusicClub.DbServices.Extensions.Act;
using MusicClub.DbServices.Extensions.GoogleEvent;
using MusicClub.DbServices.Extensions.Image;
using MusicClub.DbServices.Extensions.Lineup;
using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;

namespace MusicClub.DbServices.Extensions.Act
{
    internal static class ActExtensions
    {
        public static async Task<bool> HasReferenceToLineup(this DbSet<DbCore.Models.Act> acts, int id)
        {
            return await acts.AnyAsync(a => a.LineupId == id);
        }

        public static IQueryable<DbCore.Models.Act> IncludeAll(this IQueryable<DbCore.Models.Act> query)
        {
            return query.Include(x => x.Image)
                        .Include(x => x.Jobs)
                        .Include(x => x.Lineup)
                        .Include(x => x.GoogleEvent)
                        .Include(x => x.Performances);
        }

        public static IQueryable<ActResult> ToResults(this IQueryable<DbCore.Models.Act> query)
        {
            return query.Select(a => new ActResult
            {
                Description = a.Description,
                Duration = a.Duration,
                Start = a.Start,
                Name = a.Name,
                Title = a.Title,
                PerformancesCount = a.Performances.Count,
                Created = a.Created,
                Id = a.Id,
                ImageResult = a.Image != null ? a.Image.ToResult() : null,
                Updated = a.Updated,
                JobsCount = a.Jobs.Count,
                LineupResult = a.Lineup!.ToResult(), //TODO: temp hack (!), deal w/ null reference
                GoogleEventDbIdentity = a.GoogleEvent != null ? a.GoogleEvent.Id : null,
            });
        }

        public static IQueryable<DbCore.Models.Act> Filter(this IQueryable<DbCore.Models.Act> acts, ActFilterRequest filter)
        {
            //todo: description

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                acts = acts.Where(a => a.Name != null && a.Name.ToLower().Contains(filter.Name.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(filter.Title))
            {
                acts = acts.Where(a => a.Title != null && a.Title.ToLower().Contains(filter.Title.ToLower()));
            }

            if (filter.ImageId > 0)
            {
                acts = acts.Where(a => a.ImageId != null && a.ImageId == filter.ImageId);
            }

            if (filter.LineupId > 0)
            {
                acts = acts.Where(a => a.LineupId == filter.LineupId);
            }

            if (filter.Duration >= 0)
            {
                acts = acts.Where(a => a.Duration == filter.Duration);
            }

            if (filter.Start is { } start)
            {
                acts = acts.Where(a => a.Start != null && a.Start.Value.ToShortDateString().Equals(start.ToShortDateString()));
            }

            if (!string.IsNullOrWhiteSpace(filter.SortProperty))
            {
                if (filter.SortDirection is SortDirection.Descending)
                {
                    acts = filter.SortProperty switch
                    {
                        nameof(DbCore.Models.Act.Name) => acts.OrderByDescending(a => a.Name),
                        nameof(DbCore.Models.Act.Title) => acts.OrderByDescending(a => a.Title),
                        nameof(DbCore.Models.Act.Image) => acts.OrderByDescending(a => a.Image != null ? a.Image.Alt : null),
                        nameof(DbCore.Models.Act.Lineup) => acts.OrderByDescending(a => a.Lineup != null ? a.Lineup.Title : null),
                        nameof(DbCore.Models.Act.Duration) => acts.OrderByDescending(a => a.Duration),
                        nameof(DbCore.Models.Act.Start) => acts.OrderByDescending(a => a.Start),
                        nameof(DbCore.Models.Act.Jobs) => acts.OrderByDescending(a => a.Jobs.Count),
                        nameof(DbCore.Models.Act.Performances) => acts.OrderByDescending(a => a.Performances.Count),
                        nameof(DbCore.Models.Act.Created) => acts.OrderByDescending(a => a.Created),
                        nameof(DbCore.Models.Act.Updated) => acts.OrderByDescending(a => a.Updated),
                        _ => acts.OrderByDescending(a => a.Id),
                    };
                }
                else
                {
                    acts = filter.SortProperty switch
                    {
                        nameof(DbCore.Models.Act.Name) => acts.OrderBy(a => a.Name),
                        nameof(DbCore.Models.Act.Title) => acts.OrderBy(a => a.Title),
                        nameof(DbCore.Models.Act.Image) => acts.OrderBy(a => a.Image != null ? a.Image.Alt : null),
                        nameof(DbCore.Models.Act.Lineup) => acts.OrderBy(a => a.Lineup != null ? a.Lineup.Title : null),
                        nameof(DbCore.Models.Act.Duration) => acts.OrderBy(a => a.Duration),
                        nameof(DbCore.Models.Act.Start) => acts.OrderBy(a => a.Start),
                        nameof(DbCore.Models.Act.Jobs) => acts.OrderBy(a => a.Jobs.Count),
                        nameof(DbCore.Models.Act.Performances) => acts.OrderBy(a => a.Performances.Count),
                        nameof(DbCore.Models.Act.Created) => acts.OrderBy(a => a.Created),
                        nameof(DbCore.Models.Act.Updated) => acts.OrderBy(a => a.Updated),
                        _ => acts.OrderBy(a => a.Id),
                    };
                }
            }

            return acts;
        }


        public static DbCore.Models.Act Update(this DbCore.Models.Act act, ActRequest actRequest)
        {
            act.Name = actRequest.Name;
            act.Title = actRequest.Title;
            act.ImageId = actRequest.ImageId;
            act.Updated = DateTime.UtcNow;
            act.Duration = actRequest.Duration;
            act.Start = actRequest.Start;
            act.LineupId = actRequest.LineupId;
            act.Description = actRequest.Description;

            return act;
        }

        public static ActResult ToResult(this DbCore.Models.Act act)
        {
            return new ActResult
            {
                //GoogleEventResult = act.GoogleEvent != null ? act.GoogleEvent.ToResult() : null,
                Name = act.Name,
                Title = act.Title,
                Description = act.Description,
                PerformancesCount = act.Performances.Count,
                Created = act.Created,
                Id = act.Id,
                ImageResult = act.Image != null ? act.Image.ToResult() : null,
                Updated = act.Updated,
                JobsCount = act.Jobs.Count,
                LineupResult = act.Lineup!.ToResult(), //TODO: temp hack (!), deal w/ null reference
                Duration = act.Duration,
                Start = act.Start,
                GoogleEventDbIdentity = act.GoogleEvent != null ? act.GoogleEvent.Id : null
            };
        }
    }
}
