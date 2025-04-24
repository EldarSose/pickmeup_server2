using Microsoft.AspNetCore.Mvc;
using PickMeUp.Auth.Repository.Interfaces;
using PickMeUp.Auth.Service.Interfaces;
using PickMeUp.Core.DTOs.Auth;
using PickMeUp.Core.Models.Auth;

namespace PickMeUp.Auth.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RolesController : ControllerBase
	{
		private readonly IRoleService _service;
		private readonly IPermissionRepository _permissionRepo;

		public RolesController(IRoleService service, IPermissionRepository permissionRepo)
		{
			_service = service;
			_permissionRepo = permissionRepo;
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] RoleDto dto)
		{
			var role = new Role { Name = dto.Name };
			if (dto is RoleWithPermissionsDto roleWithPerms && roleWithPerms.PermissionIds != null)
			{
				var permissions = await _permissionRepo.GetAllAsync();
				role.Permissions = permissions.Where(p => roleWithPerms.PermissionIds.Contains(p.Id)).ToList();
			}
			var added = await _service.AddAsync(role);
			return Ok(added);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] RoleWithPermissionsDto dto)
		{
			var existing = await _service.GetByIdAsync(id);
			if (existing == null) return NotFound();

			existing.Name = dto.Name;

			if (dto.PermissionIds != null)
			{
				var allPermissions = await _permissionRepo.GetAllAsync();
				existing.Permissions = allPermissions.Where(p => dto.PermissionIds.Contains(p.Id)).ToList();
			}

			var updated = await _service.UpdateAsync(existing);
			return Ok(updated);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var role = await _service.GetByIdAsync(id);
			return role == null ? NotFound() : Ok(role);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var success = await _service.DeleteAsync(id);
			return success ? Ok() : NotFound();
		}
	}
}
