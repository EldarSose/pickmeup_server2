using AutoMapper;
using PickMeUp.Core.Models.Auth;
using PickMeUp.Core.DTOs.Auth;

public class AuthProfile : Profile
{
	public AuthProfile()
	{
		CreateMap<Permission, PermissionDto>().ReverseMap();
		CreateMap<Role, RoleDto>()
			.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
			.ReverseMap();
	}
}