// ✅ UserAddressService.cs
using AutoMapper;
using PickMeUp.Core.DTOs.User;
using PickMeUp.Core.Models.User;
using PickMeUp.User.Repository.Interfaces;
using PickMeUp.User.Service.Interfaces;

namespace PickMeUp.User.Service.Implementations
{
	public class UserAddressService : IUserAddressService
	{
		private readonly IUserAddressRepository _repo;
		private readonly IMapper _mapper;

		public UserAddressService(IUserAddressRepository repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

		public async Task<IEnumerable<UserAddressDto>> GetAddressesAsync(Guid userId)
		{
			var addresses = await _repo.GetAddressesAsync(userId);
			return _mapper.Map<IEnumerable<UserAddressDto>>(addresses);
		}

		public async Task<UserAddressDto> AddAddressAsync(CreateUserAddressDto dto)
		{
			var existing = await _repo.GetAddressesAsync(dto.UserId);
			if (existing.Any(a => a.Label == dto.Label))
				throw new InvalidOperationException("This address with the same label already exists.");

			var address = _mapper.Map<UserAddress>(dto);
			var result = await _repo.AddAddressAsync(address);
			return _mapper.Map<UserAddressDto>(result);
		}

		public async Task<bool> DeleteAddressAsync(Guid userId, string label)
		{
			return await _repo.DeleteAddressAsync(userId, label);
		}
	}
}