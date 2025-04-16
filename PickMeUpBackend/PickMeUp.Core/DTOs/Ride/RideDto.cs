using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.Ride
{
	public class RideDto
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public Guid DriverId { get; set; }
		public string PickupAddress { get; set; } = null!;
		public string DropoffAddress { get; set; } = null!;
		public decimal Price { get; set; }
		public string Status { get; set; } = null!;
	}
}
