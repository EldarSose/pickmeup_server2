using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.Auth
{
	public class RoleWithPermissionsDto : RoleDto
	{
		public List<Guid>? PermissionIds { get; set; }
	}
}
