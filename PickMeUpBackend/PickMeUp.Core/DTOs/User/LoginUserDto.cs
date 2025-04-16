﻿using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.User
{
	public class LoginUserDto
	{
		public string Email { get; set; } = null!;
		public string Password { get; set; } = null!;
	}
}
