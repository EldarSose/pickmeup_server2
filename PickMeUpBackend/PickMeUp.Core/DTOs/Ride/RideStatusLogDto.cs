using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.Ride
{
	public class RideStatusLogDto
	{
		public string Status { get; set; } = null!;
		public DateTime ChangedAt { get; set; }
	}
}
