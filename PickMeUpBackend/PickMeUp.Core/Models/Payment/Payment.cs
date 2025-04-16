using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Models.Payment
{
	public class Payment : BaseEntity
	{
		public Guid RideId { get; set; }
		public decimal Amount { get; set; }
		public string Status { get; set; } = "Pending";
		public DateTime PaidAt { get; set; }
	}
}
