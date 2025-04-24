using Microsoft.AspNetCore.Mvc;
using PickMeUp.Core.Models.Auth;

[ApiController]
[Route("api/[controller]")]
public class AuthTokensController : ControllerBase
{
	private readonly IAuthTokenService _service;
	public AuthTokensController(IAuthTokenService service) => _service = service;

	[HttpPost]
	public async Task<IActionResult> Add(AuthToken token) => Ok(await _service.AddAsync(token));

	[HttpGet]
	public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(Guid id)
	{
		var token = await _service.GetByIdAsync(id);
		return token == null ? NotFound() : Ok(token);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var success = await _service.DeleteAsync(id);
		return success ? Ok() : NotFound();
	}
}