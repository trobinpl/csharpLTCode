using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution
{
	public class RobustSolitonDistribution
	{
		private int numberOfFileSegments { get; set; }
		private double decodingFailureProbability { get; set; }
		private double cConstant { get; set; }

		public RobustSolitonDistribution(int numberOfFileSegments, double cConstant, double decodingFailureProbability)
		{
			this.numberOfFileSegments = numberOfFileSegments;
			this.decodingFailureProbability = decodingFailureProbability;
			this.cConstant = cConstant;
		}

		private double R
		{
			get
			{
				return this.cConstant * Math.Log(this.numberOfFileSegments / this.decodingFailureProbability) * Math.Sqrt(this.numberOfFileSegments);
			}
		}

		private double GetTau(int i)
		{
			double boundary = this.numberOfFileSegments / this.R;
			double result = 0;
			if (i >= 1 && i <= boundary - 1)
			{
				result = this.R / (i * numberOfFileSegments);
			}
			if (i == boundary)
			{
				result = (R * Math.Log(R / decodingFailureProbability)) / numberOfFileSegments;
			}
			if (i > boundary)
			{
				result = 0;
			}
			return result;
		}

		private double IdealSolitonValue(int i)
		{
			double result = 0;
			if (i == 1)
			{
				result = 1d / numberOfFileSegments;
			}
			if (i > 1)
			{
				result = 1d / (i * (i - 1));
			}
			return result;
		}

		private double CalculateBeta()
		{
			double sum = 0;
			for (int i = 1; i <= numberOfFileSegments; i++)
			{
				sum += IdealSolitonValue(i) + GetTau(i);
			}
			return sum;
		}

		public double GetValue(int i)
		{
			double tau = GetTau(i);
			double ideal = IdealSolitonValue(i);
			double beta = CalculateBeta();
            return (tau + ideal) / beta;
		}
	}
}
