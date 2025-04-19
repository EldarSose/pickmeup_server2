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
using Microsoft.EntityFrameworkCore;

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
			// Check if email already exists
			var existing = await _repo.GetByEmailAsync(dto.Email);
			if (existing != null)
				throw new InvalidOperationException("A user with this email already exists.");

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
			// Remove existing address if one exists
			var existing = await _repo.GetAddressesAsync(dto.UserId);
			if (existing.Any())
			{
				await _repo.RemoveAllAddressesForUserAsync(dto.UserId); // you can also call a repo method if you'd like
				await _repo.SaveChangesAsync();
			}

			// Add the new address
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
				Id = user.Id,
				Token = tokenHandler.WriteToken(token),
				ExpiresAt = tokenDescriptor.Expires!.Value,
				FullName = user.FullName,
				Email = user.Email,
				PhoneNumber = user.PhoneNumber,
				Roles = userRoles
			};
		}
		public async Task<UserDto> UpdateAsync(Guid id, UpdateUserDto dto)
		{
			var existing = await _repo.GetByIdAsync(id) ?? throw new Exception("Not found.");
			_mapper.Map(dto, existing);
			await _repo.UpdateAsync(existing);
			await _repo.SaveChangesAsync();
			return _mapper.Map<UserDto>(existing);
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			var success = await _repo.DeleteAsync(id);
			if (success)
				await _repo.SaveChangesAsync();
			return success;
		}
		public async Task<bool> ForgotPasswordAsync(ForgotPasswordDto dto)
		{
			var user = await _repo.GetByEmailAsync(dto.Email);
			if (user == null) return false;

			user.PasswordHash = Convert.ToBase64String(Encoding.UTF8.GetBytes(dto.NewPassword));
			await _repo.UpdateAsync(user);
			await _repo.SaveChangesAsync();
			return true;
		}
	}

}

