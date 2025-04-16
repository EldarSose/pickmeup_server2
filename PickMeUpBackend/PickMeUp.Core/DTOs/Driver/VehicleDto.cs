using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.Driver
{
	public class VehicleDto
	{
		public Guid Id { get; set; }
		public string Make { get; set; } = null!;
		public string Model { get; set; } = null!;
		public string LicensePlate { get; set; } = null!;
		public string Color { get; set; } = null!;
	}
}
