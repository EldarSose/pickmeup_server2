using PickMeUp.Core.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.User
{
	public class LoginResponseDto
	{
		public string Token { get; set; } = null!;
		public DateTime ExpiresAt { get; set; }
		public string FullName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		public List<RoleDto> Roles { get; set; } = new(); 
	}
}
