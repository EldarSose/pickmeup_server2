using Microsoft.EntityFrameworkCore;
using PickMeUp.Core.Models.User;
using PickMeUp.User.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserModel = PickMeUp.Core.Models.User.User;

namespace PickMeUp.User.Repository.Implementations
{
	public class UserRepository : IUserRepository
	{
		private readonly UserDbContext _context;
		public UserRepository(UserDbContext context) => _context = context;

		public async Task<UserModel?> GetByEmailAsync(string email) =>
			await _context.Users
		.Include(u => u.Roles)
		.FirstOrDefaultAsync(u => u.Email == email);

		public async Task<UserModel?> GetByIdAsync(Guid id) =>
			await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

		public async Task<UserModel> AddAsync(UserModel user)
		{
			_context.Users.Add(user);
			await SaveChangesAsync();
			return user;
		}

		public async Task<UserModel> UpdateAsync(UserModel user)
		{
			_context.Users.Update(user);
			await SaveChangesAsync();
			return user;
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			var entity = await _context.Users.FindAsync(id);
			if (entity == null) return false;

			_context.Users.Remove(entity);
			await SaveChangesAsync();
			return true;
		}

		public async Task<IEnumerable<UserModel>> GetAllAsync() =>
			await _context.Users.ToListAsync();

		public async Task<int> SaveChangesAsync() =>
			await _context.SaveChangesAsync();
	}
}