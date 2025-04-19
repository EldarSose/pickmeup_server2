using Microsoft.AspNetCore.Mvc;
using PickMeUp.Core.DTOs.User;
using PickMeUp.User.Service.Interfaces;

namespace PickMeUp.User.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;

		public UsersController(IUserService userService) => _userService = userService;

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
		{
			try
			{
				var user = await _userService.RegisterAsync(dto);
				return Ok(user);
			}
			catch (InvalidOperationException ex)
			{
				return Conflict(new { message = ex.Message });
			}
		}


		// GET: api/Users
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var users = await _userService.GetAllAsync();
			return Ok(users);
		}

		// POST: api/Users/address
		[HttpPost("address")]
		public async Task<IActionResult> AddAddress([FromBody] CreateUserAddressDto dto)
		{
			var address = await _userService.AddAddressAsync(dto);
			return Ok(address);
		}

		// GET: api/Users/{userId}/addresses
		[HttpGet("{userId:guid}/addresses")]
		public async Task<IActionResult> GetAddresses([FromRoute] Guid userId)
		{
			var addresses = await _userService.GetAddressesAsync(userId);
			return Ok(addresses);
		}

		// POST: api/Users/session
		[HttpPost("session")]
		public async Task<IActionResult> AddSession([FromBody] CreateUserSessionDto dto)
		{
			var session = await _userService.AddSessionAsync(dto);
			return Ok(session);
		}

		// GET: api/Users/{userId}/session/{deviceId}
		[HttpGet("{userId:guid}/session/{deviceId}")]
		public async Task<IActionResult> GetSession(Guid userId, string deviceId)
		{
			var session = await _userService.GetSessionAsync(userId, deviceId);
			return session is not null ? Ok(session) : NotFound();
		}

		// POST: api/Users/login
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
		{
			var result = await _userService.LoginAsync(dto);
			return Ok(result);
		}
		[HttpPost("forgot-password")]
		public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
		{
			var result = await _userService.ForgotPasswordAsync(dto);
			return result ? Ok() : NotFound("User with that email not found.");
		}
		[HttpPut("{id:guid}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDto dto)
		{
			var updated = await _userService.UpdateAsync(id, dto);
			return Ok(updated);
		}
		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var deleted = await _userService.DeleteAsync(id);
			return deleted ? Ok() : NotFound();
		}
	}
}
