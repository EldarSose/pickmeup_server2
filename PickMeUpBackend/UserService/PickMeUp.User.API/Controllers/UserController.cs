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
				var user = await _userService.RegisterAsync(dto);
				return Ok(user);
			}

			[HttpGet]
			public async Task<IActionResult> GetAll()
			{
				var users = await _userService.GetAllAsync();
				return Ok(users);
			}

			[HttpPost("address")]
			public async Task<IActionResult> AddAddress([FromBody] CreateUserAddressDto dto)
			{
				var address = await _userService.AddAddressAsync(dto);
				return Ok(address);
			}

			[HttpGet("{userId:guid}/addresses")]
			public async Task<IActionResult> GetAddresses([FromRoute] Guid userId)
			{
				var addresses = await _userService.GetAddressesAsync(userId);
				return Ok(addresses);
			}

			[HttpPost("session")]
			public async Task<IActionResult> AddSession([FromBody] CreateUserSessionDto dto)
			{
				var session = await _userService.AddSessionAsync(dto);
				return Ok(session);
			}

			[HttpGet("{userId:guid}/session/{deviceId}")]
			public async Task<IActionResult> GetSession(Guid userId, string deviceId)
			{
				var session = await _userService.GetSessionAsync(userId, deviceId);
				return session is not null ? Ok(session) : NotFound();
			}
		}
}
