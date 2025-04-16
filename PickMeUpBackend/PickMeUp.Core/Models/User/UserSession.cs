using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Models.User
{
	public class UserSession : BaseEntity
	{
		public Guid UserId { get; set; }
		public string DeviceId { get; set; } = null!;
		public DateTime ExpiresAt { get; set; }
	}
}
