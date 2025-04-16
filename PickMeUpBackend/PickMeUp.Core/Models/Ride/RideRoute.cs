using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Models.Ride
{
	public class RideRoute : BaseEntity
	{
		public Guid RideId { get; set; }
		public List<LocationPoint> RoutePoints { get; set; } = new();
		public TimeSpan EstimatedTime { get; set; }
	}
}
