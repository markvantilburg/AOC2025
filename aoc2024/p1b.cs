using System.Numerics;

namespace aoc2024
{
    public class p1b
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

            // // Order low-high
            // Array.Sort(valueA);
            // Array.Sort(valueB);

            BigInteger total = 0;
            foreach (int x in valueA)
            {
                int[] matches = Array.FindAll(valueB, y => y == x);

                if (matches.Length > 0)
                {
                    total += x * matches.Length;
                }
            }

            Console.WriteLine(total);
        }
    }
}