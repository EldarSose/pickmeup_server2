using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.Driver
{
	public class TaxiCompanyDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Address { get; set; } = null!;
		public string LogoUrl { get; set; } = null!;
		public float AverageRating { get; set; }
	}
}
