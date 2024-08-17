using CaveProvider.Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CaveProvider.Identity.API.Database.Seed
{
    public static class RolesPermissionsSeed
    {
        public static void SeedRolesAndPermissions(this ModelBuilder builder)
        {

            List<ApplicationRole> roles = [
                 new ApplicationRole(){ Id = "18a637be-385b-4f39-a977-c393e480afd2", Name = "Courses", NormalizedName = "COURSES", ConcurrencyStamp = Guid.NewGuid().ToString()},
                 new ApplicationRole(){ Id = "37380474-d6ab-44ea-8cbc-fe0d090b7b03", Name = "Results", NormalizedName = "RESULTS",  ConcurrencyStamp = Guid.NewGuid().ToString()},
                 new ApplicationRole(){ Id = "4287a436-13a3-40df-9e13-9ad9c54f7bc8", Name = "Staff", NormalizedName = "STAFF",  ConcurrencyStamp = Guid.NewGuid().ToString()},
                 new ApplicationRole(){ Id = "8adbef6f-b84c-4771-b64f-cc81c17d1ac7", Name = "Settings", NormalizedName = "SETTINGS",  ConcurrencyStamp = Guid.NewGuid().ToString()},
                 new ApplicationRole(){ Id = "bffab8fc-a865-44dd-ba51-49d6846ca04b", Name = "ReportCards", NormalizedName = "REPORT CARDS",  ConcurrencyStamp = Guid.NewGuid().ToString()},
                 new ApplicationRole(){ Id = "d07ef0df-1912-4b7a-b9f4-d779e4726cc0", Name = "Transcript", NormalizedName = "TRANSCRIPTS",  ConcurrencyStamp = Guid.NewGuid().ToString()},
                 new ApplicationRole(){ Id = "35a01d51-ac51-4b4f-80dc-da5807718fc3", Name = "Super Administrator", NormalizedName = "SUPER ADMINISTRATOR",  ConcurrencyStamp = Guid.NewGuid().ToString()},
                 new ApplicationRole(){ Id = "fd3ceefc-76e6-4064-97b1-867303d57d86", Name = "Classes", NormalizedName = "CLASSES",  ConcurrencyStamp = Guid.NewGuid().ToString()},
                ];

            List<Permission> permissions = [
                 new Permission(){ Id = "27c61786-ca12-4282-9225-f96f90137cfc",  Name = "SeeCourses", ParentId = null, Level = 1},
                 new Permission(){ Id = "4d50a5a5-e0d6-4582-8bb9-3092fadfe5b5",  Name = "SeeResults", ParentId = null, Level = 1},
                 new Permission(){ Id = "568c6baf-8c01-4902-8abd-8263c3e39189",  Name = "SeeStaff", ParentId = null, Level = 1},
                 new Permission(){ Id = "60001453-8550-4a93-aba7-132e84e486c1",  Name = "SeeSettings", ParentId = null,  Level = 1},
                 new Permission(){ Id = "8ae18dd3-4b36-477b-80cb-e4e73f667778",  Name = "SeeReportCards", ParentId = null, Level = 1},
                 new Permission(){ Id = "e9565838-3626-4762-acf5-699132abf303",  Name = "SeeTranscript", ParentId = null, Level = 1},
                 new Permission(){ Id = "8ebfe355-40e4-4d91-a431-095a0bd10aeb",  Name = "seeClasses", ParentId = null, Level = 1},
               ];


            List<RolePermission> rolePermissions = [
                //Courses
                new RolePermission(){PermissionId = "27c61786-ca12-4282-9225-f96f90137cfc", RoleId = "18a637be-385b-4f39-a977-c393e480afd2"},
                //Results
                new RolePermission(){PermissionId = "4d50a5a5-e0d6-4582-8bb9-3092fadfe5b5", RoleId = "37380474-d6ab-44ea-8cbc-fe0d090b7b03"},
                //Staff
                new RolePermission(){PermissionId = "568c6baf-8c01-4902-8abd-8263c3e39189", RoleId= "4287a436-13a3-40df-9e13-9ad9c54f7bc8"},
                //Settings
                new RolePermission(){PermissionId = "60001453-8550-4a93-aba7-132e84e486c1", RoleId = "8adbef6f-b84c-4771-b64f-cc81c17d1ac7"},
                //Report Cards
                new RolePermission(){PermissionId = "8ae18dd3-4b36-477b-80cb-e4e73f667778", RoleId= "bffab8fc-a865-44dd-ba51-49d6846ca04b"},
                //Transcripts
                new RolePermission(){PermissionId = "e9565838-3626-4762-acf5-699132abf303", RoleId= "d07ef0df-1912-4b7a-b9f4-d779e4726cc0"},
                //Classes
                new RolePermission(){PermissionId = "8ebfe355-40e4-4d91-a431-095a0bd10aeb", RoleId = "fd3ceefc-76e6-4064-97b1-867303d57d86"},

                //Super Administrator
                new RolePermission(){PermissionId = "27c61786-ca12-4282-9225-f96f90137cfc", RoleId = "35a01d51-ac51-4b4f-80dc-da5807718fc3"},
                new RolePermission(){PermissionId = "4d50a5a5-e0d6-4582-8bb9-3092fadfe5b5", RoleId = "35a01d51-ac51-4b4f-80dc-da5807718fc3"},
                new RolePermission(){PermissionId = "568c6baf-8c01-4902-8abd-8263c3e39189", RoleId= "35a01d51-ac51-4b4f-80dc-da5807718fc3"},
                new RolePermission(){PermissionId = "60001453-8550-4a93-aba7-132e84e486c1", RoleId = "35a01d51-ac51-4b4f-80dc-da5807718fc3"},
                new RolePermission(){PermissionId = "8ae18dd3-4b36-477b-80cb-e4e73f667778", RoleId= "35a01d51-ac51-4b4f-80dc-da5807718fc3"},
                new RolePermission(){PermissionId = "e9565838-3626-4762-acf5-699132abf303", RoleId= "35a01d51-ac51-4b4f-80dc-da5807718fc3"},
                new RolePermission(){PermissionId = "8ebfe355-40e4-4d91-a431-095a0bd10aeb", RoleId = "35a01d51-ac51-4b4f-80dc-da5807718fc3"},

                ];

            builder.Entity<ApplicationRole>().HasData(roles);
            builder.Entity<Permission>().HasData(permissions);
            builder.Entity<RolePermission>().HasData(rolePermissions);
        }
    }
}
