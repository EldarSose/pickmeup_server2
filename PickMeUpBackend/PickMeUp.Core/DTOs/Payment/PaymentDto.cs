using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.Payment
{
	public class PaymentDto
	{
		public Guid Id { get; set; }
		public Guid RideId { get; set; }
		public decimal Amount { get; set; }
		public string Status { get; set; } = null!;
	}
}
