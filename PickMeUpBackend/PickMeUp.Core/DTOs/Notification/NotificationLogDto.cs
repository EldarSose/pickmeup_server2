using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.Notification
{
	public class NotificationLogDto
	{
		public bool Success { get; set; }
		public string? ResponseDetails { get; set; }
		public DateTime AttemptedAt { get; set; }
	}
}
