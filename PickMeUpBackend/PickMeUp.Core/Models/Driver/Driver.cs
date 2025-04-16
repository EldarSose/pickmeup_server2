using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickMeUp.Core.Models.Common;

namespace PickMeUp.Core.Models.Driver
{

	public class Driver : BaseEntity
	{
		public string FullName { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		public bool IsActive { get; set; }
		public Guid TaxiCompanyId { get; set; }

		public TaxiCompany? Company { get; set; }
		public ICollection<Vehicle>? Vehicles { get; set; }
		public DriverStatus? Status { get; set; }
		public DriverLocation? Location { get; set; }
	}
}
