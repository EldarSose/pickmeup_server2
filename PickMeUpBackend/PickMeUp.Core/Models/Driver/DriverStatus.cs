using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Models.Driver
{
	public class DriverStatus : BaseEntity
	{
		public Guid DriverId { get; set; }
		public string Status { get; set; } = "Offline";
		public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
	}
}
