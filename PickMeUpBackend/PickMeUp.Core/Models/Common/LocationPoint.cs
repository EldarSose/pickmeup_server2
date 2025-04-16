using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Models.Common
{
	public class LocationPoint
	{
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string? Address { get; set; }
	}
}
