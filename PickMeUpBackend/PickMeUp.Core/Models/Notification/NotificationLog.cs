using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Models.Notification
{
	public class NotificationLog : BaseEntity
	{
		public Guid NotificationId { get; set; }
		public bool Success { get; set; }
		public string? ResponseDetails { get; set; }
		public DateTime AttemptedAt { get; set; } = DateTime.UtcNow;
	}
}
