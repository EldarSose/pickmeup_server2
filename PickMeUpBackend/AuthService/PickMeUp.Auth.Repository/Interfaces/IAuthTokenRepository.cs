using PickMeUp.Core.Models.Auth;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAuthTokenRepository
{
	Task<AuthToken> AddAsync(AuthToken token);
	Task<IEnumerable<AuthToken>> GetAllAsync();
	Task<AuthToken?> GetByIdAsync(Guid id);
	Task<bool> DeleteAsync(Guid id);
}