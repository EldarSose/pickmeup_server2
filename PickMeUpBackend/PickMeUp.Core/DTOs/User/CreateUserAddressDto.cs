using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.User
{
	public class CreateUserAddressDto
	{
		public Guid UserId { get; set; }
		public string Label { get; set; } = null!;
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string? Address { get; set; }
	}
}
