using AutoMapper;
using PickMeUp.Core.DTOs.User;
using UserModel = PickMeUp.Core.Models.User.User;
using PickMeUp.User.Repository.Interfaces;
using PickMeUp.User.Service.Interfaces;
using PickMeUp.Core.Models.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PickMeUp.Core.DTOs.Auth;

namespace PickMeUp.User.Service.Implementations
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _repo;
		private readonly IMapper _mapper;
		private readonly IConfiguration _configuration;

		public UserService(IUserRepository repo, IMapper mapper, IConfiguration configuration)
		{
			_repo = repo;
			_mapper = mapper;
			_configuration = configuration;
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

		public async Task<LoginResponseDto> LoginAsync(LoginUserDto dto)
		{
			var user = await _repo.GetByEmailAsync(dto.Email);
			if (user == null || string.IsNullOrWhiteSpace(dto.Password))
				throw new UnauthorizedAccessException("Invalid credentials.");

			var decodedPassword = Encoding.UTF8.GetString(Convert.FromBase64String(user.PasswordHash));
			if (decodedPassword != dto.Password)
				throw new UnauthorizedAccessException("Invalid credentials.");

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]!);

			// Placeholder for future roles
			var userRoles = new List<RoleDto> { new RoleDto { Name = "User" } };

			var claims = new List<Claim>
				{
					new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
					new Claim(ClaimTypes.Email, user.Email),
					new Claim(ClaimTypes.Name, user.FullName),
					new Claim(ClaimTypes.MobilePhone, user.PhoneNumber)
				};

			foreach (var role in userRoles)
				claims.Add(new Claim(ClaimTypes.Role, role.Name));

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(
					new SymmetricSecurityKey(key),
					SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);

			return new LoginResponseDto
			{
				Token = tokenHandler.WriteToken(token),
				ExpiresAt = tokenDescriptor.Expires!.Value,
				FullName = user.FullName,
				Email = user.Email,
				PhoneNumber = user.PhoneNumber,
				Roles = userRoles
			};
		}
	}

}

