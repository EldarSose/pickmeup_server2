using AutoMapper;
using PickMeUp.Core.DTOs.User;
using UserModel = PickMeUp.Core.Models.User.User;
using PickMeUp.User.Repository.Interfaces;
using PickMeUp.User.Service.Interfaces;
using PickMeUp.Core.Models.User;

namespace PickMeUp.User.Service.Implementations
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _repo;
		private readonly IMapper _mapper;

		public UserService(IUserRepository repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

		public async Task<UserDto> RegisterAsync(RegisterUserDto dto)
		{
			var user = _mapper.Map<UserModel>(dto);
			var addedUser = await _repo.AddAsync(user);
			return _mapper.Map<UserDto>(addedUser);
		}

		public async Task<IEnumerable<UserDto>> GetAllAsync()
		{
			var users = await _repo.GetAllAsync();
			return _mapper.Map<IEnumerable<UserDto>>(users);
		}

		public async Task<IEnumerable<UserAddressDto>> GetAddressesAsync(Guid userId)
		{
			var addresses = await _repo.GetAddressesAsync(userId);
			return _mapper.Map<IEnumerable<UserAddressDto>>(addresses);
		}

		public async Task<UserAddressDto> AddAddressAsync(CreateUserAddressDto dto)
		{
			var address = _mapper.Map<UserAddress>(dto);
			var result = await _repo.AddAddressAsync(address);
			return _mapper.Map<UserAddressDto>(result);
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
			return session != null ? _mapper.Map<UserSessionDto>(session) : null;
		}
	}
}
