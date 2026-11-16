using System.Numerics;

namespace aoc2024
{
    public class p1a
    {
        public static void solve1()
        {
            string[] inputs = File.ReadAllLines(".\\aoc2024\\2024-1-real.txt");
            int len = inputs.Length;
            int[] valueA = new int[len];
            int[] valueB = new int[len];

            int index = 0;

            foreach (var line in inputs)
            {
                string[] val = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                valueA[index] = int.Parse(val[0]);
                valueB[index] = int.Parse(val[1]);
                index++;
            }

            // Order low-high
            Array.Sort(valueA);
            Array.Sort(valueB);

            BigInteger total = 0;
            for (index = 0; index < len; index++)
            {
                // if the value is bigger than 0 we add with +
                if (valueB[index] - valueA[index] > 0)
                {
                    total += valueB[index] - valueA[index];
                }
                else
                {
                    // smaller than 0 so we use --
                    total -= valueB[index] - valueA[index];
                }
            }

            Console.WriteLine(total);
        }
    }
}
