using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.Payment
{
	public class InvoiceDto
	{
		public string InvoiceNumber { get; set; } = null!;
		public DateTime IssuedAt { get; set; }
	}
}
