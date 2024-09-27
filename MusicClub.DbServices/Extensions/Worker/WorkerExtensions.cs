using Microsoft.EntityFrameworkCore;
using MusicClub.DbCore.Models;

namespace MusicClub.DbServices.Extensions.Worker
{
    internal static class WorkerExtensions
    {
        public static async Task<bool> HasReferenceToPerson(this DbSet<DbCore.Models.Worker> workers, int id)
        {
            return await workers.AnyAsync(a => a.PersonId == id);
        }
    }
}