using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Models.User
{
	public class UserAddress : BaseEntity
	{
		public Guid UserId { get; set; }
		public string Label { get; set; } = null!;
		public LocationPoint Location { get; set; } = new();
	}
}
