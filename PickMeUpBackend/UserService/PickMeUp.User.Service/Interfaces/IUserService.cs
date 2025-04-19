using PickMeUp.Core.DTOs.Auth;
using PickMeUp.Core.DTOs.User;

namespace PickMeUp.User.Service.Interfaces
{
	public interface IUserService
	{
		Task<UserDto> RegisterAsync(RegisterUserDto dto);
		Task<IEnumerable<UserDto>> GetAllAsync();
		Task<UserDto> UpdateAsync(Guid id, UpdateUserDto dto);
		Task<bool> DeleteAsync(Guid id);

		Task<IEnumerable<UserAddressDto>> GetAddressesAsync(Guid userId);
		Task<UserAddressDto> AddAddressAsync(CreateUserAddressDto dto);

		Task<UserSessionDto> AddSessionAsync(CreateUserSessionDto dto);
		Task<UserSessionDto?> GetSessionAsync(Guid userId, string deviceId);

		Task<LoginResponseDto> LoginAsync(LoginUserDto dto);
		Task<bool> ForgotPasswordAsync(ForgotPasswordDto dto);

	}
}
