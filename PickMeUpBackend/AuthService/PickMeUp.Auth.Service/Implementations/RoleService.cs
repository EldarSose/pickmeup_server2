using PickMeUp.Auth.Repository.Interfaces;
using PickMeUp.Auth.Service.Interfaces;
using PickMeUp.Core.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Auth.Service.Implementations
{
	public class RoleService : IRoleService
	{
		private readonly IRoleRepository _repo;
		public RoleService(IRoleRepository repo) => _repo = repo;

		public Task<Role> AddAsync(Role role) => _repo.AddAsync(role);
		public Task<IEnumerable<Role>> GetAllAsync() => _repo.GetAllAsync();
		public Task<Role?> GetByIdAsync(Guid id) => _repo.GetByIdAsync(id);
		public Task<bool> DeleteAsync(Guid id) => _repo.DeleteAsync(id);
		public Task<Role> UpdateAsync(Role role) => _repo.UpdateAsync(role);
	}
}
