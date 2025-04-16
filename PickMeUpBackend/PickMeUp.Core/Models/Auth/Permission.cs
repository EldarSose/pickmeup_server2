using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Models.Auth
{
	public class Permission : BaseEntity
	{
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
	}
}
