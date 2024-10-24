﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicClub.DbCore.Models;
using System.Reflection.Emit;

namespace MusicClub.DbCore
{
    public class MusicClubDbContext(DbContextOptions<MusicClubDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Act> Acts => Set<Act>();

        public DbSet<Artist> Artists => Set<Artist>();

        public DbSet<Band> Bands => Set<Band>();

        public DbSet<Bandname> Bandnames => Set<Bandname>();

        public DbSet<GoogleCalendar> GoogleCalendars => Set<GoogleCalendar>();

        public DbSet<GoogleEvent> GoogleEvents => Set<GoogleEvent>();

        public DbSet<Function> Functions => Set<Function>();

        public DbSet<Image> Images => Set<Image>();

        public DbSet<Job> Jobs => Set<Job>();

        public DbSet<Lineup> Lineups => Set<Lineup>();

        public DbSet<Person> People => Set<Person>();

        public DbSet<Performance> Performances => Set<Performance>();

        public DbSet<Service> Services => Set<Service>();

        public DbSet<Worker> Workers => Set<Worker>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Act>()
                .HasOne(a => a.Image)
                .WithMany(i => i.Acts)
                .HasForeignKey(a => a.ImageId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            builder.Entity<Act>()
                .HasOne(a => a.Lineup)
                .WithMany(l => l.Acts)
                .HasForeignKey(a => a.LineupId)
                .IsRequired(true);

            builder.Entity<ApplicationUser>()
                .HasOne(a => a.Person)
                .WithMany(p => p.ApplicationUsers)
                .HasForeignKey(a => a.PersonId)
                .IsRequired(true);

            builder.Entity<Artist>()
                .HasOne(a => a.Image)
                .WithMany(i => i.Artists)
                .HasForeignKey(a => a.ImageId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Artist>()
                .HasOne(a => a.Person)
                .WithMany(p => p.Artists)
                .HasForeignKey(a => a.PersonId)
                .IsRequired(true);

            builder.Entity<Bandname>()
                 .HasOne(b => b.Band)
                 .WithMany(b => b.Bandnames)
                 .HasForeignKey(b => b.BandId)
                 .IsRequired(true);

            builder.Entity<GoogleEvent>()
                .HasOne(g => g.Act)
                .WithOne(a => a.GoogleEvent)
                .HasForeignKey<Act>(a => a.GoogleEventId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<GoogleEvent>()
                .HasOne(g => g.GoogleCalendar)
                .WithMany(g => g.GoogleEvents)
                .HasForeignKey(g => g.GoogleCalendarId)
                .IsRequired(true);

            builder.Entity<Job>()
                .HasOne(j => j.Worker)
                .WithMany(w => w.Jobs)
                .HasForeignKey(j => j.WorkerId)
                .IsRequired(true);

            builder.Entity<Job>()
                .HasOne(j => j.Function)
                .WithMany(f => f.Jobs)
                .HasForeignKey(j => j.FunctionId)
                .IsRequired(true);

            builder.Entity<Job>()
                .HasOne(j => j.Act)
                .WithMany(a => a.Jobs)
                .HasForeignKey(j => j.ActId)
                .IsRequired(true);

            builder.Entity<Lineup>()
                .HasOne(l => l.Image)
                .WithMany(i => i.Lineups)
                .HasForeignKey(l => l.ImageId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            builder.Entity<Performance>()
                .HasOne(p => p.Artist)
                .WithMany(a => a.Performances)
                .HasForeignKey(p => p.ArtistId)
                .IsRequired(true);

            builder.Entity<Performance>()
                .HasOne(p => p.Bandname)
                .WithMany(b => b.Performances)
                .HasForeignKey(p => p.BandnameId)
                .IsRequired(false);

            builder.Entity<Performance>()
                .HasOne(p => p.Image)
                .WithMany(i => i.Performances)
                .HasForeignKey(p => p.ImageId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            builder.Entity<Performance>()
                .HasOne(p => p.Act)
                .WithMany(a => a.Performances)
                .HasForeignKey(p => p.ActId)
                .IsRequired(true);

            builder.Entity<Service>()
                 .HasOne(s => s.Worker)
                 .WithMany(w => w.Services)
                 .HasForeignKey(s => s.WorkerId)
                 .IsRequired(true);

            builder.Entity<Service>()
                .HasOne(s => s.Function)
                .WithMany(f => f.Services)
                .HasForeignKey(s => s.FunctionId)
                .IsRequired(true);

            builder.Entity<Service>()
                .HasOne(s => s.Lineup)
                .WithMany(l => l.Services)
                .HasForeignKey(s => s.LineupId)
                .IsRequired(true);

            builder.Entity<Person>()
                .HasOne(p => p.Image)
                .WithMany(i => i.People)
                .HasForeignKey(p => p.ImageId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            builder.Entity<Worker>()
                .HasOne(w => w.Person)
                .WithMany(p => p.Workers)
                .HasForeignKey(w => w.PersonId)
                .IsRequired(true);

            base.OnModelCreating(builder);
        }
    }
}