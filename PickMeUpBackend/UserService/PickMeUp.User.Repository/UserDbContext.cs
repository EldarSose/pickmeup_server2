using Microsoft.EntityFrameworkCore;
using UserModel = PickMeUp.Core.Models.User.User;
using UserAddress = PickMeUp.Core.Models.User.UserAddress;
using UserSession = PickMeUp.Core.Models.User.UserSession;
namespace PickMeUp.User.Repository;

public class UserDbContext : DbContext
{
	public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

	public DbSet<UserModel> Users => Set<UserModel>();
	public DbSet<UserAddress> Addresses => Set<UserAddress>();
	public DbSet<UserSession> Sessions => Set<UserSession>();


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<UserAddress>().OwnsOne(a => a.Location);
	}
}
