﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.Auth
{
	public class RegisterDto
	{
		public string FullName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		public string Password { get; set; } = null!;
	}
}
