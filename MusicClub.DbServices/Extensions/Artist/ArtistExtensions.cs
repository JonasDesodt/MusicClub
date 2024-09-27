using Microsoft.EntityFrameworkCore;
using MusicClub.DbCore.Models;
using MusicClub.DbServices.Extensions;
using MusicClub.DbServices.Extensions.Artist;
using MusicClub.DbServices.Extensions.Image;
using MusicClub.DbServices.Extensions.Person;
using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;

namespace MusicClub.DbServices.Extensions.Artist
{
    internal static class ArtistExtensions
    {
        public static async Task<bool> HasReferenceToPerson(this DbSet<DbCore.Models.Artist> artists, int id)
        {
            return await artists.AnyAsync(a => a.PersonId == id);
        }

        public static IQueryable<DbCore.Models.Artist> IncludeAll(this IQueryable<DbCore.Models.Artist> query)
        {
            return query.Include(a => a.Image)
                        .Include(a => a.Person)
                        .Include(a => a.Performances);
        }

        public static IQueryable<ArtistResult> ToResults(this IQueryable<DbCore.Models.Artist> query)
        {
            return query.Select(a => new ArtistResult
            {
                Alias = a.Alias,
                PerformancesCount = a.Performances.Count,
                Created = a.Created,
                Id = a.Id,
                Image = a.Image != null ? a.Image.ToResult() : null,
                Updated = a.Updated,
                Person = a.Person != null ? a.Person.ToResult() : null
            });
        }

        public static IQueryable<DbCore.Models.Artist> Filter(this IQueryable<DbCore.Models.Artist> artists, ArtistFilterRequest filter)
        {

            if (!string.IsNullOrWhiteSpace(filter.Alias))
            {
                artists = artists.Where(a => a.Alias != null && a.Alias.ToLower().Contains(filter.Alias.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(filter.Firstname))
            {
                artists = artists.Where(a => a.Person != null && a.Person.Firstname.ToLower().Contains(filter.Firstname.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(filter.Lastname))
            {
                artists = artists.Where(a => a.Person != null && a.Person.Lastname.ToLower().Contains(filter.Lastname.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(filter.SortProperty))
            {
                if (filter.SortDirection is SortDirection.Descending)
                {
                    artists = filter.SortProperty switch
                    {
                        nameof(DbCore.Models.Artist.Alias) => artists.OrderByDescending(a => a.Alias),
                        nameof(DbCore.Models.Person.Firstname) => artists.OrderByDescending(a => a.Person != null ? a.Person.Firstname : a.Alias),
                        nameof(DbCore.Models.Person.Lastname) => artists.OrderByDescending(a => a.Person != null ? a.Person.Lastname : a.Alias),

                        _ => artists.OrderByDescending(a => a.Id),
                    };
                }
                else
                {
                    artists = filter.SortProperty switch
                    {
                        nameof(DbCore.Models.Artist.Alias) => artists.OrderBy(a => a.Alias),
                        nameof(DbCore.Models.Person.Firstname) => artists.OrderBy(a => a.Person != null ? a.Person.Firstname : a.Alias),
                        nameof(DbCore.Models.Person.Lastname) => artists.OrderBy(a => a.Person != null ? a.Person.Lastname : a.Alias),

                        _ => artists.OrderBy(a => a.Id),
                    };
                }
            }

            return artists;
        }


        public static DbCore.Models.Artist Update(this DbCore.Models.Artist artist, ArtistRequest personRequest)
        {
            artist.PersonId = personRequest.PersonId;
            artist.ImageId = personRequest.ImageId;
            artist.Updated = DateTime.UtcNow;
            artist.Alias = personRequest.Alias;

            return artist;
        }

        public static ArtistResult ToResult(this DbCore.Models.Artist artist)
        {
            return new ArtistResult
            {
                Alias = artist.Alias,
                Created = artist.Created,
                Id = artist.Id,
                Image = artist.Image?.ToResult(),
                Updated = artist.Updated,
                Person = artist.Person?.ToResult(),
                PerformancesCount = artist.Performances.Count
            };
        }
    }
}