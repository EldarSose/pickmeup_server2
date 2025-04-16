using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.Ride
{
	public class CreateRideDto
	{
		public Guid UserId { get; set; }
		public Guid DriverId { get; set; }
		public Guid? TaxiCompanyId { get; set; }
		public string PickupAddress { get; set; } = null!;
		public string DropoffAddress { get; set; } = null!;
		public DateTime ScheduledAt { get; set; }
	}
}
