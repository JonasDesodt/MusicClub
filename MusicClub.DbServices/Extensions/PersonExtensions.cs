using Microsoft.EntityFrameworkCore;
using MusicClub.DbCore.Models;
using MusicClub.Dto.Enums;
using MusicClub.Dto.Filters;
using MusicClub.Dto.Filters.Requests;
using MusicClub.Dto.Requests;
using MusicClub.Dto.Results;

namespace MusicClub.DbServices.Extensions
{
    internal static class PersonExtensions
    {
        public static PersonResult ToResult(this Person person)
        {
            return new PersonResult
            {
                ApplicationUsersCount = person.ApplicationUsers.Count,
                ArtistsCount = person.Artists.Count,
                Created = person.Created,
                Firstname = person.Firstname,
                Id = person.Id,
                Image = person.Image?.ToResult(),
                Lastname = person.Lastname,
                Updated = person.Updated,
                WorkersCount = person.Workers.Count,
            };
        }

        public static IQueryable<PersonResult> ToResults(this IQueryable<Person> query)
        {
            return query.Select(p => new PersonResult
            {
                ApplicationUsersCount = p.ApplicationUsers.Count,
                ArtistsCount = p.Artists.Count,
                Created = p.Created,
                Firstname = p.Firstname,
                Id = p.Id,
                Image = p.Image != null ? p.Image.ToResult() : null,
                Lastname = p.Lastname,
                Updated = p.Updated,
                WorkersCount = p.Workers.Count,
            });              
        }

        public static IQueryable<Person> IncludeAll(this IQueryable<Person> query)
        {
            return query.Include(p => p.Image)
                        .Include(p => p.ApplicationUsers)
                        .Include(p => p.Artists)
                        .Include(p => p.Workers);
        }

        public static Person Update(this Person person, PersonRequest personRequest)
        {
            person.Firstname = personRequest.Firstname;
            person.Lastname = personRequest.Lastname;
            person.ImageId = personRequest.ImageId;
            person.Updated = DateTime.UtcNow;

            return person;
        }

        public static IQueryable<Person> Filter(this IQueryable<Person> people, PersonFilterRequest filter)
        {
            if (!string.IsNullOrWhiteSpace(filter.Firstname))
            {
                people = people.Where(a => a.Firstname != null && a.Firstname.ToLower().Contains(filter.Firstname.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(filter.Lastname))
            {
                people = people.Where(a => a.Lastname != null && a.Lastname.ToLower().Contains(filter.Lastname.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(filter.SortProperty))
            {
                if (filter.SortDirection is SortDirection.Descending)
                {
                    people = filter.SortProperty switch
                    {
                        nameof(PersonResult.Firstname) => people.OrderByDescending(a => a.Firstname),
                        nameof(PersonResult.Lastname) => people.OrderByDescending(a => a.Lastname),
                        _ => people.OrderByDescending(a => a.Id),
                    };
                }
                else
                {
                    people = filter.SortProperty switch
                    {
                        nameof(PersonResult.Firstname) => people.OrderBy(a => a.Firstname),
                        nameof(PersonResult.Lastname) => people.OrderBy(a => a.Lastname),
                        _ => people.OrderBy(a => a.Id),
                    };
                }
            }

            return people;
        }
    }  
}