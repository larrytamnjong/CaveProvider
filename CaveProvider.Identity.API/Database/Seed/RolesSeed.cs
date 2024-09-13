using CaveProvider.Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CaveProvider.Identity.API.Database.Seed
{
    public static class RolesSeed
    {
        public static void SeedRoles(this ModelBuilder builder)
        {

            List<ApplicationRole> roles = [
                 new ApplicationRole(){ Id = "18a637be-385b-4f39-a977-c393e480afd2", Name = "Institution Setup", NormalizedName = "INSTITUTION SETUP", ConcurrencyStamp = Guid.NewGuid().ToString()},
                 new ApplicationRole(){ Id = "37380474-d6ab-44ea-8cbc-fe0d090b7b03", Name = "Result", NormalizedName = "RESULT",  ConcurrencyStamp = Guid.NewGuid().ToString()},
                 new ApplicationRole(){ Id = "4287a436-13a3-40df-9e13-9ad9c54f7bc8", Name = "Staff", NormalizedName = "STAFF",  ConcurrencyStamp = Guid.NewGuid().ToString()},
                 new ApplicationRole(){ Id = "8adbef6f-b84c-4771-b64f-cc81c17d1ac7", Name = "Settings", NormalizedName = "SETTINGS",  ConcurrencyStamp = Guid.NewGuid().ToString()},
                 new ApplicationRole(){ Id = "bffab8fc-a865-44dd-ba51-49d6846ca04b", Name = "Report Card", NormalizedName = "REPORT CARD",  ConcurrencyStamp = Guid.NewGuid().ToString()},
                 new ApplicationRole(){ Id = "d07ef0df-1912-4b7a-b9f4-d779e4726cc0", Name = "Transcript", NormalizedName = "TRANSCRIPT",  ConcurrencyStamp = Guid.NewGuid().ToString()},
                 new ApplicationRole(){ Id = "fd3ceefc-76e6-4064-97b1-867303d57d86", Name = "Student", NormalizedName = "STUDENT",  ConcurrencyStamp = Guid.NewGuid().ToString()},
                 new ApplicationRole(){ Id = "35a01d51-ac51-4b4f-80dc-da5807718fc3", Name = "Guest", NormalizedName = "GUEST",  ConcurrencyStamp = Guid.NewGuid().ToString()},
                 new ApplicationRole(){ Id = "61ce20d4-fca3-45e6-8941-3177988e8f48", Name = "Accounting", NormalizedName = "ACCOUNTING",  ConcurrencyStamp = Guid.NewGuid().ToString()},
                 new ApplicationRole(){ Id = "10198cac-f030-4f4e-9bfd-6e9752cb389f", Name = "Bursary", NormalizedName = "BURSARY",  ConcurrencyStamp = Guid.NewGuid().ToString()},
                ];


            builder.Entity<ApplicationRole>().HasData(roles);

        }
    }
}
