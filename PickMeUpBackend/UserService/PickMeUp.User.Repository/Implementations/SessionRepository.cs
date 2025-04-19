using Microsoft.EntityFrameworkCore;
using PickMeUp.Core.Models.User;
using PickMeUp.User.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace PickMeUp.User.Repository.Implementations
{
	public class UserSessionRepository : IUserSessionRepository
	{
		private readonly UserDbContext _context;
		public UserSessionRepository(UserDbContext context) => _context = context;

		public async Task<UserSession> AddSessionAsync(UserSession session)
		{
			_context.Sessions.Add(session);
			await _context.SaveChangesAsync();
			return session;
		}

		public async Task<UserSession?> GetSessionAsync(Guid userId, string deviceId) =>
			await _context.Sessions.FirstOrDefaultAsync(s => s.UserId == userId && s.DeviceId == deviceId);
	}
}
