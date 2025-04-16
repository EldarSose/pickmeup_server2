using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.Payment
{
	public class CreatePaymentDto
	{
		public Guid RideId { get; set; }
		public decimal Amount { get; set; }
	}
}
