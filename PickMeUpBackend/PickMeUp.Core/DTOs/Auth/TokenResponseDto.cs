using PickMeUp.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.DTOs.Auth
{
	public class TokenResponseDto
	{
		public string AccessToken { get; set; } = null!;
		public string RefreshToken { get; set; } = null!;
		public DateTime ExpiresAt { get; set; }
	}
}
