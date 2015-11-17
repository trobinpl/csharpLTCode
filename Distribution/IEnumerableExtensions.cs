using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution
{
	public static class IEnumerableExtensions
	{
		public static IEnumerable<double> CumulativeSum(this IEnumerable<double> sequence)
		{
			double sum = 0;
			foreach (var item in sequence)
			{
				sum += item;
				yield return sum;
			}
		}

		public static IEnumerable<CumulativeWeightProbability> CumulativeSum(this IEnumerable<WeightProbability> sequence)
		{
			double sum = 0;
			foreach (WeightProbability item in sequence)
			{
				sum += item.Probability;
				yield return new CumulativeWeightProbability(item.Weight, sum);
			}
		}
	}
}
