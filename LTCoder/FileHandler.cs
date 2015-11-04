using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTCoder
{
	public class FileHandler
	{
		public FileHandler(string filePath, int numberOfFileSegments)
		{
			if (File.Exists(filePath))
			{
				this.reader = new BinaryReader(File.OpenRead(filePath));
				this.filePath = filePath;
				this.numberOfFileSegments = numberOfFileSegments;
				this.random = new Random();
			}
			else
			{
				throw new FileNotFoundException();
			}
		}

		private string filePath { get; set; }
		private FileInfo fileInfo
		{
			get
			{
				return new FileInfo(filePath);
			}
		}

		private int numberOfFileSegments { get; set; }

		private int segmentSize
		{
			get
			{
				double lengthByNumberOfSegments = fileInfo.Length / (double)numberOfFileSegments;
				return (int)Math.Ceiling(lengthByNumberOfSegments);
			}
		}

		private Random random;

		private BinaryReader reader { get; set; }

		public FileSegment GetSegment(int i)
		{
			byte[] buffer = new byte[segmentSize];
			this.reader.BaseStream.Position = segmentSize * i;
			this.reader.Read(buffer, 0, segmentSize);
			return new FileSegment()
			{
				SegmentNumber = i,
				Data = new BitArray(buffer)
			};
		}

		public List<FileSegment> GetRandomSegments(int segmentsCount)
		{
			if (segmentsCount > numberOfFileSegments)
			{
				throw new ArgumentOutOfRangeException();
			}

			List<FileSegment> segments = new List<FileSegment>();
			for (int i = 0; i < segmentsCount; i++)
			{
				int segmentNumber = this.random.Next(numberOfFileSegments);
				segments.Add(GetSegment(segmentNumber));
			}
			return segments;
		}
	}
}
