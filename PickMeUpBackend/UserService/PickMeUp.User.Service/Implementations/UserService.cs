using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PickMeUp.Core.DTOs.Auth;
using PickMeUp.Core.DTOs.User;
using PickMeUp.Core.Models.User;
using PickMeUp.User.Repository.Interfaces;
using PickMeUp.User.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserModel = PickMeUp.Core.Models.User.User;

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

		public async Task<UserDto> UpdateAsync(Guid id, UpdateUserDto dto)
		{
			var existingUser = await _repo.GetByIdAsync(id)
				?? throw new KeyNotFoundException("User not found.");

			// Check if email exists and belongs to another user
			var userWithEmail = await _repo.GetByEmailAsync(dto.Email);
			if (userWithEmail != null && userWithEmail.Id != id)
				throw new InvalidOperationException("Another user with this email already exists.");

			_mapper.Map(dto, existingUser);
			await _repo.UpdateAsync(existingUser);
			await _repo.SaveChangesAsync();

			return _mapper.Map<UserDto>(existingUser);
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			var success = await _repo.DeleteAsync(id);
			if (success)
				await _repo.SaveChangesAsync();
			return success;
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
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
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