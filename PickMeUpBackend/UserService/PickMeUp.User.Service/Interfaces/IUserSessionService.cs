using PickMeUp.Core.DTOs.User;
using System;
using System.Threading.Tasks;

namespace PickMeUp.User.Service.Interfaces
{
	public interface IUserSessionService
	{
		Task<UserSessionDto> AddSessionAsync(CreateUserSessionDto dto);
		Task<UserSessionDto?> GetSessionAsync(Guid userId, string deviceId);
	}
}
