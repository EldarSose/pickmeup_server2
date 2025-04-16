using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Models.Ride
{
	public class Ride : BaseEntity
	{
		public Guid UserId { get; set; }
		public Guid DriverId { get; set; }
		public Guid? TaxiCompanyId { get; set; }

		public LocationPoint PickupLocation { get; set; } = new();
		public LocationPoint DropoffLocation { get; set; } = new();
		public string Status { get; set; } = "Pending";
		public decimal Price { get; set; }
		public DateTime ScheduledAt { get; set; }

		public ICollection<RideRoute>? StatusLogs { get; set; }
	}
}
