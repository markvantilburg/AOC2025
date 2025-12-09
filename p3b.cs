using System;

public class p3b
{
    public static void Main()
    {
        string[] inputs = File.ReadAllLines("3a.txt");

        //string[] inputs =
        //{
        //    "987654321111111",
        //    "811111111111119",
        //    "234234234234278",
        //    "818181911112111"
        //};

        long totalJolt = 0;

        foreach (string line in inputs)
        {
            // Count all values
            //int maxPosition = line.Length;

            // Which values do we need
            int digitsLeft = 12;

            // Get the values from the string
            string theVal = "";
            int temp = int.Parse(line[0].ToString());

            int start = 0;
            while (digitsLeft > 0)
            {
                int currentDigit = int.Parse(line[start].ToString());
                
                for (int i = start; i < line.Length - (digitsLeft - 1); i++)
                {
                    if (int.Parse(line[i].ToString()) > currentDigit)
                    {
                        currentDigit = int.Parse(line[i].ToString());
                        start = i;
                    }
                }
                theVal += currentDigit;
                digitsLeft--;
                start++;
            }

            totalJolt += long.Parse(theVal);

            Console.WriteLine(theVal);
        }

        Console.WriteLine("totalJolt= " + totalJolt);
        Console.WriteLine("press any key");
        Console.ReadKey();
    }
}