using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Models.Ride
{
	public class RideStatusLog : BaseEntity
	{
		public Guid RideId { get; set; }
		public string Status { get; set; } = null!;
		public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
	}
}
