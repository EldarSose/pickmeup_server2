using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickMeUp.Core.Models.Common;

namespace PickMeUp.Core.DTOs.Driver
{

	public class DriverDto
	{
		public Guid Id { get; set; }
		public string FullName { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		public Guid TaxiCompanyId { get; set; }
	}
}
