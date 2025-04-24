using Microsoft.EntityFrameworkCore;
using PickMeUp.Auth.Repository.Interfaces;
using PickMeUp.Core.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Auth.Repository.Implementations
{
	public class RoleRepository : IRoleRepository
	{
		private readonly AuthDbContext _context;
		public RoleRepository(AuthDbContext context) => _context = context;

		public async Task<Role> AddAsync(Role role)
		{
			_context.Roles.Add(role);
			await _context.SaveChangesAsync();
			return role;
		}

		public async Task<IEnumerable<Role>> GetAllAsync() => await _context.Roles.Include(r => r.Permissions).ToListAsync();

		public async Task<Role?> GetByIdAsync(Guid id) => await _context.Roles.Include(r => r.Permissions).FirstOrDefaultAsync(r => r.Id == id);

		public async Task<bool> DeleteAsync(Guid id)
		{
			var role = await _context.Roles.FindAsync(id);
			if (role == null) return false;
			_context.Roles.Remove(role);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<Role> UpdateAsync(Role role)
		{
			_context.Roles.Update(role);
			await _context.SaveChangesAsync();
			return role;
		}
	}
}
