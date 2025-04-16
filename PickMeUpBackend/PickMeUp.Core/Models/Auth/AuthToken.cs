using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Models.Auth
{
	public class AuthToken : BaseEntity
	{
		public Guid UserId { get; set; }
		public string RefreshToken { get; set; } = null!;
		public DateTime ExpiresAt { get; set; }
	}
}
