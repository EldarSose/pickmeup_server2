using AutoMapper;
using PickMeUp.Core.DTOs.User;
using UserModel = PickMeUp.Core.Models.User.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickMeUp.Core.Models.User;

namespace PickMeUp.User.Service.Mappings
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<UserModel, UserDto>();
			CreateMap<RegisterUserDto, PickMeUp.Core.Models.User.User>()
	.ForMember(dest => dest.PasswordHash, opt =>
		opt.MapFrom(src => Convert.ToBase64String(Encoding.UTF8.GetBytes(src.Password))))
	.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
	.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
	.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));

			CreateMap<UserAddress, UserAddressDto>();
			CreateMap<CreateUserAddressDto, UserAddress>();

			CreateMap<UserSession, UserSessionDto>();
			CreateMap<CreateUserSessionDto, UserSession>();
			CreateMap<UpdateUserDto, UserModel>()
	.ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));
		}
	}
}
