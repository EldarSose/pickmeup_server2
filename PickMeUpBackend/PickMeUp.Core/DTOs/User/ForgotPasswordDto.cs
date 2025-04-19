using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.User
{
	public class ForgotPasswordDto
	{
		public string Email { get; set; } = string.Empty;
		public string NewPassword { get; set; } = string.Empty;
	}

}
