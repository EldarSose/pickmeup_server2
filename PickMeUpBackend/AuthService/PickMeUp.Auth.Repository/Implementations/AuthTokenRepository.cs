using Microsoft.EntityFrameworkCore;
using PickMeUp.Auth.Repository;
using PickMeUp.Core.Models.Auth;

public class AuthTokenRepository : IAuthTokenRepository
{
	private readonly AuthDbContext _context;
	public AuthTokenRepository(AuthDbContext context) => _context = context;

	public async Task<AuthToken> AddAsync(AuthToken token)
	{
		_context.AuthTokens.Add(token);
		await _context.SaveChangesAsync();
		return token;
	}

	public async Task<IEnumerable<AuthToken>> GetAllAsync() => await _context.AuthTokens.ToListAsync();

	public async Task<AuthToken?> GetByIdAsync(Guid id) => await _context.AuthTokens.FindAsync(id);

	public async Task<bool> DeleteAsync(Guid id)
	{
		var token = await _context.AuthTokens.FindAsync(id);
		if (token == null) return false;
		_context.AuthTokens.Remove(token);
		await _context.SaveChangesAsync();
		return true;
	}
}