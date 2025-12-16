using System;
using System.Collections;

public class p5a
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

        long numberFresh = 0;

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
                if (string.IsNullOrWhiteSpace(inputs[j]))
                {
                    continue;
                }

                if (CheckRange(long.Parse(inputs[j])))
                {
                    numberFresh++;
                }
            }
        }

        Console.WriteLine("numberFresh= " + numberFresh);
    }

    private bool CheckRange(long valToCheck)
    {
        foreach (Range x in ranges)
        {
            if (valToCheck >= x.low && valToCheck <= x.high)
            {
                return true;
            }
        }

        return false;
    }
}
