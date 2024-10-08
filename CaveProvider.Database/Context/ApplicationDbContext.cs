﻿using CaveProvider.Core.Model;
using CaveProvider.Core.Model.Institution;
using CaveProvider.Database.Context.Interface;
using CaveProvider.Database.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace CaveProvider.Database.Context
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        protected readonly IConfiguration Configuration;
        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #region Institution
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Institution> Institution { get; set; }
        public DbSet<Term> Terms { get; set; }
        #endregion

        #region Section
        public DbSet<Section> Sections { get; set; }
        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedTerms();
        } 
    }
}
