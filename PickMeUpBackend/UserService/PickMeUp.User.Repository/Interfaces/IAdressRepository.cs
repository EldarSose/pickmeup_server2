using PickMeUp.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PickMeUp.User.Repository.Interfaces
{
	public interface IUserAddressRepository
	{
		Task<IEnumerable<UserAddress>> GetAddressesAsync(Guid userId);
		Task<UserAddress> AddAddressAsync(UserAddress address);
		Task RemoveAllAddressesForUserAsync(Guid userId);
		Task<bool> DeleteAddressAsync(Guid userId, string label);
	}
}