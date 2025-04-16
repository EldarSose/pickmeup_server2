using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.User
{
	public class UserDto
	{
		public Guid Id { get; set; }
		public string FullName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
	}
}
