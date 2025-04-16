using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickMeUp.Core.Models.Common;

namespace PickMeUp.Core.Models.Driver
{

	public class DriverLocation : BaseEntity
	{
		public Guid DriverId { get; set; }
		public LocationPoint Location { get; set; } = new();
		public DateTime Timestamp { get; set; } = DateTime.UtcNow;
	}
}
