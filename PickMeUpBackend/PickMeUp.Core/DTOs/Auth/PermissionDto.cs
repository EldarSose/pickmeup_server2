﻿using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.Auth
{
	public class PermissionDto
	{
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
	}
}
