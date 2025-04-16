using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Models.Rating
{
	public class RatingSummary : BaseEntity
	{
		public Guid DriverId { get; set; }
		public float AverageScore { get; set; }
		public int TotalRatings { get; set; }
	}
}
