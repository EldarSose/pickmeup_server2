using Microsoft.AspNetCore.Mvc;
using PickMeUp.Auth.Service.Interfaces;
using PickMeUp.Core.Models.Auth;

namespace PickMeUp.Auth.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PermissionsController : ControllerBase
	{
		private readonly IPermissionService _service;
		public PermissionsController(IPermissionService service) => _service = service;

		[HttpPost]
		public async Task<IActionResult> Add(Permission permission) => Ok(await _service.AddAsync(permission));

		[HttpGet]
		public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var permission = await _service.GetByIdAsync(id);
			return permission == null ? NotFound() : Ok(permission);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var success = await _service.DeleteAsync(id);
			return success ? Ok() : NotFound();
		}
	}

}
