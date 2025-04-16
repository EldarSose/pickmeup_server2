using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.Rating
{
	public class CreateRatingDto
	{
		public Guid RideId { get; set; }
		public Guid DriverId { get; set; }
		public Guid UserId { get; set; }
		public int Score { get; set; }
		public string? Comment { get; set; }
	}
}
