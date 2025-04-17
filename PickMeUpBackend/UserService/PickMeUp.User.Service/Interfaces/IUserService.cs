using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickMeUp.Core.DTOs.User;

namespace PickMeUp.User.Service.Interfaces
{
	public interface IUserService
	{
		Task<UserDto> RegisterAsync(RegisterUserDto dto);
		Task<IEnumerable<UserDto>> GetAllAsync();
		Task<IEnumerable<UserAddressDto>> GetAddressesAsync(Guid userId);
		Task<UserAddressDto> AddAddressAsync(CreateUserAddressDto dto); 
		Task<UserSessionDto> AddSessionAsync(CreateUserSessionDto dto);
		Task<UserSessionDto?> GetSessionAsync(Guid userId, string deviceId);
		Task<LoginResponseDto> LoginAsync(LoginUserDto dto);
	}
}
