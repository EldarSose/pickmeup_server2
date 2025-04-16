using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Models.Notification
{
	public class Notification : BaseEntity
	{
		public Guid UserId { get; set; }
		public string Type { get; set; } = null!; // e.g. Email, SMS, Push
		public string Message { get; set; } = null!;
		public DateTime SentAt { get; set; } = DateTime.UtcNow;
	}
}
