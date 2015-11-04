using Distribution;
using LTCoder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTTester
{
	class Program
	{
		static void Main(string[] args)
		{
			FileHandler handler = new FileHandler("results.txt", 100);
			List<FileSegment> segments = handler.GetRandomSegments(2);

			Coder coder = new Coder(segments);
			CodedPiece codedPiece = coder.CodeSegments();


			//RobustSolitonDistribution distribution = new RobustSolitonDistribution(30, 0.2, 0.05);
			//List<WeightProbability> zones = new List<WeightProbability>();
			//Dictionary<int, int> howMuch = new Dictionary<int, int>();
			//Random rand = new Random();
			//double random;
			//for (int i = 1; i <= 30; i++)
			//{
			//	double value = distribution.GetValue(i);
			//	WeightProbability prop = new WeightProbability(i, value);
			//	zones.Add(prop);
			//}

			//var cumulated = zones.Select(p => p.Probability).CumulativeSum().Select((i, index) => new { i, index });
			//for (int j=0; j<1000; j++)
			//{
			//	random = rand.NextDouble();
			//	var matchIndex = cumulated.First(m => random < m.i).index;
			//	Console.WriteLine(zones[matchIndex].Weight);
			//	if (howMuch.Keys.Contains(matchIndex))
			//	{
			//		howMuch[matchIndex]++;
			//	}
			//	else
			//	{
			//		howMuch[matchIndex] = 1;
			//	}
			//}

			//StreamWriter writer = new StreamWriter("results.txt");
			//foreach(KeyValuePair<int, int> pair in howMuch)
			//{
			//	writer.WriteLine("{0},{1}", pair.Key, pair.Value);
			//}
			//writer.Close();
		}
	}
}
