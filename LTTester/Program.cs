using Distribution;
using LTCoder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution
{
	class Program
	{
		static int segmentsCount = 1000;
		static void Main(string[] args)
		{
			Random rand = new Random();
			RobustSolitonDistribution distribution = new RobustSolitonDistribution(segmentsCount, 0.2, 0.05);
			FileHandler handler = new FileHandler("results.txt", segmentsCount);

			for (int i = 0; i < 100; i++)
			{
				int nextWeight = distribution.NextWeight(rand.NextDouble());
				List<FileSegment> segments = handler.GetRandomSegments(nextWeight);
				Coder coder = new Coder(segments);
				CodedPiece codedPiece = coder.CodeSegments();
				foreach (bool bit in codedPiece.CodedWord)
				{
					Debug.Write((bit ? 1 : 0));
				}
				Debug.WriteLine("");
			}
			
			//RobustSolitonDistribution distribution = new RobustSolitonDistribution(30, 0.2, 0.05);
			//List<WeightProbability> zones = new List<WeightProbability>();
			//Dictionary<int, int> howMuch = new Dictionary<int, int>();
			
			//double random;
			//for (int i = 1; i <= 100; i++)
			//{
			//	double value = distribution.GetValue(i);
			//	WeightProbability prop = new WeightProbability(i, value);
			//	zones.Add(prop);
			//}

			//var cumulated = zones.Select(p => p.Probability).CumulativeSum().Select((i, index) => new { i, index });
			//for (int j = 0; j < 5000; j++)
			//{
			//	int weight = distribution.NextWeight(rand.NextDouble());
			//	if (howMuch.Keys.Contains(weight))
			//	{
			//		howMuch[weight]++;
			//	}
			//	else
			//	{
			//		howMuch[weight] = 1;
			//	}
			//}

			//StreamWriter writer = new StreamWriter("results2.txt");
			//foreach (KeyValuePair<int, int> pair in howMuch.OrderBy(k => k.Key))
			//{
			//	writer.WriteLine("{0},{1}", pair.Key, pair.Value);
			//}
			//writer.Close();
		}
	}
}
