using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserModel = PickMeUp.Core.Models.User.User;
using PickMeUp.User.Repository.Interfaces;
using PickMeUp.Core.Models.User;

namespace PickMeUp.User.Repository.Implementations
{
	public class UserRepository : IUserRepository
	{
		private readonly UserDbContext _context;

		public UserRepository(UserDbContext context) => _context = context;

		public async Task<UserModel?> GetByEmailAsync(string email) =>
			await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

		public async Task<UserModel> AddAsync(UserModel user)
		{
			_context.Users.Add(user);
			await SaveChangesAsync();
			return user;
		}

		public async Task<IEnumerable<UserModel>> GetAllAsync() =>
			await _context.Users.ToListAsync();

		public async Task<UserAddress> AddAddressAsync(UserAddress address)
		{
			_context.Addresses.Add(address);
			await SaveChangesAsync();
			return address;
		}

		public async Task<IEnumerable<UserAddress>> GetAddressesAsync(Guid userId) =>
			await _context.Addresses.Where(a => a.UserId == userId).ToListAsync();

		public async Task<UserSession> AddSessionAsync(UserSession session)
		{
			_context.Sessions.Add(session);
			await SaveChangesAsync();
			return session;
		}

		public async Task<UserSession?> GetSessionAsync(Guid userId, string deviceId) =>
			await _context.Sessions.FirstOrDefaultAsync(s => s.UserId == userId && s.DeviceId == deviceId);

		public async Task SaveChangesAsync() =>
			await _context.SaveChangesAsync();
	}

}
