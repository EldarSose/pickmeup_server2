using PickMeUp.Core.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Auth.Repository.Interfaces
{
	public interface IPermissionRepository
	{
		Task<Permission> AddAsync(Permission permission);
		Task<IEnumerable<Permission>> GetAllAsync();
		Task<Permission?> GetByIdAsync(Guid id);
		Task<bool> DeleteAsync(Guid id);
	}
}
