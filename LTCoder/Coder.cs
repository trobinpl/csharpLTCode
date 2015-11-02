using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTCoder
{
    public class Coder
    {
		private int numberOfFileSegments { get; set; }

		public Coder(int numberOfFileSegments, byte[] byteArray)
		{
			this.numberOfFileSegments = numberOfFileSegments;
		}
    }
}
