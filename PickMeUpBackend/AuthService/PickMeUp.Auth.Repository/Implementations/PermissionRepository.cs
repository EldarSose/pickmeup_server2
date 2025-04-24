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
	public class PermissionRepository : IPermissionRepository
	{
		private readonly AuthDbContext _context;
		public PermissionRepository(AuthDbContext context) => _context = context;

		public async Task<Permission> AddAsync(Permission permission)
		{
			_context.Permissions.Add(permission);
			await _context.SaveChangesAsync();
			return permission;
		}

		public async Task<IEnumerable<Permission>> GetAllAsync() => await _context.Permissions.ToListAsync();

		public async Task<Permission?> GetByIdAsync(Guid id) => await _context.Permissions.FindAsync(id);

		public async Task<bool> DeleteAsync(Guid id)
		{
			var permission = await _context.Permissions.FindAsync(id);
			if (permission == null) return false;
			_context.Permissions.Remove(permission);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
