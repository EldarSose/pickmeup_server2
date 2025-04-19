using PickMeUp.Core.DTOs.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PickMeUp.User.Service.Interfaces
{
	public interface IUserAddressService
	{
		Task<IEnumerable<UserAddressDto>> GetAddressesAsync(Guid userId);
		Task<UserAddressDto> AddAddressAsync(CreateUserAddressDto dto);
		Task<bool> DeleteAddressAsync(Guid userId, string label);
	}
}