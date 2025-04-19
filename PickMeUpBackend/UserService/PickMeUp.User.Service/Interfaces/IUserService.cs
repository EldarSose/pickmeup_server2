using PickMeUp.Core.DTOs.Auth;
using PickMeUp.Core.DTOs.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PickMeUp.User.Service.Interfaces
{
	public interface IUserService
	{
		Task<UserDto> RegisterAsync(RegisterUserDto dto);
		Task<IEnumerable<UserDto>> GetAllAsync();
		Task<UserDto> UpdateAsync(Guid id, UpdateUserDto dto);
		Task<bool> DeleteAsync(Guid id);
		Task<LoginResponseDto> LoginAsync(LoginUserDto dto);
		Task<bool> ForgotPasswordAsync(ForgotPasswordDto dto);
	}
}