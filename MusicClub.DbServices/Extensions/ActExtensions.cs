using Microsoft.EntityFrameworkCore;
using MusicClub.DbCore.Models;
using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;

namespace MusicClub.DbServices.Extensions
{
    internal static class ActExtensions
    {
        public static async Task<bool> HasReferenceToLineup(this DbSet<Act> acts, int id)
        {
            return await acts.AnyAsync(a => a.LineupId == id);
        }

        public static IQueryable<Act> IncludeAll(this IQueryable<Act> query)
        {
            return query.Include(a => a.Image)
                        .Include(a => a.Jobs)
                        .Include(a => a.Lineup)
                        .Include(a => a.Performances);
        }

        public static IQueryable<ActResult> ToResults(this IQueryable<Act> query)
        {
            return query.Select(a => new ActResult
            {
                Duration = a.Duration,
                Start = a.Start,
                Name = a.Name,
                Title = a.Title,
                PerformancesCount = a.Performances.Count,
                Created = a.Created,
                Id = a.Id,
                Image = a.Image != null ? a.Image.ToResult() : null,
                Updated = a.Updated,
                JobsCount = a.Jobs.Count,
                Lineup = a.Lineup!.ToResult() //TODO: temp hack (!), deal w/ null reference
            });
        }

        public static IQueryable<Act> Filter(this IQueryable<Act> acts, ActFilterRequest filter)
        {

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

            if(filter.Duration >= 0)
            {
                acts = acts.Where(a => a.Duration == filter.Duration);
            }

            if(filter.Start is { } start)
            {
                acts = acts.Where(a => a.Start != null && a.Start.Value.ToShortDateString().Equals(start.ToShortDateString()));
            }

            if (!string.IsNullOrWhiteSpace(filter.SortProperty))
            {
                if (filter.SortDirection is SortDirection.Descending)
                {
                    acts = filter.SortProperty switch
                    {
                        nameof(Act.Name) => acts.OrderByDescending(a => a.Name),
                        nameof(Act.Title) => acts.OrderByDescending(a => a.Title),
                        nameof(Act.Image) => acts.OrderByDescending(a => a.Image != null ? a.Image.Alt : null),
                        nameof(Act.Lineup) => acts.OrderByDescending(a => a.Lineup != null ? a.Lineup.Title : null),
                        nameof(Act.Duration) => acts.OrderByDescending(a => a.Duration),
                        nameof(Act.Start) => acts.OrderByDescending(a => a.Start),
                        nameof(Act.Jobs) => acts.OrderByDescending(a => a.Jobs.Count),
                        nameof(Act.Performances) => acts.OrderByDescending(a => a.Performances.Count),
                        nameof(Act.Created) => acts.OrderByDescending(a => a.Created),
                        nameof(Act.Updated) => acts.OrderByDescending(a => a.Updated),
                        _ => acts.OrderByDescending(a => a.Id),
                    };
                }
                else
                {
                    acts = filter.SortProperty switch
                    {
                        nameof(Act.Name) => acts.OrderBy(a => a.Name),
                        nameof(Act.Title) => acts.OrderBy(a => a.Title),
                        nameof(Act.Image) => acts.OrderBy(a => a.Image != null ? a.Image.Alt : null),
                        nameof(Act.Lineup) => acts.OrderBy(a => a.Lineup != null ? a.Lineup.Title : null),
                        nameof(Act.Duration) => acts.OrderBy(a => a.Duration),
                        nameof(Act.Start) => acts.OrderBy(a => a.Start),
                        nameof(Act.Jobs) => acts.OrderBy(a => a.Jobs.Count),
                        nameof(Act.Performances) => acts.OrderBy(a => a.Performances.Count),
                        nameof(Act.Created) => acts.OrderBy(a => a.Created),
                        nameof(Act.Updated) => acts.OrderBy(a => a.Updated),
                        _ => acts.OrderBy(a => a.Id),
                    };
                }
            }

            return acts;
        }


        public static Act Update(this Act act, ActRequest personRequest)
        {
            act.Name = personRequest.Name;
            act.Title = personRequest.Title;
            act.ImageId = personRequest.ImageId;
            act.Updated = DateTime.UtcNow;
            act.Duration = personRequest.Duration;
            act.Start = personRequest.Start;
            act.LineupId = personRequest.LineupId;  
            
            return act;
        }

        public static ActResult ToResult(this Act act)
        {
            return new ActResult
            {
                Name = act.Name,
                Title = act.Title,
                PerformancesCount = act.Performances.Count,
                Created = act.Created,
                Id = act.Id,
                Image = act.Image != null ? act.Image.ToResult() : null,
                Updated = act.Updated,
                JobsCount = act.Jobs.Count,
                Lineup = act.Lineup!.ToResult() //TODO: temp hack (!), deal w/ null reference
            };
        }
    }
}
