using Microsoft.EntityFrameworkCore;
using PickMeUp.Core.Models.User;
using PickMeUp.User.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickMeUp.User.Repository.Implementations
{
	public class UserAddressRepository : IUserAddressRepository
	{
		private readonly UserDbContext _context;
		public UserAddressRepository(UserDbContext context) => _context = context;

		public async Task<IEnumerable<UserAddress>> GetAddressesAsync(Guid userId) =>
			await _context.Addresses.Where(a => a.UserId == userId).ToListAsync();

		public async Task<UserAddress> AddAddressAsync(UserAddress address)
		{
			_context.Addresses.Add(address);
			await _context.SaveChangesAsync();
			return address;
		}

		public async Task RemoveAllAddressesForUserAsync(Guid userId)
		{
			var existing = await _context.Addresses.Where(a => a.UserId == userId).ToListAsync();
			if (existing.Any())
			{
				_context.Addresses.RemoveRange(existing);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<bool> DeleteAddressAsync(Guid userId, string label)
		{
			var address = await _context.Addresses.FirstOrDefaultAsync(a => a.UserId == userId && a.Label == label);
			if (address == null) return false;

			_context.Addresses.Remove(address);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}