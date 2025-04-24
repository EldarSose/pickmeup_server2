using PickMeUp.Core.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Auth.Service.Interfaces
{
	public interface IPermissionService
	{
		Task<Permission> AddAsync(Permission permission);
		Task<IEnumerable<Permission>> GetAllAsync();
		Task<Permission?> GetByIdAsync(Guid id);
		Task<bool> DeleteAsync(Guid id);
	}
}
