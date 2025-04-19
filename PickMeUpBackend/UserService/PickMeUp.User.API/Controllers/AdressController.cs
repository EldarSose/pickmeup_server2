
// ✅ AddressController.cs
using Microsoft.AspNetCore.Mvc;
using PickMeUp.Core.DTOs.User;
using PickMeUp.User.Service.Interfaces;

namespace PickMeUp.User.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AddressesController : ControllerBase
	{
		private readonly IUserAddressService _userService;

		public AddressesController(IUserAddressService userService) => _userService = userService;

		[HttpGet("{userId:guid}")]
		public async Task<IActionResult> GetUserAddresses(Guid userId)
		{
			var addresses = await _userService.GetAddressesAsync(userId);
			return Ok(addresses);
		}

		[HttpPost]
		public async Task<IActionResult> AddAddress([FromBody] CreateUserAddressDto dto)
		{
			try
			{
				var address = await _userService.AddAddressAsync(dto);
				return Ok(address);
			}
			catch (InvalidOperationException ex)
			{
				return Conflict(new { message = ex.Message });
			}
		}

		[HttpDelete("{userId:guid}/{label}")]
		public async Task<IActionResult> DeleteAddress(Guid userId, string label)
		{
			var success = await _userService.DeleteAddressAsync(userId, label);
			return success ? Ok() : NotFound();
		}
	}
}