using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.Payment
{
	public class RefundDto
	{
		public Guid PaymentId { get; set; }
		public decimal Amount { get; set; }
		public string Reason { get; set; } = null!;
	}

}
