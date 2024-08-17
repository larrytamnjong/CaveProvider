﻿using CaveProvider.Core.Model;
using CaveProvider.Core.Model.Institution;
using CaveProvider.Database.Context.Interface;
using Microsoft.EntityFrameworkCore;


namespace CaveProvider.Database.Context
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        protected readonly IConfiguration Configuration;
        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<Institution> Institutions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        } 
    }
}
