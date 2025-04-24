using PickMeUp.Core.Models.Auth;

public class AuthTokenService : IAuthTokenService
{
	private readonly IAuthTokenRepository _repo;
	public AuthTokenService(IAuthTokenRepository repo) => _repo = repo;

	public Task<AuthToken> AddAsync(AuthToken token) => _repo.AddAsync(token);
	public Task<IEnumerable<AuthToken>> GetAllAsync() => _repo.GetAllAsync();
	public Task<AuthToken?> GetByIdAsync(Guid id) => _repo.GetByIdAsync(id);
	public Task<bool> DeleteAsync(Guid id) => _repo.DeleteAsync(id);
}