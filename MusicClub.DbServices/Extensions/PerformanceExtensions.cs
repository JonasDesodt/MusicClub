using Microsoft.EntityFrameworkCore;
using MusicClub.DbCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicClub.DbServices.Extensions
{
    internal static class PerformanceExtensions
    {
        public static async Task<bool> HasReferenceToArtist(this DbSet<Performance> performances, int id)
        {
            return await performances.AnyAsync(a => a.ArtistId == id);
        }

        public static async Task<bool> HasReferenceToAct(this DbSet<Performance> performances, int id)
        {
            return await performances.AnyAsync(a => a.ActId == id);
        }
    }
}
