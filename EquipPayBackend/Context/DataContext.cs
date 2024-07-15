using EquipPayBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace EquipPayBackend.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>()
                .HasOne(ua => ua.UserInfo)
                .WithOne(ui => ui.UserAccount)
                .HasForeignKey<UserInfo>(ui => ui.UserAccountId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.UserAccounts)
                .WithOne(ua => ua.Role)
                .HasForeignKey(ua => ua.RoleId);
        }
    }
}
