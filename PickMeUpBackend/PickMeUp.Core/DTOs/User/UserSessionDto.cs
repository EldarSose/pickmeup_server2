using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.User
{
	public class UserSessionDto
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public string DeviceId { get; set; } = null!;
		public DateTime ExpiresAt { get; set; }
	}
}
