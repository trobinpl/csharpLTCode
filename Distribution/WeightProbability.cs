using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution
{
	public class WeightProbability
	{
		public int Weight { get; set; }
		public double Probability { get; set; }

		public WeightProbability(int weight, double probability)
		{
			Weight = weight;
			Probability = probability;
		}
	}
}
