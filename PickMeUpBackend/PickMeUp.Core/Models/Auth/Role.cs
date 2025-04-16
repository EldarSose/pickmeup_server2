using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Models.Auth
{
	public class Role : BaseEntity
	{
		public string Name { get; set; } = null!;
		public ICollection<Permission>? Permissions { get; set; }
	}
}
