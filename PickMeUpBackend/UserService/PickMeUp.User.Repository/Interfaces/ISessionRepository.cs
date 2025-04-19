using PickMeUp.Core.Models.User;
using System;
using System.Threading.Tasks;

namespace PickMeUp.User.Repository.Interfaces
{
	public interface IUserSessionRepository
	{
		Task<UserSession> AddSessionAsync(UserSession session);
		Task<UserSession?> GetSessionAsync(Guid userId, string deviceId);
	}
}