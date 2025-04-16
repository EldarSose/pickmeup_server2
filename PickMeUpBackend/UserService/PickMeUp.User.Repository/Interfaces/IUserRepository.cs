using PickMeUp.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModel = PickMeUp.Core.Models.User.User;

namespace PickMeUp.User.Repository.Interfaces
{
	public interface IUserRepository
	{
		Task<UserModel?> GetByEmailAsync(string email);
		Task<UserModel> AddAsync(UserModel user);
		Task<IEnumerable<UserModel>> GetAllAsync();
		Task<UserAddress> AddAddressAsync(UserAddress address);
		Task<IEnumerable<UserAddress>> GetAddressesAsync(Guid userId);
		Task<UserSession> AddSessionAsync(UserSession session);
		Task<UserSession?> GetSessionAsync(Guid userId, string deviceId);
		Task SaveChangesAsync();
	}
}
