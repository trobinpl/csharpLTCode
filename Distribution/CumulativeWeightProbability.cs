using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution
{
	public class CumulativeWeightProbability
	{
		public int Weight { get; set; }
		public double CumulativeProbability { get; set; }

		public CumulativeWeightProbability(int weight, double cumulativeProbability)
		{
			this.Weight = weight;
			this.CumulativeProbability = cumulativeProbability;
		}
	}
}
