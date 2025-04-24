using Microsoft.EntityFrameworkCore;
using PickMeUp.Core.Models.Auth;

namespace PickMeUp.Auth.Repository
{
	public class AuthDbContext : DbContext
	{
		public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

		public DbSet<AuthToken> AuthTokens => Set<AuthToken>();
		public DbSet<Permission> Permissions => Set<Permission>();
		public DbSet<Role> Roles => Set<Role>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Role>()
				.HasMany(r => r.Permissions)
				.WithMany()
				.UsingEntity(j => j.ToTable("RolePermissions"));

			modelBuilder.HasDefaultSchema("auth");
		}
	}
}
