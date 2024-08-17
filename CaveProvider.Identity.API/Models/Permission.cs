using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CaveProvider.Identity.API.Models
{
    public class Permission
    {
        [Key]
        public required string Id { get; set; }
        public int Level { get; set; }
        public required string Name { get; set; }
        public  string? ParentId { get; set; }
        public Permission? Parent { get; set; }
        public List<Permission>? Children { get; set; }
        public List<RolePermission>? RolePermissions { get; set; }
    }

    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasIndex(permission => permission.Name).IsUnique();

            builder.HasOne(a => a.Parent)
                .WithMany(a => a.Children)
                .HasForeignKey(a => a.ParentId);
        }
    }
}
