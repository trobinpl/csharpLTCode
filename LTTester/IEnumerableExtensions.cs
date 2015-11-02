using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTTester
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
	}
}
