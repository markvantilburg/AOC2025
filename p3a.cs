using System;

public class p3a
{
    public static void Main()
    {
        string[] inputs = File.ReadAllLines("3a.txt");

        long totalJolt = 0;

        foreach (string line in inputs)
        {
            int high1 = 0;
            int high2 = 0;
            for (int i = 0; i < line.Length; i++)
            {
                // set the highest value unless it's the last char
                if (int.Parse(line[i].ToString()) > high1 && i < line.Length - 1)
                {
                    high1 = int.Parse(line[i].ToString());
                    // reset 2 when we start again for position 1
                    high2 = 0;
                }
                else
                {
                    if (int.Parse(line[i].ToString()) > high2)
                    {
                        high2 = int.Parse(line[i].ToString());
                    }
                }
            }

            string joltVal = "" + high1 + "" + high2;
            totalJolt += int.Parse(joltVal);
        }
        
        Console.WriteLine("totalJolt= " + totalJolt);
    }
}
