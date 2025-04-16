using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Models.Driver
{
	public class Vehicle : BaseEntity
	{
		public string Make { get; set; } = null!;
		public string Model { get; set; } = null!;
		public int Year { get; set; }
		public string LicensePlate { get; set; } = null!;
		public string Color { get; set; } = null!;
		public int Seats { get; set; }
		public string FuelType { get; set; } = null!; // e.g. Petrol, Diesel, Electric
		public bool IsActive { get; set; } = true;

		// Optional: Owned by a taxi company or assigned to a driver
		public Guid? DriverId { get; set; }
		public Guid? TaxiCompanyId { get; set; }
	}
}
