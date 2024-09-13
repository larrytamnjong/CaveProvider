using CaveProvider.Core.Model.Institution;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveProvider.Database.Seed
{
    public static class TermSeed
    {
        public static void SeedTerms(this ModelBuilder builder)
        {
            List<Term> terms = [
                new Term{ Id= Guid.NewGuid(), Name = "First Term"},
                new Term {Id= Guid.NewGuid(), Name = "Second Term"},
                new Term {Id= Guid.NewGuid(), Name = "Third Term"}
            ];

            builder.Entity<Term>().HasData(terms);

        }
    }
}
