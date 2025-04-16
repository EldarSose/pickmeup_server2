using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Models.Payment
{
	public class Invoice : BaseEntity
	{
		public Guid PaymentId { get; set; }
		public string InvoiceNumber { get; set; } = null!;
		public DateTime IssuedAt { get; set; } = DateTime.UtcNow;
	}
}
