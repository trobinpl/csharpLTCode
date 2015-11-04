using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTCoder
{
    public class Coder
    {
		private List<FileSegment> segments { get; set; }
		public int segmentsCount 
		{ 
			get 
			{
				return segments.Count();
			} 
		}

		public int segmentSize { get { return firstSegment.Data.Count; } }

		public FileSegment firstSegment { get { return segments.First(); } }

		public Coder(List<FileSegment> segments)
		{
			this.segments = segments;
		}

		public CodedPiece CodeSegments()
		{
			List<int> pieceBuilders = new List<int>() { firstSegment.SegmentNumber };
			BitArray xoredBits = new BitArray(firstSegment.Data);

			foreach (FileSegment segment in segments.Skip(1))
			{
				var currentBits = new BitArray(segment.Data);
				xoredBits = xoredBits.Xor(currentBits);
				pieceBuilders.Add(segment.SegmentNumber);
			}

			return new CodedPiece()
			{
				BasedOnSegments = pieceBuilders,
				CodedWord = xoredBits
			};
		}
    }
}
