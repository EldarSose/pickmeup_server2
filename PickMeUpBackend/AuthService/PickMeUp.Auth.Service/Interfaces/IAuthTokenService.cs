using PickMeUp.Core.Models.Auth;

public interface IAuthTokenService
{
	Task<AuthToken> AddAsync(AuthToken token);
	Task<IEnumerable<AuthToken>> GetAllAsync();
	Task<AuthToken?> GetByIdAsync(Guid id);
	Task<bool> DeleteAsync(Guid id);
}
