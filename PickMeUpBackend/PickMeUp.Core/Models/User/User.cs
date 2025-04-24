using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickMeUp.Core.Models.Auth;
using PickMeUp.Core.Models.Common;

namespace PickMeUp.Core.Models.User
{

	public class User : BaseEntity
	{
		public string FullName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		public string PasswordHash { get; set; } = null!;

		public ICollection<Role> Roles { get; set; } = new List<Role>();
		public ICollection<UserAddress>? Addresses { get; set; }
		public ICollection<UserSession>? Sessions { get; set; }
	}
}
