using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Models.Rating
{
	public class Rating : BaseEntity
	{
		public Guid RideId { get; set; }
		public Guid DriverId { get; set; }
		public Guid UserId { get; set; }
		public int Score { get; set; }
		public string? Comment { get; set; }
		public DateTime RatedAt { get; set; } = DateTime.UtcNow;
	}
}
