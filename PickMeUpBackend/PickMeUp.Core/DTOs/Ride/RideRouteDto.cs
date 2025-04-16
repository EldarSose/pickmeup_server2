using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.Ride
{
	public class RideRouteDto
	{
		public List<string> RoutePoints { get; set; } = new();
		public TimeSpan EstimatedTime { get; set; }
	}
}
