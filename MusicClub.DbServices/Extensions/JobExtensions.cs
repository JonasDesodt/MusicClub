using Microsoft.EntityFrameworkCore;
using MusicClub.DbCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicClub.DbServices.Extensions
{
    internal static class JobExtensions
    {
        public static async Task<bool> HasReferenceToWorker(this DbSet<Job> jobs, int id)
        {
            return await jobs.AnyAsync(a => a.WorkerId == id);
        }

        public static async Task<bool> HasReferenceToAct(this DbSet<Job> jobs, int id)
        {
            return await jobs.AnyAsync(a => a.ActId == id);
        }
    }
}
