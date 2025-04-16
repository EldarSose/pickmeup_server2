using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Models.Payment
{
	public class Refund : BaseEntity
	{
		public Guid PaymentId { get; set; }
		public decimal Amount { get; set; }
		public string Reason { get; set; } = null!;
		public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
	}

}
