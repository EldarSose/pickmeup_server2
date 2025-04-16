﻿using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.Driver
{
	public class UpdateDriverDto
	{
		public string? FullName { get; set; }
		public string? PhoneNumber { get; set; }
		public bool? IsActive { get; set; }
	}
}
