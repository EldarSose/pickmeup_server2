using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.Notification
{
	public class NotificationTemplateDto
	{
		public string Type { get; set; } = null!;
		public string Title { get; set; } = null!;
		public string Content { get; set; } = null!;
	}
}
