using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.Notification
{
	public class SendNotificationDto
	{
		public Guid UserId { get; set; }
		public string Type { get; set; } = null!;
		public string Message { get; set; } = null!;
	}
}
