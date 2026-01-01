using System;
using System.Collections;
using System.Linq;

public class p5b
{
	public class Range
	{
		public long low { get; set; }
		public long high { get; set; }
	}

	public ArrayList ranges = new ArrayList();

	public void Main()
	{
		//string[] inputs = File.ReadAllLines("5a-example.txt");
		string[] inputs = File.ReadAllLines("5a.txt");

		// Load ranges to process
		for (int j = 0; j < inputs.Length; j++)
		{
			if (inputs[j].Contains("-"))
			{
				Range r = new Range();
				r.low = long.Parse(inputs[j].Split('-')[0]);
				r.high = long.Parse(inputs[j].Split('-')[1]);
				ranges.Add(r);
			}
			else
			{
				continue;
			}
		}

		Range[] rangesToCombine = ranges.ToArray(typeof(Range)) as Range[];
		var orderedRanges = rangesToCombine.OrderBy(r => r.low).ToList();

		p5b.Range[] combinedRanges = new p5b.Range[rangesToCombine.Length];

		int i = 0;
		combinedRanges[i] = orderedRanges[i];

		foreach (Range x in orderedRanges)
		{
			if (CheckMerge(combinedRanges[i].low, combinedRanges[i].high, x.low, x.high))
			{
				// we can merge them
				combinedRanges[i].low = Math.Min(combinedRanges[i].low, x.low);

				combinedRanges[i].high = Math.Max(combinedRanges[i].high, x.high);
			}
			else
			{
				i++;
				combinedRanges[i] = x;
			}
		}

		long fresh = 0;
		foreach (Range x in combinedRanges.Where(x => x != null))
		{
			fresh += (x.high - x.low) + 1;
		}

		Console.WriteLine("fresh:" + fresh);
	}

	private bool CheckMerge(long prevLow, long prevHigh, long low, long high)
	{
		// Since ranges are sorted by lowest
		return low <= prevHigh + 1;
	}
}