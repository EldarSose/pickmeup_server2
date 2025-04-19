using Microsoft.AspNetCore.Mvc;
using PickMeUp.Core.DTOs.User;
using PickMeUp.User.Service.Interfaces;

namespace PickMeUp.User.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SessionsController : ControllerBase
	{
		private readonly IUserSessionService _userService;

		public SessionsController(IUserSessionService userService) => _userService = userService;

		[HttpPost]
		public async Task<IActionResult> AddSession([FromBody] CreateUserSessionDto dto)
		{
			var session = await _userService.AddSessionAsync(dto);
			return Ok(session);
		}

		[HttpGet("{userId:guid}/{deviceId}")]
		public async Task<IActionResult> GetSession(Guid userId, string deviceId)
		{
			var session = await _userService.GetSessionAsync(userId, deviceId);
			return session != null ? Ok(session) : NotFound();
		}
	}
}