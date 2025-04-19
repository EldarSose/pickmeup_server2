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

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
		{
			var result = await _userService.LoginAsync(dto);
			return Ok(result);
			
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var users = await _userService.GetAllAsync();
			return Ok(users);
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDto dto)
		{
			try
			{
				var updated = await _userService.UpdateAsync(id, dto);
				return Ok(updated);
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(new { message = ex.Message });
			}
			catch (InvalidOperationException ex)
			{
				return Conflict(new { message = ex.Message });
			}
		}

		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var deleted = await _userService.DeleteAsync(id);
			return deleted ? Ok() : NotFound();
		}

		[HttpPost("forgot-password")]
		public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
		{
			var result = await _userService.ForgotPasswordAsync(dto);
			return result ? Ok() : NotFound("User with that email not found.");
		}
	}
}
