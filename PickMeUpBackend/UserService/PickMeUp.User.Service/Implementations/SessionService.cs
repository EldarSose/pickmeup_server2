using AutoMapper;
using PickMeUp.Core.DTOs.User;
using PickMeUp.Core.Models.User;
using PickMeUp.User.Repository.Interfaces;
using PickMeUp.User.Service.Interfaces;

namespace PickMeUp.User.Service.Implementations
{
	public class UserSessionService : IUserSessionService
	{
		private readonly IUserSessionRepository _repo;
		private readonly IMapper _mapper;

		public UserSessionService(IUserSessionRepository repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

		public async Task<UserSessionDto> AddSessionAsync(CreateUserSessionDto dto)
		{
			var session = _mapper.Map<UserSession>(dto);
			var result = await _repo.AddSessionAsync(session);
			return _mapper.Map<UserSessionDto>(result);
		}

		public async Task<UserSessionDto?> GetSessionAsync(Guid userId, string deviceId)
		{
			var session = await _repo.GetSessionAsync(userId, deviceId);
			return session is not null ? _mapper.Map<UserSessionDto>(session) : null;
		}
	}
}
