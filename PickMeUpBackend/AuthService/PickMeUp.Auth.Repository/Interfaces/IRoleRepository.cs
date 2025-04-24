using PickMeUp.Core.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Auth.Repository.Interfaces
{
	public interface IRoleRepository
	{
		Task<Role> AddAsync(Role role);
		Task<IEnumerable<Role>> GetAllAsync();
		Task<Role?> GetByIdAsync(Guid id);
		Task<bool> DeleteAsync(Guid id);
		Task<Role> UpdateAsync(Role role);
	}
}
