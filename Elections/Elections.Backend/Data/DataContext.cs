﻿using Elections.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Elections.Backend.Data
{
    public class DataContext : IdentityDbContext<User>  
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
            
        }

        public DbSet<ElectoralJourney> ElectoralJourneys { get; set; }

        public DbSet<ElectoralPosition> ElectoralPositions { get; set; }
        public DbSet<VotingStation> VotingStations { get; set; }
        public DbSet<Zoning> Zonings { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }

        public DbSet<User> Users { get; set; }         
        public DbSet<IdentificationType> IdentificationTypes { get; set; }

        public DbSet<ElectoralCandidate> ElectoralCandidate { get; set; }

        public DbSet<Vote> Votes { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ElectoralJourney>().HasIndex(x => x.Date).IsUnique();
            modelBuilder.Entity<ElectoralPosition>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex(s => new { s.CountryId, s.Name }).IsUnique();
            modelBuilder.Entity<City>().HasIndex(c => new { c.StateId, c.Name }).IsUnique();

            //modelBuilder.Entity<VotingStation>().HasIndex(x => new { x.CityId, x.Name }).IsUnique();
            modelBuilder.Entity<VotingStation>().HasIndex(x => new { x.Name, x.Code }).IsUnique();
            modelBuilder.Entity<Zoning>().HasIndex(x => new { x.VotingStationId, x.ZoningNumber }).IsUnique();
            modelBuilder.Entity<ElectoralCandidate>().HasKey(x => new { x.ElectoralJourneyId, x.Document });
            modelBuilder.Entity<ElectoralCandidate>().HasIndex(x => new { x.ElectoralJourneyId, x.Document }).IsUnique();
            modelBuilder.Entity<User>().HasKey(x => new { x.Document});
            //modelBuilder.Entity<Vote>().HasIndex(x => new { x.VotingStationId, x.UserDocument, x.ElectoralJourneyId,x.ElectoralCandidateId }).IsUnique();
            modelBuilder.Entity<Vote>().HasKey(x => new { x.UserDocument, x.ElectoralPositionId,x.ElectoralJourneyId }); //A VOTER CAN ONLY VOTE FOR ONE POSITION ON ONE ELECTION JOURNEY

            DisableCascadingDelete(modelBuilder);
        }
        private void DisableCascadingDelete(ModelBuilder modelBuilder)
        {
            var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
            foreach (var relationship in relationships)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }

}

