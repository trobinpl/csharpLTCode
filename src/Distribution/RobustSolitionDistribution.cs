using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distribution
{
	public class RobustSolitionDistribution
	{
		public int k { get; set; }
		public float delta { get; set; }
		public float c { get; set; }

		public RobustSolitionDistribution(int k, float c, float delta)
		{
			this.k = k;
			this.delta = delta;
			this.c = c;
		}

		private double R
		{
			get
			{
				return this.c * Math.Log(this.k/this.delta)*Math.Sqrt(this.k);
			}
		}

		private double GetTau(double i)
		{
			if(i >= 1 && i <= this.k / this.R - 1)
			{
				return this.R / i * k;
			}
			if(i == k / R)
			{
				return R * Math.Log(R / delta) / k;
			}
			if (i >= k/R+1 && i <= k)
			{
				return 0;
			}
			return -1;
		}

		private double GetIdealSolitionValue(double i)
		{
			if(i == 1)
			{
				return 1 / k;
			}
			if(i > 1)
			{
				return 1 / i * (i - 1);
			}
			return -1;
		}

		private double CalculateBeta()
		{
			double sum = 0;
			for(int i=1; i<= k; i++)
			{
				sum += GetIdealSolitionValue(i) + GetTau(i);
			}
			return sum;
		}
	}
}