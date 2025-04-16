using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.Rating
{
	public class RatingDto
	{
		public Guid Id { get; set; }
		public int Score { get; set; }
		public string? Comment { get; set; }
		public DateTime RatedAt { get; set; }
	}
}
