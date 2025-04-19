using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.User
{
	public class UpdateUserDto
	{
		public string? FullName { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Email { get; set; }
	}
}
