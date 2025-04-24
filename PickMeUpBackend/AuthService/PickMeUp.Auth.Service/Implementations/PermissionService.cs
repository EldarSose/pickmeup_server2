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
	public class PermissionService : IPermissionService
	{
		private readonly IPermissionRepository _repo;
		public PermissionService(IPermissionRepository repo) => _repo = repo;

		public Task<Permission> AddAsync(Permission permission) => _repo.AddAsync(permission);
		public Task<IEnumerable<Permission>> GetAllAsync() => _repo.GetAllAsync();
		public Task<Permission?> GetByIdAsync(Guid id) => _repo.GetByIdAsync(id);
		public Task<bool> DeleteAsync(Guid id) => _repo.DeleteAsync(id);
	}
}
