using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CaveProvider.Identity.API.Models
{
    public class RolePermission
    {
        [Key]
        public required string RoleId { get; set; }
        public ApplicationRole? Role { get; set; }
        public required string PermissionId { get; set; }
        public Permission? Permission { get; set; }
    }

    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(rp => new { rp.RoleId, rp.PermissionId });

            builder.HasOne(rp => rp.Role)
                .WithMany(pi => pi.RolePermissions)
                .HasForeignKey(pi => pi.RoleId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pi => pi.Permission)
                .WithMany(pi => pi.RolePermissions)
                .HasForeignKey(pi => pi.PermissionId);
        }
    }
}
